using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        List<ComptoirPlatPreparer> Comptoir = new List<ComptoirPlatPreparer>();

        [TestMethod()]
        public AddElement()
        {
            Comptoir.Add(new ComptoirPlatPreparer(), new ComptoirPlatPreparer());
            Assert.Equals(Comptoir, 2);
        }

        [TestMethod()]
        public RemoveElement()
        {
            Comptoir.RemoveAll();
            Assert.Equals(Comptoir, 0);
        }
    }
}
