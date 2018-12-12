using MasterSharp.Model.Cuisine;
using Model.Stock;

namespace MasterSharp.Model.Stock
{
    public class EtapeRecette
    {
        public IVaisselle Vaisselle { get; }
        public Aliment Aliment { get; }
        public ActionRecette Action { get; }
        public bool Completed { get; }


        public EtapeRecette(IVaisselle vaisselle, Aliment aliment, ActionRecette action) {
            this.Vaisselle = vaisselle;
            this.Aliment = aliment;
            this.Action = action;
            this.Completed = false;
        }
    }
}