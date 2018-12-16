using MasterSharp.Model.Stock;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using MasterSharp.Model.EDM;
using Model.Stock;

namespace Model.Cuisine
{
    public class Plongeur
    {
        private Thread thread;

        private Cuisine cuisine;
        private LaveLinge laveLinge;
        private LaveVaisselle laveVaisselle;


        public Plongeur(Cuisine cuisine) {
            this.cuisine = cuisine;
            this.laveLinge = new LaveLinge();
            this.laveVaisselle = new LaveVaisselle();
            this.thread = new Thread(new ThreadStart(this.DoWork));
            thread.Start();
        }


        private void DoWork() {
            while (true) {
                // Wash dishes
                using (MasterSharpEntities db = new MasterSharpEntities()) {
                    var dirtyItemsList = db.Dish_Stock.Where(x => x.Clean == false);

                    int nbrAssiettes = 0;
                    int nbrVerres = 0;
                    int nbrCouvert = 0;


                    if (dirtyItemsList != null) {
                        foreach (var d in dirtyItemsList) {
                            // If assiette
                            if (Regex.IsMatch(d.Dish.Name.ToString(), @"/Assiette.*/g")) {
                                if (d.Quantity < 24 - nbrAssiettes) {
                                    this.laveVaisselle.AddAssiete(d.ID_Dishes, d.Quantity);
                                    nbrAssiettes += d.Quantity;
                                }
                            }
                            // If verre
                            else if (d.Dish.Name == "Verre à eau" ||
                                     d.Dish.Name == "Verre à vin" ||
                                     d.Dish.Name == "Flûte à champagne" ||
                                     d.Dish.Name == "Jeu de tasse et assiette à café") {
                                if (d.Quantity < 24 - nbrVerres) {
                                    this.laveVaisselle.AddVerre(d.ID_Dishes, d.Quantity);
                                    nbrVerres += d.Quantity;
                                }
                                // If couvert
                                else if (d.Dish.Name == "Fourchette" ||
                                         d.Dish.Name == "Couteau" ||
                                         d.Dish.Name == "Cuillère à soupe" ||
                                         d.Dish.Name == "Cuillère à café") {
                                    if (d.Quantity < 24 - nbrCouvert) {
                                        this.laveVaisselle.AddCouvert(d.ID_Dishes, d.Quantity);
                                        nbrCouvert += d.Quantity;
                                    }
                                }
                            }
                        }

                    }
                }

                // Wash ustencil
                using (MasterSharpEntities db = new MasterSharpEntities()) {
                    var dirtyUstencilList = db.Utensil_Stock.Where(x => x.Clean == false);

                    foreach (var item in dirtyUstencilList) {
                        item.Clean = true;
                    }

                    db.SaveChanges();
                }

                // Sleep to avoid high CPU usage
                    Thread.Sleep(2000);
            }
        }
    }
}
