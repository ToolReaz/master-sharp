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

        public List<Recette> Command { get; private set; }
        private int EatTime { get; set; }

       private TypeClient Type { get; }
        
        public Client(TypeClient Type) 
        {
            this.Type = Type;
        }

        public void ChooseMeal(Carte _carte)
        {
            Command = new List<Recette>();

            //random selection of the client menu
            Random YesOrNot = new Random();

            //Entrée
            if (YesOrNot.Next(1, 2) == 1)
            {
                int entreeNbr = YesOrNot.Next(0, _carte.Entrees.Count());
                Command.Add(_carte.Entrees[entreeNbr]);
            }
            //Plat (plus de chances d'en commander un)
            if (new int[] { 1, 2, 3, 4}.Contains(YesOrNot.Next(1, 5)))
            {
                int platNbr = YesOrNot.Next(0, _carte.Plats.Count());
                Command.Add(_carte.Plats[platNbr]);
            }
            //Dessert
            if (YesOrNot.Next(1, 2) == 1)
            {
                int dessertNbr = YesOrNot.Next(0, _carte.Desserts.Count());
                Command.Add(_carte.Desserts[dessertNbr]);
            }

            Console.WriteLine("Un client a commandé : {0} & {1} & {2}", Command[0].Etapes[1], Command[1].Etapes[1], Command[2].Etapes[1]);
        }

        public void PayBill(int Bill)
        {
            Console.Out.WriteLine("Un client a payé: { 0}", Bill );
        }
    }
}
