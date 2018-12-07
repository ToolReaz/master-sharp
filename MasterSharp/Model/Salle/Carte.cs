using System;
using System.Collections.Generic;
using System.Linq;
using MasterSharp.Model.Stock;
using Model.Stock;

namespace Model.Salle
{
    public class Carte
    {
        private List<Recette> Recette;
        //private List<Vin> Vin;

        public Carte(List<Recette> Rectte)
        {
            this.Recette = Recette;
        }
    }
}
