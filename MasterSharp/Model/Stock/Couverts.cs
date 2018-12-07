using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Stock;

namespace MasterSharp.Model.Stock
{
    public class Couverts : IVaisselle
    {

        private TypeCouverts Type { get; }

        private bool Clean { get; }


        public Couverts(TypeCouverts type) {
            Type = type;
        }


        public void Wash()
        {
            throw new NotImplementedException();
        }
    }
}
