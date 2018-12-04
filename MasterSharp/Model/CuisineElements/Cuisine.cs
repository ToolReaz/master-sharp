using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MasterSharp.Model
{
    class Cuisine
    {
        private ChefCuisine ChefCuisine { get; }
        private ChefPartie ChefPartie { get; }
        private Plongeur Plongeur { get; }
        private CommisCuisine CommisCuisine { get; }

        private List<Recette> CommandsList;

        public Cuisine() {
            this.ChefCuisine = new ChefCuisine();
            this.ChefPartie = new ChefPartie();
            this.Plongeur = new Plongeur();
            this.CommisCuisine = new CommisCuisine();

            this.CommandsList = new List<Recette>();
        }

        public void AddCommand(Recette recette) {
            this.CommandsList?.Add(recette);
        }

        public void FinishCommand(Recette recette) {
            this.CommandsList?.Remove(recette);
        }
    }
}
