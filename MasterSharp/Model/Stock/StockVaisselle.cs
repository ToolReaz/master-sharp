using System;
using System.Collections.Generic;
using System.Linq;
using MasterSharp.Model.Stock;

namespace Model.Stock
{
    public class StockVaisselle : IStock
    {

        private List<IVaisselle> Vaisselle { get; }


        public StockVaisselle()
        {
        }

        public StockVaisselle(List<IVaisselle> vaisselle) {
            throw new NotImplementedException();
        }



        public IVaisselle GetItem() {
            throw new NotImplementedException();
        }

        public List<IStockItem> GetDirtyItems() {
            List<IStockItem> o = new List<IStockItem>();
            Vaisselle?.ForEach(
                item => {
                    if (!item.IsClean()) {
                        o.Add(item);
                    }
                });
            return o;
        }

        public int GetItemQuantity() {
            throw new NotImplementedException();
        }
    }
}
