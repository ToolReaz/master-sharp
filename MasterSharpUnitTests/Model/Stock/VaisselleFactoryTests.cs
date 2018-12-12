using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Stock.Tests
{
    [TestClass()]
    public class VaisselleFactoryTests
    {
        private IVaisselle vaisselleTest;

        [TestMethod()]
        public void CreateAssietteTest()
        {
            Assert.AreSame(new Assiette(TypeAssiette.CREUSE), VaisselleFactory.CreateAssiette(TypeAssiette.CREUSE));
        }

        [TestMethod()]
        public void CreateVerreTest()
        {
            Assert.AreSame(new Verre(TypeVerres.EAU), VaisselleFactory.CreateVerre(TypeVerres.EAU));
        }

        [TestMethod()]
        public void CreateCouvertTest()
        {
            Assert.AreSame(new Couverts(TypeCouverts.COUTEAUX), VaisselleFactory.CreateCouvert(TypeCouverts.COUTEAUX));
        }
    }
}