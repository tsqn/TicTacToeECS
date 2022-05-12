using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using TicTacToe.Interfaces;
using UnityEngine;

namespace TicTacToe.Server
{
    public class Server : IServer
    {
        private readonly Thread _tcpListenerThread;
        private TcpClient _connectedTcpClient;
        private TcpListener _tcpListener;
        private bool _isActive;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public Server()
        {
            _tcpListenerThread = new Thread(ListenForIncomingRequests)
            {
                IsBackground = true
            };
            _isActive = true;
            _cancellationTokenSource = new CancellationTokenSource();
            _tcpListenerThread.Start(_cancellationTokenSource.Token);
        }

        public void SendWorldStateMessage(object state)
        {
            if (_connectedTcpClient == null)
            {
                return;
            }

            var stream = _connectedTcpClient.GetStream();

            if (stream.CanWrite)
            {
                var serverMessage = JsonConvert.SerializeObject(state);
                var serverMessageAsByteArray = Encoding.ASCII.GetBytes(serverMessage);
                stream.Write(serverMessageAsByteArray, 0, serverMessageAsByteArray.Length);
            }
        }

        private void ListenForIncomingRequests(object cancellationToken)
        {
            _tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8053);
            _tcpListener.Start();
            var bytes = new byte[1024];

            if (cancellationToken is not CancellationToken ct)
            {
                throw new Exception("Invalid cancellation Token");
            }

            try
            {
                using (_connectedTcpClient = _tcpListener.AcceptTcpClient())
                {
                    while (_isActive && _connectedTcpClient.Connected && !ct.IsCancellationRequested)
                    {
                        using (var stream = _connectedTcpClient.GetStream())
                        {
                            int length;
                            while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                            {
                                var incomingData = new byte[length];

                                Array.Copy(bytes, 0, incomingData, 0, length);
                                var clientMessage = Encoding.ASCII.GetString(incomingData);
                                Console.WriteLine(clientMessage);
                            }
                        }
                    }
                }
            }
            catch (SocketException e)
            {
                if (e.ErrorCode == 10004)
                {
                    // Socket exception after thread abort.
                    return;
                }
                throw;
            }
        }

        public void Dispose()
        {
            _isActive = false;
            _cancellationTokenSource.Cancel();
            _tcpListener.Stop();
            _tcpListenerThread.Abort();
            _connectedTcpClient?.Dispose();
            Debug.Log("Disposed");
        }
    }
}