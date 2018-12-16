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
        private Carre Carre;
        private Thread thread;
        private Table table;
        
        //private GroupeClient client;
        private Queue<GroupeClient> _queueAttenteClient { get; set; }

        public MaitreHotel(Salle _salle)
        {
            //Console.WriteLine("Maitre hotel intancié > ");
            salle = _salle;
            Carre = salle.Carre;

            _queueAttenteClient = new Queue<GroupeClient>();
            this.thread = new Thread(new ThreadStart(this.DoWork));
            thread.Start();
        }

        public void DoWork()
        {
            //on regarde la queue si il y a quelqu'un on traite puis dequeue
            while (true)
            {
                if (salle._queueClient.Count >= 1)
                {
                    for (int i=0; i<= salle._queueClient.Count; i++ )
                    {
                        GroupeClient grpClients = salle._queueClient.Peek();

                        Welcome();
                        //selection de la table + les placer 
                        AssignTable(salle.HowManyClient, grpClients.idGroupe, grpClients);
                                                
                        //puis dequeue
                        salle._queueClient.Dequeue();

                        //ajouter le groupe a la liste des clients en attente (relais vers ChefRang)
                        salle._justArrivedClients.Enqueue(grpClients);
                    }

                }

                Thread.Sleep(3000);
            }

        }
              
        static void Welcome()
        {
            Console.WriteLine("(MaîtreHotel) Bienvenue !");
        }

        public void AssignTable(int NbClient ,int idGroupe, GroupeClient grpClients)
        {
            int n = 0;
            int i = 0;
            
            // select the first occurence where a table is not assign and the number of client is under minimal size of table 
            var query = (from e in Carre.tables orderby e.Place where e.NumeroGroupe == 0 && e.Place > NbClient select e).FirstOrDefault();


            if (query != null)
            {
                query.NumeroGroupe = idGroupe;
                query.grpClients = grpClients;
            }
            else
            {
                _queueAttenteClient = salle._queueClient;

                //need to implement after when a client quit the table
                TableFree();

            }

        }

        public void TableFree()
        {

        }

    }
}
