using System.Collections.Generic;
using MasterSharp.Model.Stock;

namespace Model.Stock
{
    public class Recette
    {
        public List<EtapeRecette> Etapes { get; }
        public List<IVaisselle> Vaisselle { get; }



        public Recette() {
            this.Etapes = new List<EtapeRecette>();
            this.Vaisselle = new List<IVaisselle>();
        }


        public Recette(List<EtapeRecette> etapes, List<IVaisselle> vaisselles) {
            this.Etapes = etapes;
            this.Vaisselle = vaisselles;
        }


        public void AddEtape(EtapeRecette e) {
            this.Etapes?.Add(e);
        }


        public void AddVaisselle(IVaisselle v) {
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