using System;
using System.Collections.Generic;
using System.Numerics;
using TicTacToe.Core;

namespace TicTacToe.Logic.Extensions
{
    public static class CellsExtensions
    {
        public static int GetLongestChain(this Dictionary<Vector2, SignType> cells,
            Vector2 position)
        {
            var startType = cells[position];

            if (startType == SignType.None)
            {
                return 0;
            }
            
            var horizontalLength = CheckLine(cells, position, startType, new Vector2(1, 0));
            var verticalLength = CheckLine(cells, position, startType, new Vector2(0, 1));
            var firstDiagonalLength = CheckLine(cells, position, startType, new Vector2(1, 1));
            var secondDiagonalLength = CheckLine(cells, position, startType, new Vector2(-1, 1));

            return Math.Max(horizontalLength,
                Math.Max(Math.Max(verticalLength, firstDiagonalLength), secondDiagonalLength));
        }

        private static int CheckLine(Dictionary<Vector2, SignType> cells, Vector2 position,
            SignType startType, Vector2 direction)
        {
            var resultLength = 1;

            resultLength += SearchForward(cells, position, startType, direction);
            resultLength += SearchForward(cells, position, startType, direction * -1);

            return resultLength;
        }

        private static int SearchForward(Dictionary<Vector2, SignType> cells, Vector2 position,
            SignType startType,
            Vector2 direction)
        {
            var currentLength = 0;
            var currentPosition = position + direction;
            while (cells.TryGetValue(currentPosition, out var entity))
            {
                if (entity != startType)
                {
                    break;
                }

                currentLength++;
                currentPosition += direction;
            }

            return currentLength;
        }
    }
}