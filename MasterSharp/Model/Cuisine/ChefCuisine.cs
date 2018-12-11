using MasterSharp.Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Model.Stock;

namespace Model.Cuisine
{
    public class ChefCuisine
    {
        public List<CommisCuisine> _commisCuisine { get; set; }
        public List<ChefPartie> _chefParties { get; set; }

        private Thread _thread;

        private int _lastCommis = 0;
        private int _lastChef = 0;


        public ChefCuisine() {
            // Create commis list and add 2 commis
            _commisCuisine = new List<CommisCuisine> {new CommisCuisine(), new CommisCuisine()};
            // Create chef partie list and add 2 chefs
            _chefParties = new List<ChefPartie> {new ChefPartie(), new ChefPartie()};
        }


        public void Dispatch(Recette r) {
            for (int i = 0; i < r.Actions.Count; i++) {
                if (r.Actions[i].Name == "CUT") {
                    _commisCuisine?[_lastCommis]?.Cut(r.Aliments[i]);
                    _lastCommis++;
                } else if (r.Actions[i].Name == "FIND") {
                    _commisCuisine?[_lastCommis]?.Find(r.Aliments[i]);
                    _lastCommis++;
                } else {
                    _chefParties?[_lastChef]?.AddActionToDo(r.Actions[i], r.Aliments[i]);
                    _lastChef++;
                }


                if (_lastCommis >= _commisCuisine?.Count) {
                    _lastCommis = 0;
                }

                if (_lastChef >= _commisCuisine?.Count) {
                    _lastChef = 0;
                }
            }
        }
    }
}
