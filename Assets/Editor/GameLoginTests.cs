using System.Collections.Generic;
using Components;
using Leopotam.Ecs;
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

        var chainLenght = cells.GetLongestChain(Vector2Int.zero);

        Assert.AreEqual(0, chainLenght);
    }

    [Test]
    public void CheckHorizontalChainOne()
    {
        var world = new EcsWorld();


        var cells = CreateTestCells(world);

        cells[Vector2Int.zero].Get<Taken>().value = SignType.Cross;

        var chainLenght = cells.GetLongestChain(Vector2Int.zero);

        Assert.AreEqual(1, chainLenght);
    }

    [Test]
    public void CheckHorizontalChainTwoLeft()
    {
        var world = new EcsWorld();


        var cells = CreateTestCells(world);


        cells[new Vector2Int(2, 0)].Get<Taken>().value = SignType.Cross;
        cells[new Vector2Int(1, 0)].Get<Taken>().value = SignType.Cross;

        var chainLenght = cells.GetLongestChain(new Vector2Int(2, 0));


        Assert.AreEqual(2, chainLenght);
    }

    [Test]
    public void CheckHorizontalChainTwoRight()
    {
        var world = new EcsWorld();

        var cells = CreateTestCells(world);

        cells[new Vector2Int(2, 0)].Get<Taken>().value = SignType.Cross;
        cells[new Vector2Int(1, 0)].Get<Taken>().value = SignType.Cross;

        var chainLenght = cells.GetLongestChain(new Vector2Int(1, 0));


        Assert.AreEqual(2, chainLenght);
    }
    
    [Test]
    public void CheckVerticalChainThree()
    {
        var world = new EcsWorld();

        var cells = CreateTestCells(world);

        cells[new Vector2Int(0, 2)].Get<Taken>().value = SignType.Cross;
        cells[new Vector2Int(0, 1)].Get<Taken>().value = SignType.Cross;
        cells[new Vector2Int(0, 0)].Get<Taken>().value = SignType.Cross;

        var chainLenght = cells.GetLongestChain(new Vector2Int(0, 1));


        Assert.AreEqual(3, chainLenght);
    }
    
    [Test]
    public void CheckFirstDiagonalChainThree()
    {
        var world = new EcsWorld();

        var cells = CreateTestCells(world);

        cells[new Vector2Int(2, 2)].Get<Taken>().value = SignType.Cross;
        cells[new Vector2Int(1, 1)].Get<Taken>().value = SignType.Cross;
        cells[new Vector2Int(0, 0)].Get<Taken>().value = SignType.Cross;

        var chainLenght = cells.GetLongestChain(new Vector2Int(1, 1));


        Assert.AreEqual(3, chainLenght);
    }
    
    [Test]
    public void CheckSecondDiagonalChainThreeOne()
    {
        var world = new EcsWorld();

        var cells = CreateTestCells(world);

        cells[new Vector2Int(2, 0)].Get<Taken>().value = SignType.Cross;
        cells[new Vector2Int(1, 1)].Get<Taken>().value = SignType.Cross;
        cells[new Vector2Int(0, 2)].Get<Taken>().value = SignType.Cross;

        var chainLenght = cells.GetLongestChain(new Vector2Int(1, 1));


        Assert.AreEqual(3, chainLenght);
    }

    private static Dictionary<Vector2Int, EcsEntity> CreateTestCells(EcsWorld world)
    {
        return new Dictionary<Vector2Int, EcsEntity>
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

    private static EcsEntity CreateCell(EcsWorld world, Vector2Int position)
    {
        var entity = world.NewEntity();
        entity.Get<Position>().Value = position;
        entity.Get<Cell>();

        return entity;
    }
}