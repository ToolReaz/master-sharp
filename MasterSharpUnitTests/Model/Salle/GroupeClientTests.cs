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
    public class GroupeClientTests
    {


        [TestMethod()]
        public void GroupeClientTest(List<Client> Groupe)
        {
            List<Client> Groupe = new List<Client>();
            Groupe.Add(new Client(), new Client());
            Assert.Equals(Groupe, 2);
        //Assert.Fail();
        }
    }
}