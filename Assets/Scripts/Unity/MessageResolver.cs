using System;
using System.Collections.Generic;
using TicTacToe.Core;
using TicTacToe.Logic.Messages;
using TicTacToe.Unity.Extensions;
using TicTacToe.Unity.UI;
using UnityEngine;
using UnityEngine.Assertions;
using Object = UnityEngine.Object;

namespace TicTacToe.Unity
{
    public class MessageResolver
    {
        private readonly Dictionary<int, GameObject> _signsDictionary = new();
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

                        var camera = Camera.main;

                        Assert.IsNotNull(camera);

                        camera.orthographic = message.Orthographic;
                        camera.orthographicSize = message.OrthographicSize;
                        camera.transform.position = message.Position.Convert();

                        break;
                    case InstantiateCellViewMessage message:

                        var newCellView = Object.Instantiate(Configuration.CellView, message.Position.Convert(),
                            Quaternion.identity);
                        newCellView.EntityId = message.EntityId;

                        break;
                    case InstantiateSignViewMessage message:

                        switch (message.SignType)
                        {
                            case SignType.Cross:
                                var newCrossView = Object.Instantiate(Configuration.CrossView,
                                    message.Position.Convert(), Quaternion.identity);
                                newCrossView.EntityId = message.Id;
                                _signsDictionary.Add(message.Id, newCrossView.gameObject);
                                break;
                            case SignType.Ring:
                                var newRingView = Object.Instantiate(Configuration.RingView, message.Position.Convert(),
                                    Quaternion.identity);
                                newRingView.EntityId = message.Id;
                                _signsDictionary.Add(message.Id, newRingView.gameObject);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        break;
                    case DeleteSignMessage message:
                        Object.Destroy(_signsDictionary[message.Id]);
                        _signsDictionary.Remove(message.Id);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(result));
                }
            }
        }
    }
}