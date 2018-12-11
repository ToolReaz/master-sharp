﻿using System;
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
        private Salle.Salle salle;

        private MaitreHotel maitreHotel;

        public Restaurant(Salle.Salle salle)
        {
            salle = new Salle.Salle(new List<Carre>());

            //a modifier si necessaire
            maitreHotel = new MaitreHotel(salle);

            this.thread = new Thread(new ThreadStart(this.ClientArrived));
            thread.Start();

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
