using System;
using System.Collections.Generic;
using System.Linq;
using MasterSharp.Model.Cuisine;
using MasterSharp.Model.EDM;
using MasterSharp.Model.Stock;
using Model.Stock;

namespace Model.Salle
{
    public class Carte
    {
        private List<Recette> Recettes;
        public List<Recette> Entrees { get; set; }
        public List<Recette> Plats { get; set; }
        public List<Recette> Desserts { get; set; }

        //private List<Vin> Vin;
        private int NbCarte = 40;

        public Carte()
        {
            Console.Write("Carte intanciée > ");
        }
        
        public void GiveCard(int NbCarteDonner)
        {
            NbCarte = NbCarte - NbCarteDonner;
        }

        public void CompositionCarte()
        {
            Recettes = new List<Recette>();
            Entrees = new List<Recette>();
            Plats = new List<Recette>();
            Desserts = new List<Recette>();

            MasterSharpEntities db = new MasterSharpEntities();
            var dbRecipes = db.Recipes.ToList();

            foreach (var recipe in dbRecipes)
            {
                Console.WriteLine(recipe.Name);

                Recette recette = new Recette();

                //add all EtapeRecette to the recette :
                foreach (var step in recipe.Recipe_Step)
                {
                    /*EtapeRecette etapeRecette = new EtapeRecette(new ActionRecette(step., step.Action.Utensils));
                    recette.AddEtape(etapeRecette);*/
                }

                //Ajout de la recette du plat dans le tableau correspondant à son type :
                if (recipe.Recipe_Categories.Name == "Entrée")
                {
                    Entrees.Add(recette);
                }
                else if (recipe.Recipe_Categories.Name == "Plat")
                {
                    Entrees.Add(recette);
                }
                else if (recipe.Recipe_Categories.Name == "Dessert")
                {
                    Entrees.Add(recette);
                }

            }
        }
    }
}
