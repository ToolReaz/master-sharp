using System;
using System.Linq;
using MasterSharp.Model.Stock;

namespace Model.Stock
{
    public class Assiette : IVaisselle
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
