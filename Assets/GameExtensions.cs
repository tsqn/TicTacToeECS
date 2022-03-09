using System.Collections.Generic;
using Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems
{
    public static class GameExtensions
    {
        public static int GetLongestChain(this Dictionary<Vector2Int, int> cells, EcsWorld ecsWorld,
            Vector2Int position)
        {
            var startEntity = cells[position];

            var takenPool = ecsWorld.GetPool<Taken>();

            if (!takenPool.Has(startEntity))
            {
                return 0;
            }

            var startType = takenPool.Get(startEntity).value;


            var horizontalLength = CheckLine(ecsWorld, cells, position, startType, new Vector2Int(1, 0));
            var verticalLength = CheckLine(ecsWorld, cells, position, startType, new Vector2Int(0, 1));
            var firstDiagonalLength = CheckLine(ecsWorld, cells, position, startType, new Vector2Int(1, 1));
            var secondDiagonalLength = CheckLine(ecsWorld, cells, position, startType, new Vector2Int(-1, 1));

            return Mathf.Max(horizontalLength, verticalLength, firstDiagonalLength, secondDiagonalLength);
        }

        private static int CheckLine(EcsWorld world, Dictionary<Vector2Int, int> cells, Vector2Int position,
            SignType startType, Vector2Int direction)
        {
            var resultLength = 1;

            resultLength += SearchForward(world, cells, position, startType, direction);
            resultLength += SearchForward(world, cells, position, startType, direction * -1);

            return resultLength;
        }

        private static int SearchForward(EcsWorld world, Dictionary<Vector2Int, int> cells, Vector2Int position,
            SignType startType,
            Vector2Int direction)
        {
            var currentLength = 0;
            var currentPosition = position + direction;
            while (cells.TryGetValue(currentPosition, out var entity))
            {
                var takenPool = world.GetPool<Taken>();

                if (!takenPool.Has(entity))
                {
                    break;
                }


                var type = takenPool.Get(entity).value;

                if (type != startType)
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