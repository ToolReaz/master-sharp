using System.Collections.Generic;
using MasterSharp.Model.Stock;

namespace Model.Stock
{
    public class Recette
    {
        private List<EtapeRecette> Etapes { get; }


        public Recette() {
            this.Etapes = new List<EtapeRecette>();
        }


        public Recette(List<EtapeRecette> etapes) {
            this.Etapes = etapes;
        }


        public void AddEtape(EtapeRecette e) {
            this.Etapes?.Add(e);
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