using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Stock;

namespace MasterSharp.Model.Stock
{
    interface IUstencilNonLavable : IUstencile
    {
        int IsFull();
    }
}
