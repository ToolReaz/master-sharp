using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MasterSharp.Model.Salle;
using Model.Stock;

namespace Model.Salle
{
    public class Salle
    {
        public Carre Carre { get; set; }

        //Employees
        private MaitreHotel maitreHotel;
        private ChefRang chefRang;
        private CommisSallle commisSallle;
        private Serveur serveur;
        //Recips commands 
        public Carte carte { get; set; }
        private List<Recette> recettes;
        //Reception
        private GroupeClient clients;
        private Thread thread;
        private const int NextClient = 1200000;
        private Random randomClient = new Random();
        public int HowManyClient { get; private set; }
        public Queue<GroupeClient> _queueClient { get; set; }
        public static int idGroupe = 1;
        public bool newClient { get; set; }



        public Salle()
        {
            Console.Write("Salle intanciée > ");
            Carre = new Carre();

            newClient = false;
            _queueClient = new Queue<GroupeClient>();
            initSalle();


            //Thread
            thread = new Thread(new ThreadStart(this.ClientArrived));
            thread.Start();

            carte = new Carte();
        }


        private void initSalle()
        {
            maitreHotel = new MaitreHotel(this);
            chefRang = new ChefRang(this);
            serveur = new Serveur(this);
            commisSallle = new CommisSallle();
        }

        public void ClientArrived()
        {
            while (true)
            {
                HowManyClient = randomClient.Next(1, 10);
                clients = new GroupeClient(HowManyClient, idGroupe);
                _queueClient.Enqueue(clients);
                idGroupe++;
                newClient = true;
                Thread.Sleep(NextClient);
            }
        }
    }
}
