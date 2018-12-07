using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Stock;

namespace MasterSharp.Model.Stock
{
    class Assiette : IVaisselle
    {

        private TypeAssiette Type { get; }


        public Assiette(TypeAssiette type) {
            Type = type;
        }


        public void Wash()
        {
            throw new NotImplementedException();
        }
    }
}
