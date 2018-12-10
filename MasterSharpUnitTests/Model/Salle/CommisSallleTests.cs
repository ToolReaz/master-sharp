using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSharpUnitTests.Model.Salle
{
    [TestClass()]
    class CommisSallleTests
    {
        public int  Water = 40;
        public int Bread = 40;

        [TestMethod()]
        public void DoWork()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ServeWaterBread(int NbWater, int NbBread)
        {
            if(NbWater == 0 ||NbBread == 0 || Bread == 0 || Water== 0)
            {
                Assert.Fail();
            }
            Water -= NbWater;
            Bread -= NbBread;
            
        }
    }
}
