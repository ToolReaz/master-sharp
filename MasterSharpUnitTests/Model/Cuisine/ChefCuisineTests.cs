using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Cuisine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Cuisine.Tests
{
    [TestClass()]
    public class ChefCuisineTests
    {
        private Recette recette;
        [TestMethod()]
        public void Dispatch(Recette recette)
        {
            Assert.Equals(recette.Etapes[2].ActionName, "CUT"); //normally just
            Assert.Equals(recette.Etapes[2].ActionName, "FIND"); //normally fail because the action is to cut
        }
    }
}