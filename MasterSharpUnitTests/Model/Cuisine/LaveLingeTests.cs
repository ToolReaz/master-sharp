using MasterSharp.Model.Stock;
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
    public class LaveLingeTests
    {
        private Queue<ITextille> _queue;
        private Thread thread;
        private LaveLinge lave;

        public LaveLingeTests()
        {
            if(thread == null)
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
        public void QueueTest()
        {
            //_queue.Enqueue();
            Assert.IsNotNull(_queue);
        }
    }
}