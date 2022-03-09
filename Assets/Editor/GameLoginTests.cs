using System.Collections.Generic;
using Components;
using Leopotam.EcsLite;
using NUnit.Framework;
using Systems;
using UnityEngine;

[TestFixture]
public class GameLoginTests
{
    [Test]
    public void CheckHorizontalChainZero()
    {
        var world = new EcsWorld();

        var cells = CreateTestCells(world);

        var chainLenght = cells.GetLongestChain(world,Vector2Int.zero);

        Assert.AreEqual(0, chainLenght);
    }

    [Test]
    public void CheckHorizontalChainOne()
    {
        var world = new EcsWorld();


        var cells = CreateTestCells(world);

        var takenPool = world.GetPool<Taken>();
        takenPool.Add(cells[Vector2Int.zero]).value = SignType.Cross;

        var chainLenght = cells.GetLongestChain(world,Vector2Int.zero);

        Assert.AreEqual(1, chainLenght);
    }

    [Test]
    public void CheckHorizontalChainTwoLeft()
    {
        var world = new EcsWorld();


        var cells = CreateTestCells(world);

        var takenPool = world.GetPool<Taken>();
        takenPool.Add(cells[new Vector2Int(2, 0)]).value = SignType.Cross;
        takenPool.Add(cells[new Vector2Int(1, 0)]).value = SignType.Cross;

        var chainLenght = cells.GetLongestChain(world,new Vector2Int(2, 0));


        Assert.AreEqual(2, chainLenght);
    }

    [Test]
    public void CheckHorizontalChainTwoRight()
    {
        var world = new EcsWorld();

        var cells = CreateTestCells(world);

        var takenPool = world.GetPool<Taken>();
        takenPool.Add(cells[new Vector2Int(2, 0)]).value = SignType.Cross;
        takenPool.Add(cells[new Vector2Int(1, 0)]).value = SignType.Cross;

        var chainLenght = cells.GetLongestChain(world,new Vector2Int(1, 0));


        Assert.AreEqual(2, chainLenght);
    }

    [Test]
    public void CheckVerticalChainThree()
    {
        var world = new EcsWorld();

        var cells = CreateTestCells(world);

        var takenPool = world.GetPool<Taken>();
        takenPool.Add(cells[new Vector2Int(0, 2)]).value = SignType.Cross;
        takenPool.Add(cells[new Vector2Int(0, 1)]).value = SignType.Cross;
        takenPool.Add(cells[new Vector2Int(0, 0)]).value = SignType.Cross;

        var chainLenght = cells.GetLongestChain(world,new Vector2Int(0, 1));


        Assert.AreEqual(3, chainLenght);
    }

    [Test]
    public void CheckFirstDiagonalChainThree()
    {
        var world = new EcsWorld();

        var cells = CreateTestCells(world);

        var takenPool = world.GetPool<Taken>();
        takenPool.Add(cells[new Vector2Int(2, 2)]).value = SignType.Cross;
        takenPool.Add(cells[new Vector2Int(1, 1)]).value = SignType.Cross;
        takenPool.Add(cells[new Vector2Int(0, 0)]).value = SignType.Cross;

        var chainLenght = cells.GetLongestChain(world,new Vector2Int(1, 1));


        Assert.AreEqual(3, chainLenght);
    }

    [Test]
    public void CheckSecondDiagonalChainThreeOne()
    {
        var world = new EcsWorld();

        var cells = CreateTestCells(world);
        var takenPool = world.GetPool<Taken>();
        takenPool.Add(cells[new Vector2Int(2, 0)]).value = SignType.Cross;
        takenPool.Add(cells[new Vector2Int(1, 1)]).value = SignType.Cross;
        takenPool.Add(cells[new Vector2Int(0, 2)]).value = SignType.Cross;

        var chainLenght = cells.GetLongestChain(world,new Vector2Int(1, 1));


        Assert.AreEqual(3, chainLenght);
    }

    private static Dictionary<Vector2Int, int> CreateTestCells(EcsWorld world)
    {
        return new Dictionary<Vector2Int, int>
        {
            {new Vector2Int(0, 0), CreateCell(world, new Vector2Int(0, 0))},
            {new Vector2Int(0, 1), CreateCell(world, new Vector2Int(0, 1))},
            {new Vector2Int(0, 2), CreateCell(world, new Vector2Int(0, 2))},
            {new Vector2Int(1, 0), CreateCell(world, new Vector2Int(1, 0))},
            {new Vector2Int(1, 1), CreateCell(world, new Vector2Int(1, 1))},
            {new Vector2Int(1, 2), CreateCell(world, new Vector2Int(1, 2))},
            {new Vector2Int(2, 0), CreateCell(world, new Vector2Int(2, 0))},
            {new Vector2Int(2, 1), CreateCell(world, new Vector2Int(2, 1))},
            {new Vector2Int(2, 2), CreateCell(world, new Vector2Int(2, 2))}
        };
    }

    private static int CreateCell(EcsWorld world, Vector2Int position)
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