using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Unity
{
    public class Event<T>
    {
        private readonly Dictionary<int, Action<T>> _listeners = new();

        public int AddListener(Action<T> listener)
        {
            var count = _listeners.Count;
            while (_listeners.ContainsKey(count))
            {
                count++;
            }

            var id = count;
            _listeners.Add(id, listener);

            return id;
        }

        public void Notify(T eventArgs)
        {
            for (var i = 0; i < _listeners.Count; i++)
            {
                _listeners[i].Invoke(eventArgs);
            }
        }

        public void RemoveAllListeners()
        {
            _listeners.Clear();
        }

        public void RemoveListener(int id)
        {
            _listeners.Remove(id);
        }
    }

    public class Event
    {
        private readonly Dictionary<int, Action> _listeners = new();

        public int AddListener(Action listener)
        {
            var count = _listeners.Count;
            while (_listeners.ContainsKey(count))
            {
                count++;
            }

            var id = count;
            _listeners.Add(id, listener);

            return id;
        }

        public void Notify()
        {
            var toNotify = _listeners.Values.ToArray();
            foreach (var listener in toNotify)
            {
                listener.Invoke();
            }
        }

        public void RemoveAllListeners()
        {
            _listeners.Clear();
        }

        public void RemoveListener(int id)
        {
            _listeners.Remove(id);
        }
    }
}