using MasterSharp.Model.Stock;
using Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Cuisine
{
    public class Cuisine
    {
        public IStock StockVaisselle { get; set; }
        public IStock StockTextille { get; set; } 


        public Cuisine()
        {
            this.StockVaisselle = new StockVaisselle();
            this.StockTextille = new StockTextille();
        }

        public void AddCommandRecette(Recette _Recette)
        {
            throw new NotImplementedException();
        }

        public void FinishCommand(Recette _Recette)
        {
            throw new NotImplementedException();
        }
    }
}
