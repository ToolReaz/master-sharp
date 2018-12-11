using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Stock.Tests
{
    [TestClass()]
    public class UstencilTests
    {
        private Ustencil ustencilTest;

        [TestMethod()]
        public void UstencilTest() {
            ustencilTest = new Ustencil("Fouet", "Petit", true);
            Assert.AreEqual("Fouet", ustencilTest.Name);
            Assert.AreEqual("Petit", ustencilTest.Size);
            Assert.AreEqual(true, ustencilTest.Clean);
        }

        [TestMethod()]
        public void UseTest() {
            ustencilTest.Use();
            Assert.AreEqual(false, ustencilTest.Clean);
        }

        [TestMethod()]
        public void WashTest() {
            ustencilTest.Wash();
            Assert.AreEqual(true, ustencilTest.Clean);
        }
    }
}