using System;
using System.Collections.Generic;
using System.Linq;
using MasterSharp.Model.Cuisine;
using MasterSharp.Model.EDM;
using MasterSharp.Model.Stock;
using Model.Stock;

namespace Model.Salle
{
    public sealed class Carte
    {
        //static ref to the object (Singleton DP)
        private static Carte instance = null;
        //Thread-safe : only one thread can instanciate the class
        private static readonly object padlock = new object();


        private List<Recette> Recettes;
        public List<Recette> Entrees { get; set; }
        public List<Recette> Plats { get; set; }
        public List<Recette> Desserts { get; set; }

        //private List<Vin> Vin;
        private int NbCarte = 40;

        //Private unique constructor & without parameters (Singleton DP)
        private Carte()
        {
            //Console.WriteLine("Carte intanciée > ");
            InitCarte();
        }
        
        public void GiveCard(int NbCarteDonner)
        {
            NbCarte = NbCarte - NbCarteDonner;
        }
        public void ReclaimCard(int NbCarteDonner)
        {
            NbCarte = NbCarte + NbCarteDonner;
        }

        public void InitCarte()
        {
            Recettes = new List<Recette>();
            Entrees = new List<Recette>();
            Plats = new List<Recette>();
            Desserts = new List<Recette>();

            MasterSharpEntities db = new MasterSharpEntities();
            var dbRecipes = db.Recipes.ToList();

            foreach (var recipe in dbRecipes)
            {
                //Console.WriteLine("{0}.Recette : {1}", recipe.ID, recipe.Name);
                Recette recette = new Recette(recipe.ID);
                //add all EtapeRecette to the recette :
                foreach (var step in recipe.Recipe_Step)
                {
                    //TotalTime par défaut est à 0, ensuite si les 3 temps additionnels seront 'null' il restera à 0
                    int totalTime = 0;
                    totalTime = (step.Recipe.Preparation?.Milliseconds + step.Recipe.Cook?.Milliseconds + step.Recipe.Rest?.Milliseconds).GetValueOrDefault();
                    EtapeRecette etapeRecette = new EtapeRecette(step.Food.Name, step.Action.Name, totalTime);
                    recette.AddEtape(etapeRecette);
                    //Console.WriteLine("Etape {0} : {1} - {2} ({3}ms)", step.Number_Step, step.Food.Name, step.Action.Name, totalTime);
                }

                //Ajout de la recette du plat dans le tableau correspondant à son type :
                if (recipe.Recipe_Categories.Name == "Entrée")
                {
                    Entrees.Add(recette);
                }
                else if (recipe.Recipe_Categories.Name == "Plat")
                {
                    Plats.Add(recette);
                }
                else if (recipe.Recipe_Categories.Name == "Dessert")
                {
                    Desserts.Add(recette);
                }

            }
        }

        public static Carte Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Carte();
                    }
                    return instance;
                }
            }
        }
    }
}
