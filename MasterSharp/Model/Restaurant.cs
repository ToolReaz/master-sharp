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
        
        public Restaurant()
        {
            this.thread = new Thread(new ThreadStart(this.ClientArrived));

        }
        
        public void ClientArrived()
        {
            while (true)
            {
                int NextClient = 1200000;
                Random randomClient = new Random();
                int HowManyClient = randomClient.Next(1, 10);
                client = new GroupeClient(HowManyClient);
                Thread.Sleep(NextClient);
            }
           

        }
    }
}
