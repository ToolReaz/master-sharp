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

        public void ChooseMeal()
        {
            Commandes = new List<Commande>();

            //random selection of the client menu
            Random YesOrNot = new Random();

            //Entrée
            if (YesOrNot.Next(1, 2) == 1)
            {
                int entreeNbr = YesOrNot.Next(0, Carte.Instance.Entrees.Count());
                Commandes.Add(new Commande(this, entreeNbr, "Entrees"));
            }
            //Plat (plus de chances d'en commander un)
            //if (new int[] { 1, 2, 3, 4}.Contains(YesOrNot.Next(1, 5))) { }
            
            //Un client aura tjrs un plat
            int platNbr = YesOrNot.Next(0, Carte.Instance.Plats.Count());
            Commandes.Add(new Commande(this, platNbr, "Plats"));
            
            //Dessert
            if (YesOrNot.Next(1, 4) == 1)
            {
                int dessertNbr = YesOrNot.Next(0, Carte.Instance.Desserts.Count());
                Commandes.Add(new Commande(this, dessertNbr, "Desserts"));
            }

            //Console.WriteLine("Un client a commandé : {0} & {1} & {2}", Commandes[0]?.recetteNbr, Commandes[1]?.recetteNbr, Commandes[2]?.recetteNbr);
        }

        public void PayBill(int Bill)
        {
            Console.Out.WriteLine("Un client a payé: { 0}", Bill );
        }
    }
}
