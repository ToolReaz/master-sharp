using System;
using System.Linq;
using MasterSharp.Model.Stock;

namespace Model.Stock
{
    public class Couverts : IVaisselle
    {

        public TypeCouverts Type { get; }

        private bool Clean { get; }


        public Couverts(TypeCouverts type) {
            Type = type;
            Clean = true;
        }


        public bool IsClean() {
            return this.Clean;
        }


        public void Wash()
        {
            throw new NotImplementedException();
        }
    }
}
