﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            ((List<Client>)new List<Client>()).Add(new Client(TypeClient.BUSY));
            Assert.Equals(new List<Client>(), 1);
        //Assert.Fail();
        }
    }
}