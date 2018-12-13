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
        // Instance of cuisine
        private Cuisine _cuisine { get; }

        // Last commis who was assigned a task
        private int _lastCommis = 0;

        // Last commis who was assigned a task
        private int _lastChef = 0;


        public ChefCuisine(Cuisine cuisine) {
            this._cuisine = cuisine;
        }


        public void Dispatch(Recette recette) {
            // For each step of a recipe
            for (int i = 0; i < recette.Etapes.Count; i++) {
                // If the step's action is CUT
                if (recette.Etapes[i].ActionName == "CUT") {
                    // Send the aliment to cut to the commis
                    this._cuisine.Commis[_lastCommis]?.Cut(recette.Etapes[i].Aliment);
                    // The next action will be performed by the next commis
                    _lastCommis++;
                } else if (recette.Etapes[i].ActionName == "FIND") {
                    // Send the aliment to find to the commis
                    this._cuisine.Commis[_lastCommis]?.Find(recette.Etapes[i].Aliment);
                    // The next action will be performed by the next commis
                    _lastCommis++;
                } else {
                    // Send the others actions to the chefs
                    this._cuisine.ChefParties[_lastChef]?.AddActionToDo(recette.Etapes[i].ActionName, recette.Etapes[i].ActionTime);
                    // The next action will be performed by the next chef
                    _lastChef++;
                }


                // Reset the last commis who was assigned a task if every commis had a task
                if (_lastCommis >= this._cuisine.Commis?.Count) {
                    _lastCommis = 0;
                }

                // Reset the last chef who was assigned a task if every commis had a task
                if (_lastChef >= this._cuisine.Commis?.Count) {
                    _lastChef = 0;
                }
            }
        }
    }
}
