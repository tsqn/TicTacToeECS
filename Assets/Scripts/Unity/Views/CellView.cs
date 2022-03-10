using Interfaces;
using Unity.Wrappers;
using UnityEngine;

namespace Unity.Views
{
    public class CellView : MonoDecorator, ICellView
    {
        [SerializeField]
        private int _entity;

        public int Entity
        {
            get => _entity;
            set => _entity = value;
        }
    }
}