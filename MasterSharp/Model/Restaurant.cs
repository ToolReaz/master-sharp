using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MasterSharp.Model.EDM;
using Model.Cuisine;
using Model.Salle;
using Model.Stock;

namespace Model
{
    public class Restaurant
    {

        private GroupeClient clients;
        private Thread thread;
        private const int NextClient = 1200000;
        public int HowManyClient { get; private set; }
        private Random randomClient = new Random();
        public Queue<GroupeClient> _queueClient { get; private set; }
        private Salle.Salle salle;
        public Carte carte { get; set; }
        private List<Recette> recettes;

        //private MaitreHotel maitreHotel;
        public static int idGroupe = 1;

        public Restaurant()
        {
            _queueClient = new Queue<GroupeClient>();
            salle = new Salle.Salle(this, new List<Carre>());

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

        public void CompositionCarte()
        {
            recettes = new List<Recette>();

            MasterSharpEntities db = new MasterSharpEntities();
            var dbRecipes = db.Recipes.ToList();

            foreach (var recipe in dbRecipes)
            {
                Console.WriteLine(recipe);
            }

            carte = new Carte(recettes);
        }
    }
}
