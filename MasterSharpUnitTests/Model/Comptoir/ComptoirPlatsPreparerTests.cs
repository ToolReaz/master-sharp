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
        int NbPlatsSalle;

        List<ComptoirPlatsPreparer> Comptoir = new List<ComptoirPlatsPreparer>();

        [TestMethod()]
        public void AddElement(int NbPlatsSalle)
        {
            for (int i =0; i<= NbPlatsSalle; i++)
            {
                Comptoir.Add(new ComptoirPlatsPreparer());
            }
           
            Assert.Equals(NbPlatsSalle, Comptoir.Count);
        }

        [TestMethod()]
        public  void RemoveElement(int NbRemoveElement)
        {
            for (int i = 0; i <= NbRemoveElement; i++)
            {
                NbPlatsSalle -= 1;
                Comptoir.RemoveAt(1);
            }
            Assert.Equals(NbRemoveElement, Comptoir.Count);

        }
    }
}
