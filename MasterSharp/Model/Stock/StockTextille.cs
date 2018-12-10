using System;
using System.Collections.Generic;
using System.Linq;
using MasterSharp.Model.Stock;

namespace Model.Stock
{
    public class StockTextille : IStock
    {

        private List<ITextille> Textille { get; set; }



        public StockTextille() {

        }



        public int GetItemQuantity() {
            throw new NotImplementedException();
        }

        public List<IStockItem> GetDirtyItems()
        {
            List<IStockItem> o = new List<IStockItem>();
            Textille?.ForEach(
                item => {
                    if (!item.IsClean())
                    {
                        o.Add(item);
                    }
                });
            return o;
        }

        public StockTextille() {
            throw new NotImplementedException();
        }
    }
}
