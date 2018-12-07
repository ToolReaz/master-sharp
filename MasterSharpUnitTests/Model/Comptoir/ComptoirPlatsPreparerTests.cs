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
    class ComptoirPlatsPreparerTests
    {
        List<ComptoirPlatsPreparer> Comptoir = new List<ComptoirPlatsPreparer>();

        [TestMethod()]
        public void AddElement()
        {
            Comptoir.Add(new ComptoirPlatsPreparer());
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
