using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        
        [TestMethod()]
        public ServeurTests()
        {
            Assert.Fail();
        }
        
       
        public ServeClient()
        {
            Recette.Add("Salade", "Boeuf Bourgignon", "Mousse chocolat");
        }

        public RideOff()
        {
            Recette.RemoveAll();
            Assert.Equals(Recette, 0);

        }

        public BringFood()
        {

        }
    }
}
