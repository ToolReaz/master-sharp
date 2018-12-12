using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MasterSharp.Model.EDM;

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

        public static void Textil_Stock()
        {
            using (MasterSharpEntities db = new MasterSharpEntities())
            {
                var dbctx = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)db).ObjectContext;
                dbctx.ExecuteStoreCommand("DELETE FROM Textil_Stock");
                var textils = db.Textils;
                List<Textil_Stock> textilStock = new List<Textil_Stock>();
                int quantity;

                foreach (var t in textils)
                {
                    if (t.Name == "Serviette en tissu")
                    {
                        quantity = 150;
                    }
                    else if (t.Name == "Nappe")
                    {
                        quantity = 40;
                    }
                    else
                    {
                        quantity = 150;
                    }
                    textilStock.Add(new Textil_Stock { Quantity = quantity, Clean = true, ID_Stocks = 1, ID_Textils = t.ID });
                }
                db.Textil_Stock.AddRange(textilStock);
                db.SaveChanges();
            }
        }

        public static void Utensil_Stock()
        {
            Utensil_Stock utensilNotClean;
            List<Utensil> utensils;
            int quantityNotClean;
            using (MasterSharpEntities db = new MasterSharpEntities())
            {
                utensils = db.Utensils.ToList();
            }

            foreach (var u in utensils)
            {
                using (MasterSharpEntities db = new MasterSharpEntities())
                {
                    utensilNotClean = db.Utensil_Stock.SingleOrDefault(g => g.ID_Utensils == u.ID && g.Clean == false);
                    if (utensilNotClean != null)
                    {
                        quantityNotClean = utensilNotClean.Quantity;
                        db.Utensil_Stock.Remove(utensilNotClean);
                        db.SaveChanges();
                        UpdateCleanQuantity(u.ID,quantityNotClean);
                    }
                }
            }
        }

        public static void UpdateCleanQuantity(int ID, int quantity)
        {
            using (MasterSharpEntities db = new MasterSharpEntities())
            {
                var utensil = (from e in db.Utensil_Stock
                               where e.ID_Utensils == ID && e.Clean == true
                               select e).Single();
                utensil.Quantity = utensil.Quantity + quantity;
                db.SaveChanges();
            }
        }
    }
}
