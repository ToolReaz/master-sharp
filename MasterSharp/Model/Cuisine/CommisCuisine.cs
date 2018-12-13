using MasterSharp.Model.Stock;
using Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MasterSharp.Model.EDM;

namespace Model.Cuisine
{
    /*
     * Action: Couper, eplucher, trouver l'aliment
     */
    public class CommisCuisine
    {
        public Queue<Aliment> ToFindAliments { get; }
        public Queue<Aliment> ToCutAliments { get; }

        private Thread _thread;

        public CommisCuisine() {
            this.ToFindAliments = new Queue<Aliment>();
            this.ToCutAliments = new Queue<Aliment>();

            this._thread = new Thread(
                new ThreadStart(
                    () => {
                        while (true) {
                            if (ToFindAliments.Count > 0) {
                                // The stock is already updated by the controller
                                // So we just wait 30s to simulate the time taken by the commis to get the food
                                Thread.Sleep(30000);
                            } else if (ToCutAliments.Count > 0) {
                                // Request DB
                                Utensil_Stock ustensil;
                                do {
                                    // Try to get a clean cut
                                    using (MasterSharpEntities db = new MasterSharpEntities()) {
                                        ustensil = (
                                            from u in db.Utensil_Stock
                                            where u.Utensil.Name == "Couteau de cuisine" && u.Clean == true
                                            select u).FirstOrDefault();
                                    }

                                    // Time to cut (this time is also used to not spam connections if any cut where found)
                                    Thread.Sleep(30000);

                                    // Do it until a clean cut is available
                                } while (ustensil == null);

                                // If a cut where found use it (the cut become dirty)
                                using (MasterSharpEntities db = new MasterSharpEntities()) {
                                    var tmp = (
                                        from u in db.Utensil_Stock
                                        where u.Utensil.ID == ustensil.ID_Utensils
                                        select u).FirstOrDefault();

                                    tmp.Clean = false;
                                    db.SaveChanges();
                                }
                            }
                        }

                        // Sleep to prevent high usage of processor
                        Thread.Sleep(2000);
                    }));
            _thread.Start();
        }

        public void Cut(Aliment a) {
            this.ToCutAliments.Enqueue(a);
        }

        public void Find(Aliment a) {
            this.ToFindAliments.Enqueue(a);
        }
    }
}
