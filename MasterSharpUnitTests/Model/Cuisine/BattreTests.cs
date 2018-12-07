using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Cuisine;
using Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Cuisine.Tests
{
    [TestClass()]
    public class BattreTests
    {
        [TestMethod()]
        public void DoActionTest()
        {
            Ustencil ObjUstencil = new Ustencil();
            Assert.Equals(ObjUstencil, ObjUstencil);
        }
    }
}