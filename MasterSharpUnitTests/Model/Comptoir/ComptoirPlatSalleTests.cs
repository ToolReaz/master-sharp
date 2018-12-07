using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Comptoir;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSharpUnitTests.Model.Comptoir
{
    [TestClass()]
    class ComptoirPlatSalleTests
    {

        List<ComptoirPlatSalle> Comptoir = new List<ComptoirPlatSalle>();

        [TestMethod()]
        public void AddElement()
        {
            Comptoir.Add(new ComptoirPlatSalle());
            Assert.Equals(Comptoir, 1);
        }

        [TestMethod()]
        public  void RemoveElement()
        {
            Comptoir.RemoveAt(1);
            Assert.Equals(Comptoir, 0);
        }
    }
}
