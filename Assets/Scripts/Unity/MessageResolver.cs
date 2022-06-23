using System;
using TicTacToe.Interfaces;
using TicTacToe.Logic.Components;
using TicTacToe.Logic.Components.Events;
using TicTacToe.Logic.Messages;
using TicTacToe.Logic.Systems;
using TicTacToe.Unity.Decorators;
using TicTacToe.Unity.Extensions;
using UnityEngine;
using UnityEngine.Assertions;

namespace TicTacToe.Unity
{
    public class MessageResolver
    {
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

                        var camera = Camera.main;
                        
                        Assert.IsNotNull(camera);
                        
                        camera.orthographic = message.Orthographic;
                        camera.orthographicSize = message.OrthographicSize;
                        camera.transform.position = message.Position.Convert();
                        
                        break;
                    
                    case RequestScreenPointToRayMessage message:
                        
                        var ray = Camera.main.ScreenPointToRay(message.Position.Convert());
                        
                        if (Physics.Raycast(ray, out var hitInfo))
                        {
                            var cellView = hitInfo.collider.GetComponent<ICellView>();

                            if (cellView != null)
                            {
                                
                                MessagesBridge.InputMessages.Enqueue(new ClickedCellViewMessage()
                                {
                                    Entity = cellView.Entity
                                });
                            }
                        }
                        
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(result));
                }
            }
        }
    }
}