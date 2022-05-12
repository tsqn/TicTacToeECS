using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TicTacToe.Client
{
    public class Client : IDisposable
    {
        private readonly object _lockObject = new();
        private Thread _clientReceiveThread;
        private string _serializedState;
        private TcpClient _socketConnection;
        private bool _isActive;

        public Client()
        {
            ConnectToTcpServer();
        }

        public string CurrentState
        {
            get
            {
                lock (_lockObject)
                {
                    return _serializedState;
                }
            }
        }

        private void ConnectToTcpServer()
        {
            _clientReceiveThread = new Thread(ListenForData)
            {
                IsBackground = true
            };
            _isActive = true;
            _clientReceiveThread.Start();
        }

        private void ListenForData()
        {
            _socketConnection = new TcpClient("localhost", 8053);
            var bytes = new byte[1024];
            while (_isActive)
            {
                using (var stream = _socketConnection.GetStream())
                {
                    int length;
                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        var incomingData = new byte[length];
                        Array.Copy(bytes, 0, incomingData, 0, length);
                        
                        lock (_lockObject)
                        {
                            _serializedState = Encoding.ASCII.GetString(incomingData);
                        }
                    }
                }
            }
        }

        private void SendMessage()
        {
            if (_socketConnection == null)
            {
                return;
            }


            var stream = _socketConnection.GetStream();
            if (stream.CanWrite)
            {
                const string clientMessage = "This is a message from one of your clients.";
                var clientMessageAsByteArray = Encoding.ASCII.GetBytes(clientMessage);
                stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
            }
        }

        public void Dispose()
        {
            _isActive = false;
            // _clientReceiveThread.Abort();
            _socketConnection?.Dispose();
        }
    }
}