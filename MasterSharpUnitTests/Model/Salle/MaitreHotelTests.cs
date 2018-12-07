using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Salle.Tests
{
    [TestClass()]
    public class MaitreHotelTests
    {
        List<GroupeClient> GroupeCLient = new List<GroupeClient>();

        [TestMethod()]
        public void DoWorkTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void WelcomeTest()
        {
            GroupeCLient.Add(new GroupeClient(new List<Client>()));
            Assert.Equals(GroupeCLient, 1);
            //Assert.Fail();
        }
    }
}