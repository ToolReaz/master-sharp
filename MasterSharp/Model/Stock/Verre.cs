using System;
using System.Linq;

namespace Model.Stock
{
    public class Verre : IVaisselle
    {

        public TypeVerres Type { get; }

        private bool Clean { get; set; }


        public Verre(TypeVerres type) {
            throw new NotImplementedException();
        }


        public bool IsClean() {
            return this.Clean;
        }


        public void Wash() {
            throw new NotImplementedException();
        }
    }
}
