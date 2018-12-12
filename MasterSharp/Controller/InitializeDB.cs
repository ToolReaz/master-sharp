using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.EDM;

namespace Controller
{
    public static class InitializeDB
    {
        public static void Food_Stock()
        {
            using (MasterSharpEntities db = new MasterSharpEntities())
            {
                db.DeleteAllFoodStock();
                List<Food_Stock> foodStock = new List<Food_Stock>();
                var foods = db.Foods;
                DateTime now = DateTime.Now;
                DateTime expiryDate;

                foreach (var f in foods)
                {
                    if (f.Food_Types.Name == "Frais")
                    {
                        expiryDate = now.AddDays(2);
                    }
                    else if (f.Food_Types.Name == "Surgelé")
                    {
                        expiryDate = now.AddMonths(1);
                    }
                    else if (f.Food_Types.Name == "Sec")
                    {
                        expiryDate = now.AddYears(1);
                    }
                    else
                    {
                        expiryDate = now;
                    }

                    foodStock.Add(new Food_Stock { Quantity = 1000, Expiry_Date = expiryDate, ID_Foods = f.ID, ID_Stocks = 1 });
                }

                db.Food_Stock.AddRange(foodStock);
                db.SaveChanges();
            }
        }

        public static void Dish_Stock()
        {
            using (MasterSharpEntities db = new MasterSharpEntities())
            {
                var dbctx = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)db).ObjectContext;
                dbctx.ExecuteStoreCommand("DELETE FROM Dish_Stock");
                var dishes = db.Dishes;
                List<Dish_Stock> dishStock = new List<Dish_Stock>();
                int quantity;

                foreach (var d in dishes)
                {
                    if (d.Name == "Assiette creuse")
                    {
                        quantity = 30;
                    }
                    else if (d.Name == "Jeu de tasse et assiette à café")
                    {
                        quantity = 50;
                    }
                    else
                    {
                        quantity = 150;
                    }
                    dishStock.Add(new Dish_Stock { Quantity = quantity, Clean = true, ID_Stocks = 1, ID_Dishes = d.ID });
                }
                db.Dish_Stock.AddRange(dishStock);
                db.SaveChanges();
            }
        }
    }
}
