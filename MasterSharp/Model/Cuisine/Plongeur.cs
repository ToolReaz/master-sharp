using MasterSharp.Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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


        public void DoWork() {
            while (true) {
                // Si il y a qqc a laver
                // Place dans le lave vaissele le plus possible
                // Uniquement 24 de chaque type (24 assietes, 24 verres, 24 couverts)


                // Check if there is dirty vaisselle
                // Dirty vaisselle contained in the stock
                List<IStockItem> DirtyVaisselle = cuisine.StockVaisselle.GetDirtyItems();

                // Add dirty vaisselle to the LaveVaisselle's queue
                if (DirtyVaisselle?.Count > 0) {
                    DirtyVaisselle.ForEach(
                        item => {
                            if (item.GetType() == typeof(Assiette)) {
                                laveVaisselle.AddAssiete(item);
                            } else if (item.GetType() == typeof(Verre)) {
                                laveVaisselle.AddVerre(item);
                            } else if (item.GetType() == typeof(Couverts)) {
                                laveVaisselle.AddCouvert(item);
                            }
                        });
                }







                // Dirty textile contained in the stock
                List<IStockItem> DirtyTextille = cuisine.StockTextille.GetDirtyItems();

                // Add dirty textile to the LaveLinge's queue
                if (DirtyTextille?.Count > 0) {
                    DirtyTextille.ForEach(
                        item => {
                            laveLinge.Queue(item);
                        });
                }


                // Wash dirty ustencil
            }
        }

        public void Wash() { }
    }
}
