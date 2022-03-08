using System.Collections.Generic;
using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public static class GameExtensions
    {
        public static int GetLongestChain(this Dictionary<Vector2Int, EcsEntity> cells, Vector2Int position)
        {
            var startEntity = cells[position];

            if (!startEntity.Has<Taken>())
            {
                return 0;
            }

            var startType = startEntity.Get<Taken>().value;


            var horizontalLength = CheckLine(cells, position, startType, new Vector2Int(1, 0));
            var verticalLength = CheckLine(cells, position, startType, new Vector2Int(0, 1));
            var firstDiagonalLength = CheckLine(cells, position, startType, new Vector2Int(1, 1));
            var secondDiagonalLength = CheckLine(cells, position, startType, new Vector2Int(-1, 1));

            return Mathf.Max(horizontalLength, verticalLength, firstDiagonalLength, secondDiagonalLength);
        }

        private static int CheckLine(Dictionary<Vector2Int, EcsEntity> cells, Vector2Int position,
            SignType startType, Vector2Int direction)
        {
            var currentLenght = 1;
            var currentPosition = position + direction;
            while (cells.TryGetValue(currentPosition, out var entity))
            {
                if (!entity.Has<Taken>())
                {
                    break;
                }

                var type = entity.Get<Taken>().value;

                if (type != startType)
                {
                    break;
                }

                currentLenght++;
                currentPosition += direction;
            }

            direction *= -1;
            currentPosition = position + direction;
            while (cells.TryGetValue(currentPosition, out var entity))
            {
                if (!entity.Has<Taken>())
                {
                    break;
                }

                var type = entity.Get<Taken>().value;

                if (type != startType)
                {
                    break;
                }

                currentLenght++;
                currentPosition += direction;
            }

            return currentLenght;
        }
    }
}