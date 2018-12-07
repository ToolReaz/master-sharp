using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Stock;

namespace MasterSharp.Model.Stock
{
    public class StockVaisselle : IStock
    {

        private List<IVaisselle> Vaisselle { get; }

        public StockVaisselle(List<IVaisselle> vaisselle) {
            throw new NotImplementedException();
        }



        public IVaisselle GetItem() {
            throw new NotImplementedException();
        }

        public int GetItemQuantity() {
            throw new NotImplementedException();
        }
    }
}
