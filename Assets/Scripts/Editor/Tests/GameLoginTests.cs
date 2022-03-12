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
    public class GameLoginTests
    {
        [Test]
        public void CheckHorizontalChainZero()
        {
            var world = new EcsWorld();

            var cells = CreateTestCells(world);

            var chainLenght = cells.GetLongestChain(world,Vector2.Zero);

            Assert.AreEqual(0, chainLenght);
        }

        [Test]
        public void CheckHorizontalChainOne()
        {
            var world = new EcsWorld();


            var cells = CreateTestCells(world);

            var takenPool = world.GetPool<Taken>();
            takenPool.Add(cells[Vector2.Zero]).Type = SignType.Cross;

            var chainLenght = cells.GetLongestChain(world,Vector2.Zero);

            Assert.AreEqual(1, chainLenght);
        }

        [Test]
        public void CheckHorizontalChainTwoLeft()
        {
            var world = new EcsWorld();


            var cells = CreateTestCells(world);

            var takenPool = world.GetPool<Taken>();
            takenPool.Add(cells[new Vector2(2, 0)]).Type = SignType.Cross;
            takenPool.Add(cells[new Vector2(1, 0)]).Type = SignType.Cross;

            var chainLenght = cells.GetLongestChain(world,new Vector2(2, 0));


            Assert.AreEqual(2, chainLenght);
        }

        [Test]
        public void CheckHorizontalChainTwoRight()
        {
            var world = new EcsWorld();

            var cells = CreateTestCells(world);

            var takenPool = world.GetPool<Taken>();
            takenPool.Add(cells[new Vector2(2, 0)]).Type = SignType.Cross;
            takenPool.Add(cells[new Vector2(1, 0)]).Type = SignType.Cross;

            var chainLenght = cells.GetLongestChain(world,new Vector2(1, 0));


            Assert.AreEqual(2, chainLenght);
        }

        [Test]
        public void CheckVerticalChainThree()
        {
            var world = new EcsWorld();

            var cells = CreateTestCells(world);

            var takenPool = world.GetPool<Taken>();
            takenPool.Add(cells[new Vector2(0, 2)]).Type = SignType.Cross;
            takenPool.Add(cells[new Vector2(0, 1)]).Type = SignType.Cross;
            takenPool.Add(cells[new Vector2(0, 0)]).Type = SignType.Cross;

            var chainLenght = cells.GetLongestChain(world,new Vector2(0, 1));


            Assert.AreEqual(3, chainLenght);
        }

        [Test]
        public void CheckFirstDiagonalChainThree()
        {
            var world = new EcsWorld();

            var cells = CreateTestCells(world);

            var takenPool = world.GetPool<Taken>();
            takenPool.Add(cells[new Vector2(2, 2)]).Type = SignType.Cross;
            takenPool.Add(cells[new Vector2(1, 1)]).Type = SignType.Cross;
            takenPool.Add(cells[new Vector2(0, 0)]).Type = SignType.Cross;

            var chainLenght = cells.GetLongestChain(world,new Vector2(1, 1));


            Assert.AreEqual(3, chainLenght);
        }

        [Test]
        public void CheckSecondDiagonalChainThreeOne()
        {
            var world = new EcsWorld();

            var cells = CreateTestCells(world);
            var takenPool = world.GetPool<Taken>();
            takenPool.Add(cells[new Vector2(2, 0)]).Type = SignType.Cross;
            takenPool.Add(cells[new Vector2(1, 1)]).Type = SignType.Cross;
            takenPool.Add(cells[new Vector2(0, 2)]).Type = SignType.Cross;

            var chainLenght = cells.GetLongestChain(world,new Vector2(1, 1));


            Assert.AreEqual(3, chainLenght);
        }

        private static Dictionary<Vector2, int> CreateTestCells(EcsWorld world)
        {
            return new Dictionary<Vector2, int>
            {
                {new Vector2(0, 0), CreateCell(world, new Vector2(0, 0))},
                {new Vector2(0, 1), CreateCell(world, new Vector2(0, 1))},
                {new Vector2(0, 2), CreateCell(world, new Vector2(0, 2))},
                {new Vector2(1, 0), CreateCell(world, new Vector2(1, 0))},
                {new Vector2(1, 1), CreateCell(world, new Vector2(1, 1))},
                {new Vector2(1, 2), CreateCell(world, new Vector2(1, 2))},
                {new Vector2(2, 0), CreateCell(world, new Vector2(2, 0))},
                {new Vector2(2, 1), CreateCell(world, new Vector2(2, 1))},
                {new Vector2(2, 2), CreateCell(world, new Vector2(2, 2))}
            };
        }

        private static int CreateCell(EcsWorld world, Vector2 position)
        {
            var id = world.NewEntity();

            var positionPool = world.GetPool<Position>();
            var cellPool = world.GetPool<Cell>();

            ref var positionComponent = ref positionPool.Add(id);
            positionComponent.Value = position;

            cellPool.Add(id);

            return id;
        }
    }
}