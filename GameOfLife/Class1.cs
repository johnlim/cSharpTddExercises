using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
  public class World
  {
    public World() { setOfLiveCells = new SortedSet<Cell>(); }
    public void giveCellLife(Cell cell) { setOfLiveCells.Add(cell); }
    public bool isCellAlive(Cell cell) { return setOfLiveCells.Contains(cell); }
    private SortedSet<Cell> setOfLiveCells;
  }

  public class Cell : IComparable<Cell>
  {
    public Cell(int x, int y) { xCoordinate = x; yCoordinate = y; }
    public int CompareTo(Cell cell)
    {
      if (xCoordinate < cell.xCoordinate) return -1;
      if (xCoordinate > cell.xCoordinate) return 1;
      if (xCoordinate == cell.xCoordinate && yCoordinate == cell.yCoordinate) return 0;
      if (yCoordinate < cell.yCoordinate) return -1;
      else return 1;
    }
    private int xCoordinate;
    private int yCoordinate;
  }
}



namespace ClassLibrary1
{
  using NUnit.Framework;
  using GameOfLife;


  [TestFixture]
  public class Class1
  {
    [Test]
    public void testWorldGivesCellLife()
    {
      World world = new World();
      Cell cell = new Cell(0, 1);
      world.giveCellLife(cell);
      Assert.IsTrue(world.isCellAlive(cell));
    }
    [Test]
    public void testWorldGivesAnotherCellLife()
    {
      Cell cell = new Cell(0, 0);
      Cell anotherCell = new Cell(1, 0);
      World world = new World();

      world.giveCellLife(anotherCell);
      Assert.IsFalse(world.isCellAlive(cell));
      Assert.IsTrue(world.isCellAlive(anotherCell));

    }
  }
}
