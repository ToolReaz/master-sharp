using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Model.Cuisine;
using Model.Salle;


namespace Model
{
    public class Restaurant
    {

        private GroupeClient clients;
        private Thread thread;
        private const int NextClient = 1200000;
        public int HowManyClient;
        private Random randomClient = new Random();
        public Queue<GroupeClient> _queueClient { get; set; }
        private Salle.Salle salle;
        public Carte carte { get; set; }

        //private MaitreHotel maitreHotel;
        public static int idGroupe =1;

        public Restaurant()
        {
            salle = new Salle.Salle(this, new List<Carre>());
            _queueClient = new Queue<GroupeClient>();

            //a modifier si necessaire
            //maitreHotel = new MaitreHotel(salle);

            this.thread = new Thread(new ThreadStart(this.ClientArrived));
            thread.Start();

        }
        
        public void ClientArrived()
        {
            while (true)
            {
                HowManyClient = randomClient.Next(1, 10);
                clients = new GroupeClient(HowManyClient, idGroupe);
                _queueClient.Enqueue(clients);
                idGroupe++;
                Thread.Sleep(NextClient);

            }
           

        }
    }
}
