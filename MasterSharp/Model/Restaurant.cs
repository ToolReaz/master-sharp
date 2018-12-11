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

        private GroupeClient client;
        private Thread thread;
        private const int NextClient = 1200000;
        private Random randomClient = new Random();
        public Queue<GroupeClient> _queueClient { get; set; }

        private MaitreHotel maitreHotel;
        public Restaurant()
        {
            this.thread = new Thread(new ThreadStart(this.ClientArrived));

        }
        
        public void ClientArrived()
        {
            while (true)
            {
                int HowManyClient = randomClient.Next(1, 10);
                client = new GroupeClient(HowManyClient);
                _queueClient.Enqueue(client);
                Thread.Sleep(NextClient);

            }
           

        }
    }
}
