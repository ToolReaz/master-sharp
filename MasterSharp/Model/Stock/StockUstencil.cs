using System;
using System.Collections.Generic;
using System.Linq;
using MasterSharp.Model.Stock;

namespace Model.Stock
{
    public class StockUstencil : IStock
    {
        public int GetItemQuantity() {
            throw new NotImplementedException();
        }

        public List<IStockItem> GetDirtyItems()
        {
            throw new NotImplementedException();
        }

        public StockUstencil() {
            throw new NotImplementedException();
        }
    }
}
