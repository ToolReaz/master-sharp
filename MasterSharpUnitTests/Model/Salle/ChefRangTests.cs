using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Salle;
using Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Salle.Tests

{
    [TestClass()]
    public class ChefRangTests
    {
        //Carte MenuTable = new Carte(List<Recette>);

        int NbCarteDonner;
        public Carte carte;

    [TestMethod()]
        public void DoWork()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GiveMenu(int NbCarteDonner)
        {
            if(NbCarteDonner == 0)
            {
                Assert.Fail();
            }
            carte.GiveCard(0);
        }

        [TestMethod()]
        public void TakeCommand()
        {
            Assert.Fail();
        }


    }
}
