using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSharpUnitTests.Model.Salle
{
    [TestClass()]
    class SalleTests
    {
        List<Carre> Carre = new List<Carre>();

        [TestMethod()]
        public SalleTests()
        {
            Carre.add(2);
            Assert.Equals(Carre, 2);
            //Assert.Fail();
        }
    }
}
