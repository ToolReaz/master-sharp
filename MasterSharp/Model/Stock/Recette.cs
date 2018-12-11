using System;
using System.Collections.Generic;
using System.Linq;
using MasterSharp.Model.Cuisine;
using MasterSharp.Model.Stock;

namespace Model.Stock
{
    public class Recette
    {
        public List<IVaisselle> Vaisselles { get; }

        public List<Aliment> Aliments { get; }

        public List<ActionRecette> Actions { get; }

        public Recette(List<IVaisselle> vaisselles, List<Aliment> aliments, List<ActionRecette> actions) {
            Vaisselles = vaisselles;
            Aliments = aliments;
            Actions = actions;
        }
    }
}
