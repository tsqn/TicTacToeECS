using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TicTacToe.Logic.Components;
using TicTacToe.Unity.Wrappers;
using UnityEngine;

namespace TicTacToe.Unity
{
    public class Synchronizer : IDisposable
    {
        private static Synchronizer _instance;
        private readonly Client.Client _client;
        private readonly Dictionary<int, MonoDecorator> _objects;

        private Synchronizer()
        {
            _client = new Client.Client();
            _objects = new Dictionary<int, MonoDecorator>();
        }

        public static Synchronizer Instance => _instance ??= new Synchronizer();

        public void Sync()
        {
            var stateMessage = _client.CurrentState;

            if (string.IsNullOrEmpty(stateMessage))
            {
                return;
            }

            // Debug.Log(stateMessage);
            var state = JsonConvert.DeserializeObject<WorldState>(stateMessage);

            foreach (var (key, value) in state.State)
            {
                if (_objects.TryGetValue(key, out var monoObject))
                {
                    monoObject.transform.position =
                        new Vector3(value.X, value.Y, 0);
                }
            }
        }

        public void AddObject(int id, MonoDecorator newObject)
        {
            _objects.TryAdd(id, newObject);
            // Debug.Log($"Object added - id:{id}, object:{newObject}");
        }

        public void Dispose()
        {
            _client.Dispose();
            _objects.Clear();
        }
    }
}