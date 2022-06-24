using TicTacToe.Interfaces;
using TicTacToe.Unity.Extensions;
using TicTacToe.Unity.Views;
using UnityEngine;

namespace TicTacToe.Unity
{
    [CreateAssetMenu]
    public class Configuration : ScriptableObject, IConfiguration
    {
        [SerializeField]
        private int _levelWidth = 3;

        [SerializeField]
        private int _levelHeight = 3;

        [SerializeField]
        private int _chainLength = 3;

        [SerializeField]
        private CellView _cellView;

        [SerializeField]
        private Vector2 _offset;

        [SerializeField]
        private SignView _crossView;

        [SerializeField]
        private SignView _ringView;

        public CellView CellView => _cellView;
        public System.Numerics.Vector2 Offset => _offset.Convert();
        public int LevelWidth => _levelWidth;
        public int LevelHeight => _levelHeight;
        public int ChainLength => _chainLength;
        public SignView CrossView => _crossView;
        public SignView RingView => _ringView;
    }
}