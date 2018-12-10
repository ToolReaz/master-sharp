using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSharp.Model.Salle.Tests
{
    [TestClass()]
    public class CarreTests
    {
        List<Table> Table;

        [TestMethod()]
        public void CarreTest(int NbTable)
        {
            Assert.Equals(NbTable, Table.Count);
        }
    }
}