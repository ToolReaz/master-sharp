using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasterSharp.Model.Salle;
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
        List<Rang> Rang = new List<Rang>();

        [TestMethod()]
        public void CarreTest()
        {
            Rang.Add(new Rang(), new Rang());
            Assert.Equals(Rang, 2);
            //Assert.Fail();
        }
    }
}