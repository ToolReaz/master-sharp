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
    public class CommisCuisineTests
    {
       
        private CommisCuisine commis;

       

        [TestMethod()]
        public void CutTest()
        {
            commis.Cut("Carotte");
            Assert.IsNotNull(commis.ToCutAliments);
        }

        [TestMethod()]
        public void FindTest()
        {
            commis.Find("Carotte");
            Assert.IsNotNull(commis.ToFindAliments);
        }
    }
}