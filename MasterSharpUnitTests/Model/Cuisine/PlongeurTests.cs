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
    public class PlongeurTests
    {
        private Cuisine cuisine;

        [TestMethod()]
        public void DoWorkTest()
        {
            List<IStockItem> DirtyVaisselle = cuisine.StockVaisselle.GetDirtyItems();
            List<IStockItem> DirtyTextille = cuisine.StockTextille.GetDirtyItems();

            if (DirtyVaisselle.Count < 0 || DirtyTextille.Count < 0)
            {
                Assert.Fail();
            }

        }
    }
}