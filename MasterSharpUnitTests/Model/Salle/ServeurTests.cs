using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSharpUnitTests.Model.Salle
{
    [TestClass()]
    class ServeurTests
    {
        List<Recette> Recette = new List<Recette>();
        
        //[TestMethod()]
        public ServeurTests()
        {
            Assert.Fail();
        }
        
       
        public void ServeClient()
        {
           // Recette.Add("Salade", "Boeuf Bourgignon", "Mousse chocolat");
        }

        public void RideOff()
        {
            Recette.RemoveAt(1);
            Assert.Equals(Recette, 0);

        }

        public void BringFood()
        {

        }
    }
}
