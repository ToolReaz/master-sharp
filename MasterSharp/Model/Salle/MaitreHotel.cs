using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MasterSharp.Model.Salle;

namespace Model.Salle
{
    public class MaitreHotel : IEmployeSalle
    {
        private Salle salle;
        private Thread thread;
        private Table table;
        private Carre carre;
        private Restaurant restaurant;
        private GroupeClient client;


        public MaitreHotel(Salle salle)
        {
            this.salle = salle;
            this.thread = new Thread(new ThreadStart(this.DoWork));
            thread.Start();
            
        }

        public void DoWork()
        {
            //on reagarde la queue si il y a quelqu'un on traite puis dequeue
            while (true)
            {
                if(restaurant._queueClient.Count >= 1)
                {
                    for(int i=0; i<=restaurant._queueClient.Count; i++ )
                    {
                        Welcome();
                        //selection de la table + les placer 
                        AssignTable(restaurant.HowManyClient, Restaurant.idGroupe);


                        //puis dequeue
                        restaurant._queueClient.Dequeue();
                    }

                   

                }
            }

           
        }
              
        static void Welcome()
        {
            Console.WriteLine("Un nouveau groupe de client est arrivé.");
        }

        public void AssignTable(int NbClient ,int idGroupe)
        {
          
            switch (NbClient)
            {
                case 1:
                case 2:
                    {
                        int n = 0;
                        if(carre.tables[n].NumeroGroupe == 0)
                        {
                            // carre.tables[0].NumeroGroupe = idGroupe;
                        }


                    }
                    break;


                case 3:
                case 4:
                    {
                        //table.GetTable(4);
                    }
                    break;

                case 5:
                case 6:
                    {
                       // table.GetTable(6);
                    }
                    break;

                case 7:
                case 8:
                    {
                       // table.GetTable(8);
                    }
                    break;

                case 9:
                case 10:
                    {
                        //table.GetTable(10);
                    }
                    break;

                default:
                    {
                        Console.WriteLine("Erreur, aucune table ne peux etre assigné (attendre dans la file)");
                    }
                    break;
            }

        }

    }
}
