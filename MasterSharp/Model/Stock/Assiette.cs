using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSharp.Model.Stock
{
    class Assiette : IVaisselle
    {

        private TypeAssiette Type { get; }


        public Assiette(TypeAssiette type) {
            Type = type;
        }
    }
}
