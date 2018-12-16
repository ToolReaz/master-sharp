using System.Collections.Generic;
using MasterSharp.Model.EDM;
using MasterSharp.Model.Stock;

namespace Model.Stock
{
    public class Recette
    {
        public int recipeID { get; }
        public List<EtapeRecette> Etapes { get; }
        public List<Dish> Vaisselle { get; }


        public Recette(int recipeID) {
            this.recipeID = recipeID;
            this.Etapes = new List<EtapeRecette>();
            this.Vaisselle = new List<Dish>();
        }


        public Recette(List<EtapeRecette> etapes, List<Dish> vaisselles, int recipeID) {
            this.Etapes = etapes;
            this.Vaisselle = vaisselles;
            this.recipeID = recipeID;
        }


        public void AddEtape(EtapeRecette e) {
            this.Etapes?.Add(e);
        }


        public void AddVaisselle(Dish v) {
            this.Vaisselle?.Add(v);
        }


        public bool IsComplet() {
            foreach (EtapeRecette etape in Etapes) {
                if (!etape.Completed) {
                    return false;
                }
            }

            return true;
        }
    }
}