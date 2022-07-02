using System.Collections.Generic;
using System.Numerics;
using Leopotam.EcsLite;
using NUnit.Framework;
using TicTacToe.Core;
using TicTacToe.Logic.Components;
using TicTacToe.Logic.Extensions;

namespace TicTacToe.Editor.Tests
{
    [TestFixture]
    public class GameLogicTests
    {
        [Test]
        public void CheckHorizontalChainZero()
        {
            var cells = CreateTestCells();

            var chainLenght = cells.GetLongestChain(Vector2.Zero);

            Assert.AreEqual(0, chainLenght);
        }

        [Test]
        public void CheckHorizontalChainOne()
        {
            var world = new EcsWorld();

            var cells = CreateTestCells();

            cells[Vector2.Zero] = SignType.Cross;

            var chainLenght = cells.GetLongestChain(Vector2.Zero);

            Assert.AreEqual(1, chainLenght);
        }

        [Test]
        public void CheckHorizontalChainTwoLeft()
        {
            var world = new EcsWorld();

            var cells = CreateTestCells();

            cells[new Vector2(2, 0)] = SignType.Cross;
            cells[new Vector2(1, 0)] = SignType.Cross;

            var chainLenght = cells.GetLongestChain(new Vector2(2, 0));

            Assert.AreEqual(2, chainLenght);
        }

        [Test]
        public void CheckHorizontalChainTwoRight()
        {
            var world = new EcsWorld();

            var cells = CreateTestCells();

            var takenPool = world.GetPool<Sign>();
            cells[new Vector2(2, 0)] = SignType.Cross;
            cells[new Vector2(1, 0)] = SignType.Cross;

            var chainLenght = cells.GetLongestChain(new Vector2(1, 0));


            Assert.AreEqual(2, chainLenght);
        }

        [Test]
        public void CheckVerticalChainThree()
        {
            var world = new EcsWorld();

            var cells = CreateTestCells();

            cells[new Vector2(0, 2)] = SignType.Cross;
            cells[new Vector2(0, 1)] = SignType.Cross;
            cells[new Vector2(0, 0)] = SignType.Cross;

            var chainLenght = cells.GetLongestChain(new Vector2(0, 1));

            Assert.AreEqual(3, chainLenght);
        }

        [Test]
        public void CheckFirstDiagonalChainThree()
        {
            var world = new EcsWorld();

            var cells = CreateTestCells();

            cells[new Vector2(2, 2)] = SignType.Cross;
            cells[new Vector2(1, 1)] = SignType.Cross;
            cells[new Vector2(0, 0)] = SignType.Cross;

            var chainLenght = cells.GetLongestChain(new Vector2(1, 1));

            Assert.AreEqual(3, chainLenght);
        }

        [Test]
        public void CheckSecondDiagonalChainThreeOne()
        {
            var world = new EcsWorld();

            var cells = CreateTestCells();
            cells[new Vector2(2, 0)] = SignType.Cross;
            cells[new Vector2(1, 1)] = SignType.Cross;
            cells[new Vector2(0, 2)] = SignType.Cross;

            var chainLenght = cells.GetLongestChain(new Vector2(1, 1));

            Assert.AreEqual(3, chainLenght);
        }

        private static Dictionary<Vector2, SignType> CreateTestCells()
        {
            return new Dictionary<Vector2, SignType>
            {
                {new Vector2(0, 0), SignType.None},
                {new Vector2(0, 1), SignType.None},
                {new Vector2(0, 2), SignType.None},
                {new Vector2(1, 0), SignType.None},
                {new Vector2(1, 1), SignType.None},
                {new Vector2(1, 2), SignType.None},
                {new Vector2(2, 0), SignType.None},
                {new Vector2(2, 1), SignType.None},
                {new Vector2(2, 2), SignType.None}
            };
        }

        private static int CreateCell(EcsWorld world, Vector2 position)
        {
            var id = world.NewEntity();

            var positionPool = world.GetPool<CellPosition>();
            var cellPool = world.GetPool<Cell>();

            ref var positionComponent = ref positionPool.Add(id);
            positionComponent.Value = position;

            cellPool.Add(id);

            return id;
        }
    }
}