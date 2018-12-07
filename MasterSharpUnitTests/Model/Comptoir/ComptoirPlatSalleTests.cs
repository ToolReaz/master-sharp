using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public AddElement()
        {
            Comptoir.Add(new ComptoirPlatSalle(), new ComptoirPlatSalle());
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
