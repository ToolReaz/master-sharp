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
        private Cuisine _cuisine { get; }

        private Thread _thread;

        private int _lastCommis = 0;
        private int _lastChef = 0;


        public ChefCuisine(Cuisine cuisine) {
            this._cuisine = cuisine;
        }


        public void Dispatch(Recette recette) {
            for (int i = 0; i < recette.Etapes.Count; i++) {
                if (recette.Etapes[i].Action.Name == "CUT") {
                    this._cuisine.Commis[_lastCommis]?.Cut(recette.Etapes[i].Aliment);
                    _lastCommis++;
                } else if (recette.Etapes[i].Action.Name == "FIND") {
                    this._cuisine.Commis[_lastCommis]?.Find(recette.Etapes[i].Aliment);
                    _lastCommis++;
                } else {
                    this._cuisine.ChefParties[_lastChef]?.AddActionToDo(recette.Etapes[i].Action, recette.Etapes[i].Aliment);
                    _lastChef++;
                }


                if (_lastCommis >= this._cuisine.Commis?.Count) {
                    _lastCommis = 0;
                }

                if (_lastChef >= this._cuisine.Commis?.Count) {
                    _lastChef = 0;
                }
            }
        }
    }
}
