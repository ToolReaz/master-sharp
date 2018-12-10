using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.EDM;

namespace Controller
{
    public class MenuOfTheDay
    {
        public Recipe ofTheDay(string Recipe_Category)
        {
            using (MasterSharpEntities db = new MasterSharpEntities())
            {
                var recipes = (from f in db.Recipes
                               where f.Recipe_Categories.Name == Recipe_Category
                               select new
                               {
                                   f.ID,
                                   f.Name
                               }).ToList();
                List<int> recipesID = new List<int>();
                foreach (var s in recipes)
                {
                    recipesID.Add(s.ID);
                }
                Random rnd = new Random();
                int recipeID = recipesID[rnd.Next(recipesID.Count)];
                var recipeOfTheDay = db.Recipes.Find(recipeID);

                return recipeOfTheDay;
            }
        }

    }
}
