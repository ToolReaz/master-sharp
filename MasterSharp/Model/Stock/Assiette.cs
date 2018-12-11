using System;
using System.Linq;
using MasterSharp.Model.Stock;

namespace Model.Stock
{
    public class Assiette : IVaisselle
    {

        private TypeAssiette Type { get; }

        private bool Clean { get; set; }


        public Assiette(TypeAssiette type) {
            Type = type;
            Clean = true;
        }


        public bool IsClean() {
            return this.Clean;
        }


        public void Wash() {
            this.Clean = true;
        }
    }
}
