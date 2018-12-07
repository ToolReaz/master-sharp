using System;
using System.Linq;
using MasterSharp.Model.Stock;

namespace Model.Stock
{
    public class Aliment
    {

        private TypeAliment Type { get; }


        public Aliment(TypeAliment type) {
            Type = type;
        }

        public bool IsFresh() {
            throw new NotImplementedException();
        }
    }
}
