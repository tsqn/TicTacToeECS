using System;
using System.Collections.Generic;
using TicTacToe.Core;
using TicTacToe.Logic.Messages;
using TicTacToe.Unity.Extensions;
using TicTacToe.Unity.Views;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TicTacToe.Unity.Resolvers
{
    public class InstantiationResolver
    {
        private static readonly Dictionary<int, GameObject> SignsDictionary = new();
        
        public static void Instantiate(CellView configurationCellView, InstantiateCellViewMessage message)
        {
            var newCellView = Object.Instantiate(configurationCellView, message.Position.Convert(),
                Quaternion.identity);
            newCellView.EntityId = message.EntityId;
        }
        
        public static void InstantiateSign(InstantiateSignViewMessage message, SignView crossView, SignView ringView)
        {
            switch (message.SignType)
            {
                case SignType.Cross:
                    var newCrossView = Object.Instantiate(crossView,
                        message.Position.Convert(), Quaternion.identity);
                    newCrossView.EntityId = message.Id;
                    SignsDictionary.Add(message.Id, newCrossView.gameObject);
                    break;
                case SignType.Ring:
                    var newRingView = Object.Instantiate(ringView, message.Position.Convert(),
                        Quaternion.identity);
                    newRingView.EntityId = message.Id;
                    SignsDictionary.Add(message.Id, newRingView.gameObject);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        public static void DeleteSigns(DeleteSignMessage message)
        {
            Object.Destroy(SignsDictionary[message.Id]);
            SignsDictionary.Remove(message.Id);
        }
        
    }
}