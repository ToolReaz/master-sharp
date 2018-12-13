using System;
using System.Collections.Generic;
using System.Linq;
using MasterSharp.Model.Stock;
using Model.Stock;

namespace Model.Salle
{
    public class Carte
    {
        private List<Recette> Recettes;
        //private List<Vin> Vin;
        private int NbCarte = 40;

        public Carte(List<Recette> Recettes)
        {
            Console.WriteLine("Carte intancié");
            this.Recettes = Recettes;
        }
        
        public void GiveCard(int NbCarteDonner)
        {
            NbCarte = NbCarte - NbCarteDonner;
        }
    }
}
