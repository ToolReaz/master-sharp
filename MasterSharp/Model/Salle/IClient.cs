using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSharp.Model.Salle
{
    interface IClient
    {

        void Order(Recette recette);
    }
}
