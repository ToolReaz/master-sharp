using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterSharp.Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSharp.Model.Stock.Tests
{
    [TestClass()]
    public class AlimentTests
    {
        private Aliment Aliment { get; set; }

        [TestMethod()]
        public void AlimentTest()
        {
            Aliment = new Aliment(TypeAliment.SEC);
            Assert.Fail();
        }

        [TestMethod()]
        public void IsFreshTest()
        {
            Assert.Equals(Aliment.IsFresh(), true);
        }
    }
}