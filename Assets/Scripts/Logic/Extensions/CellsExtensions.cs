using System;
using System.Collections.Generic;
using System.Numerics;
using Leopotam.EcsLite;
using TicTacToe.Core;
using TicTacToe.Logic.Components;

namespace TicTacToe.Logic.Extensions
{
    public static class CellsExtensions
    {
        public static int GetLongestChain(this Dictionary<Vector2, int> cells, EcsWorld ecsWorld,
            Vector2 position)
        {
            var startEntity = cells[position];

            var takenPool = ecsWorld.GetPool<Sign>();

            if (!takenPool.Has(startEntity))
            {
                return 0;
            }

            var startType = takenPool.Get(startEntity).Type;


            var horizontalLength = CheckLine(ecsWorld, cells, position, startType, new Vector2(1, 0));
            var verticalLength = CheckLine(ecsWorld, cells, position, startType, new Vector2(0, 1));
            var firstDiagonalLength = CheckLine(ecsWorld, cells, position, startType, new Vector2(1, 1));
            var secondDiagonalLength = CheckLine(ecsWorld, cells, position, startType, new Vector2(-1, 1));

            return Math.Max(horizontalLength,
                Math.Max(Math.Max(verticalLength, firstDiagonalLength), secondDiagonalLength));
        }

        private static int CheckLine(EcsWorld world, Dictionary<Vector2, int> cells, Vector2 position,
            SignType startType, Vector2 direction)
        {
            var resultLength = 1;

            resultLength += SearchForward(world, cells, position, startType, direction);
            resultLength += SearchForward(world, cells, position, startType, direction * -1);

            return resultLength;
        }

        private static int SearchForward(EcsWorld world, Dictionary<Vector2, int> cells, Vector2 position,
            SignType startType,
            Vector2 direction)
        {
            var currentLength = 0;
            var currentPosition = position + direction;
            while (cells.TryGetValue(currentPosition, out var entity))
            {
                var takenPool = world.GetPool<Sign>();

                if (!takenPool.Has(entity))
                {
                    break;
                }


                var type = takenPool.Get(entity).Type;

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