using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MasterSharp.Model.Salle;
using MasterSharp.Model.Stock;
using Model.Stock;

namespace Model.Salle
{
     public class Client : IClient
    {
        private Thread thread;

        public List<Commande> Commandes { get; private set; }
        private int EatTime { get; set; }

        private TypeClient Type { get; }
        public GroupeClient groupeClient;
        private int idGroupe;
        
        public Client(TypeClient Type, GroupeClient _groupeClient) 
        {
            this.Type = Type;
            groupeClient = _groupeClient;
            idGroupe = groupeClient.idGroupe;
        }

        public void ChooseMeal(Carte _carte)
        {
            Commandes = new List<Commande>();

            //random selection of the client menu
            Random YesOrNot = new Random();

            //Entrée
            if (YesOrNot.Next(1, 2) == 1)
            {
                int entreeNbr = YesOrNot.Next(0, _carte.Entrees.Count());
                Commandes.Add(new Commande(this, _carte.Entrees[entreeNbr], "entrée"));
            }
            //Plat (plus de chances d'en commander un)
            if (new int[] { 1, 2, 3, 4}.Contains(YesOrNot.Next(1, 5)))
            {
                int platNbr = YesOrNot.Next(0, _carte.Plats.Count());
                Commandes.Add(new Commande(this, _carte.Plats[platNbr], "plat"));
            }
            //Dessert
            if (YesOrNot.Next(1, 2) == 1)
            {
                int dessertNbr = YesOrNot.Next(0, _carte.Desserts.Count());
                Commandes.Add(new Commande(this, _carte.Desserts[dessertNbr], "dessert"));
            }

            Console.WriteLine("Un client a commandé : {0} & {1} & {2}", Commandes[0].recette.Etapes[0], Commandes[1].recette.Etapes[0], Commandes[2].recette.Etapes[0]);
        }

        public void PayBill(int Bill)
        {
            Console.Out.WriteLine("Un client a payé: { 0}", Bill );
        }
    }
}
