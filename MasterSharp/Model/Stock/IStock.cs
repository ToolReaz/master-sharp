using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Stock;

namespace MasterSharp.Model.Stock
{
    public interface IStock
    {

        int GetItemQuantity();

        List<IStockItem> GetDirtyItems();
    }
}
