using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
  using NUnit.Framework;
  
  [TestFixture]
  public class testFail
  {
    [Test]
    public void testFailure(){
      Assert.Ignore();
    }
  }
}
