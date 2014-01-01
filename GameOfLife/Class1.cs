using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Rules
//Any live cell with fewer than two live neighbours dies, as if caused by under-population.
//Any live cell with two or three live neighbours lives on to the next generation.
//Any live cell with more than three live neighbours dies, as if by overcrowding.
//Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

namespace GameOfLife
{
  public class World
  {
    public World() { setOfLiveCells = new SortedSet<Cell>(); }
    public void giveCellLife(Cell cell) { setOfLiveCells.Add(cell); }
    public bool isCellAlive(Cell cell) { return setOfLiveCells.Contains(cell); }
    public World tick(){return (new World());}
    private SortedSet<Cell> setOfLiveCells;
  }

  public class Cell : IComparable<Cell>
  {
    public Cell(int x, int y) { xCoordinate = x; yCoordinate = y;}
    public int CompareTo(Cell cell)
    {
      if (xCoordinate < cell.xCoordinate) return -1;
      if (xCoordinate > cell.xCoordinate) return 1;
      if (xCoordinate == cell.xCoordinate && yCoordinate == cell.yCoordinate) return 0;
      if (yCoordinate < cell.yCoordinate) return -1;
      else return 1;
    }
    public List<Cell> getNeighbours(){
      listOfNeighbours = new List<Cell>();
      listOfNeighbours.Add(new Cell(xCoordinate + 1, yCoordinate));
      listOfNeighbours.Add(new Cell(xCoordinate, yCoordinate + 1));
      listOfNeighbours.Add(new Cell(xCoordinate + 1, yCoordinate + 1));
      listOfNeighbours.Add(new Cell(xCoordinate - 1, yCoordinate));
      listOfNeighbours.Add(new Cell(xCoordinate, yCoordinate - 1));
      listOfNeighbours.Add(new Cell(xCoordinate - 1, yCoordinate - 1));
      listOfNeighbours.Add(new Cell(xCoordinate + 1, yCoordinate - 1));
      listOfNeighbours.Add(new Cell(xCoordinate - 1, yCoordinate + 1));
      return listOfNeighbours;
    }
    private int xCoordinate;
    private int yCoordinate;
    private List<Cell> listOfNeighbours;
  }
}



namespace ClassLibrary1
{
  using NUnit.Framework;
  using GameOfLife;


  [TestFixture]
  public class Class1
  {
    World world;
    [SetUp]
    public void testFixtureSetUp()
    {
      world = new World();
    }   
    [Test]
    public void testWorldGivesCellLife()
    {
      Cell cell = new Cell(0, 1);
      world.giveCellLife(cell);
      Assert.IsTrue(world.isCellAlive(cell));
    }
    [Test]
    public void testWorldGivesAnotherCellLife()
    {
      Cell cell = new Cell(0, 0);
      Cell anotherCell = new Cell(1, 0);
      
      world.giveCellLife(anotherCell);
      Assert.IsFalse(world.isCellAlive(cell));
      Assert.IsTrue(world.isCellAlive(anotherCell));
    }

    [Test]
    public void testCellKnowsItsNeighbours()
    {
      Cell cell = new Cell(0,0);
      Cell neighbour = new Cell(1,0);
      List<Cell> listOfNeighbours = cell.getNeighbours();
      Assert.AreEqual(0, cell.getNeighbours()[0].CompareTo(neighbour));
    }

    [Test]
    public void testCellWithLessThanTwoLiveNeighboutsDiesOnNextTick()
    {
      Cell cell = new Cell(0,0);
      Cell neighbour = new Cell(0,1);
      Cell anotherNeighbour = new Cell(1,0);
      
      world.giveCellLife(cell);
      Assert.IsFalse(world.tick().isCellAlive(cell));
    }

    [Test]
    [Ignore("need to implement method to determine number of live neighbours")]
    public void testCellWithTwoLiveNeighboursLiveOnNextTick()
    {
      Cell cell = new Cell(0,0);
      Cell neighbour = new Cell(0,1);
      Cell anotherNeighbour = new Cell(1,0);
      world.giveCellLife(cell);
      world.giveCellLife(neighbour);
      world.giveCellLife(anotherNeighbour);
      Assert.IsTrue(world.tick().isCellAlive(cell)); 
    }
  }
}
