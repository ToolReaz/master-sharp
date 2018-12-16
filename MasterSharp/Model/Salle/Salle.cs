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
        public MaitreHotel maitreHotel;
        public ChefRang chefRang;
        public CommisSallle commisSallle;
        public Serveur serveur;
        //Recips commands 
        public Carte carte { get; set; }
        private List<Recette> recettes;
        //Reception
        public static GroupeClient clients { get; set; }
        private Thread thread;
        private const int NextClient = 24000;
        private Random randomClient = new Random();
        public int HowManyClient { get; private set; }
        public Queue<GroupeClient> _queueClient { get; set; }
        public Queue<GroupeClient> _justArrivedClients { get; set; }
        public Queue<GroupeClient> _readyToOrderClients { get; set; }
        public Queue<GroupeClient> _waitingClients { get; set; }
        public Queue<GroupeClient> _finishedClients { get; set; }
        public static int idGroupe = 1;
        public bool newClient { get; set; }



        public Salle()
        {
            //Console.WriteLine("Salle intanciée > ");
            Carre = new Carre();

            newClient = false;
            _queueClient = new Queue<GroupeClient>();
            _justArrivedClients = new Queue<GroupeClient>();
            _readyToOrderClients = new Queue<GroupeClient>();
            _waitingClients = new Queue<GroupeClient>();
            _finishedClients = new Queue<GroupeClient>();
            initSalle();


            //Thread
            thread = new Thread(new ThreadStart(this.ClientArrived));
            thread.Start();
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
                Console.WriteLine("Groupe de {0} clients généré, groupe numéro {1}.", HowManyClient+1, idGroupe);
                _queueClient.Enqueue(clients);
                idGroupe++;
                newClient = true;
                Thread.Sleep(NextClient);
            }
        }
    }
}
