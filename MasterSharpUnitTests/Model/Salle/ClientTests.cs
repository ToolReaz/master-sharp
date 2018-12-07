using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public ClientTests()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public OrderMEal()
        {
            List<Recette> Meal = new List<Recette>();
            Meal.Add("Boeuf Bourgignon", "Lasagne");
            Assert.Equal(Meal, "Test");
        }

        [TestMethod()]
        public PayBill()
        {
            int Bill = 20;
            Assert.Equal(Bill, 0);

        }
    }
}
