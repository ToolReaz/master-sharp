using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSharpUnitTests.Model.Salle
{
    [TestClass()]
    class TableTests
    {
        int GroupeClient = 1;
        Table TableClient = new Table(1);

        //[TestMethod()]
        public TableTests()
        {
            //TableClient.add();
            Assert.Equals(TableClient, 1);
            //Assert.Fail();
        }
    }
}
