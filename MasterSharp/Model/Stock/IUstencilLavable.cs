using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Stock;

namespace MasterSharp.Model.Stock
{
    interface IUstencilLavable : IUstencile
    {
        bool IsClean();

        void Wash();
    }
}
