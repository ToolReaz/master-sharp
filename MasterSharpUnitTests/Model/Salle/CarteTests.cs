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
    class CarteTests
    {
        List<Recette> Carte;
        int NbCarte = 40;
        int NbCarteDonner;

        [TestMethod()]
        public void GiveCard(int NbCarteDonner)
        {
              if(NbCarte == 0|| NbCarteDonner == 0)
            {
                Assert.Fail();
            } 
              
        }
    }
}
