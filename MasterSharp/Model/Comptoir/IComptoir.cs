using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSharp.Comptoir
{
    interface IComptoir
    {
        
        void AddElement(int NbPlatsSalle);
        void RemoveElement(int NbRemoveElement);
    }
}
