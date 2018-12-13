using MasterSharp.Model.Cuisine;
using Model.Stock;

namespace MasterSharp.Model.Stock
{
    public class EtapeRecette
    {
        public Aliment Aliment { get; }
        public ActionRecette Action { get; }
        public bool Completed { get; }


        public EtapeRecette(Aliment aliment, ActionRecette action) {
            this.Aliment = aliment;
            this.Action = action;
            this.Completed = false;
        }
    }
}