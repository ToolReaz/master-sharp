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
    public class SalleTests
    {
        private GroupeClient client;
        private Queue<GroupeClient> _queueClient;

       [TestMethod()]
        public void ClientArrivedTest()
        {
            client = new GroupeClient(3,2);
            _queueClient.Enqueue(clients);
            Assert.IsNotNull(_queueClient);
        }
    }
}
