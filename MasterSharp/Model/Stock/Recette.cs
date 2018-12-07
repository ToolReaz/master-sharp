using System;
using System.Collections.Generic;
using System.Linq;
using MasterSharp.Model.Stock;

namespace Model.Stock
{
    public class Recette
    {

        private List<IVaisselle> vaisselles { get; }

        private List<Aliment> aliments { get; }

        private List<Action> actions { get; }


        public Recette() {

        }
    }
}
