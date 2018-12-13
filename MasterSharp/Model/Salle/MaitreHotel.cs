using System;
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
        private Restaurant restaurant;
        //private GroupeClient client;

        public MaitreHotel(Restaurant _restaurant, Salle _salle)
        {
            this.salle = _salle;
            this.restaurant = _restaurant;
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
                        AssignTable();


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

        public void AssignTable()
        {   
            table.CheckTable(restaurant.HowManyClient);
        }
        
    }
}
