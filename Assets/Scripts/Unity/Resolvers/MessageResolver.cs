using System;
using TicTacToe.Logic.Messages;
using TicTacToe.Unity.UI;
using UnityEngine;

namespace TicTacToe.Unity.Resolvers
{
    public class MessageResolver
    {
        public Configuration Configuration;
        public MessagesBridge MessagesBridge;
        public WinScreen WinScreen;

        public void Update()
        {
            while (MessagesBridge.OutputMessages.TryDequeue(out var result))
            {
                Debug.Log($"{result.GetType()} event occured.");
                switch (result)
                {
                    case GameOverMessage message:
                        WinScreen.SetWinner(message.Result);
                        break;
                    
                    case ApplyCameraSettingsMessage message:
                        CameraResolver.SetCameraSettings(message);
                        break;
                    
                    case InstantiateCellViewMessage message:
                        InstantiationResolver.Instantiate(Configuration.CellView, message);
                        break;
                    case InstantiateSignViewMessage message:
                        InstantiationResolver.InstantiateSign(message, Configuration.CrossView, Configuration.RingView);
                        break;
                    
                    case DeleteSignMessage message:
                        InstantiationResolver.DeleteSigns(message);
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException(nameof(result));
                }
            }
        }
    }
}