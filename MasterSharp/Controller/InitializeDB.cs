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
    }
}
