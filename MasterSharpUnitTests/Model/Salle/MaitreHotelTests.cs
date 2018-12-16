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
        private Salle salle;
        private GroupeClient client;
        private MaitreHotel maitre;

        [TestMethod()]
        public void DoWorkTest()
        {
            salle._queueClient.Enqueue(client = new GroupeClient(4,2));
            Assert.IsNotNull(salle._queueClient);
            salle._queueClient.Dequeue();
            Assert.IsNull(salle._queueClient);


        }

        [TestMethod()]
        public void WelcomeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AssignTableTest()
        {
            maitre.AssignTable(5, 3);
            Assert.Equals(5, client.NbPersonnesGroupe);
            Assert.Equals(3, client.idGroupe);
        }
    }
}