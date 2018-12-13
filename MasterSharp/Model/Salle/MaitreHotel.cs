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
        //private GroupeClient client;
        private Queue<GroupeClient> _queueAttenteClient { get; set; }

        public MaitreHotel(Restaurant _restaurant, Salle _salle)
        {
            this.salle = _salle;
            this.restaurant = _restaurant;
            _queueAttenteClient = new Queue<GroupeClient>();

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
            int n = 0;
            int i = 0;
            
            // select the first occurence where a table is not assign and the number of client is under minimal size of table 
            var query = (from e in carre.tables orderby e.Place where e.NumeroGroupe == 0 && e.Place > NbClient select e).FirstOrDefault();


            if (query != null)
            {
                query.NumeroGroupe = idGroupe;
            }
            else
            {
                _queueAttenteClient = restaurant._queueClient;

                //need to implement after when a client quit the table
                TableFree();

            }

        }

        public void TableFree()
        {

        }

    }
}
