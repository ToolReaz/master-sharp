using System;
using System.Linq;
using MasterSharp.Model.Stock;

namespace Model.Stock
{
    public abstract class VaisselleFactory
    {
        public static IVaisselle CreateAssiette(TypeAssiette t) {
            return new Assiette(t);
        }

        public static IVaisselle CreateVerre(TypeVerres t)
        {
            return new Verre(t);
        }

        public static IVaisselle CreateCouvert(TypeCouverts t)
        {
            return new Couverts(t);
        }
    }
}
