using System;
using System.Linq;
using MasterSharp.Model.Stock;

namespace Model.Stock
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
