using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Cuisine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model.Cuisine.Tests
{
    [TestClass()]
    public class LaveVaisselleTests
    {
        private Thread _thread;

        public LaveVaisselleTests()
        {
            if (_thread == null)
            {
                Assert.Fail();
            }
        }
        [TestMethod()]
        public void IsCleanTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void Queue()
        {
            Assert.Fail();
        }

    }
}