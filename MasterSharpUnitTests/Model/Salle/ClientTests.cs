﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSharpUnitTests.Model.Salle
{
    [TestClass()]
    class ClientTests
    {

        [TestMethod()]
        public void OrderMEal()
        {
            List<Recette> Meal = new List<Recette>();
            Meal.Add(new Recette());
            Assert.Equals(Meal, 1);
        }

        [TestMethod()]
        public void PayBill()
        {
            int Bill = 20;
            Assert.Equals(Bill, 0);

        }
    }
}
