using MasterSharp.Model.Stock;
using Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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
            ToFindAliments = new Queue<Aliment>();
            ToCutAliments = new Queue<Aliment>();

            _thread = new Thread(
                new ThreadStart(
                    () => {
                        while (true) {
                            if (ToFindAliments.Count > 0) {
                                // Go find aliment in stock
                                
                            } else if (ToCutAliments.Count > 0) {
                                // Cut the aliment
                            }

                            // Sleep to prevent high usage of processor
                            Thread.Sleep(2);
                        }
                    }));
        }

        public void Cut(Aliment a) {
            ToCutAliments.Enqueue(a);
        }

        public void Find(Aliment a) {
            ToFindAliments.Enqueue(a);
        }
    }
}
