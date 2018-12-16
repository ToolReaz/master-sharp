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
        private GroupeClient client;

        [TestMethod()]
        public void GroupeClientTest()
        {
            client.GroupeClient(5, 1);
            Assert.Equals(5, client.NbPersonnesGroupe);
            Assert.Equals(1, client.idGroupe);
        }
    }
}