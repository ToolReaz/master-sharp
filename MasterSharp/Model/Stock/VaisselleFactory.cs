using System;
using System.Linq;
using MasterSharp.Model.Stock;

namespace Model.Stock
{
    public abstract class VaisselleFactory
    {

        public static IVaisselle CreateAssietteEntree()
        {
            return new Assiette(TypeAssiette.PETITE);
        }

        public static IVaisselle CreateAssietePlate()
        {
            return new Assiette(TypeAssiette.PLATE);
        }

        public static IVaisselle CreateAssiettePlate()
        {
            return new Assiette(TypeAssiette.CREUSE);
        }

        public static IVaisselle CreateAssietteDessert()
        {
            return new Assiette(TypeAssiette.DESSERT);
        }

        public static IVaisselle CreateVerreEau()
        {
            return new Verre(TypeVerres.EAU);
        }

        public static IVaisselle CreateVerreVin()
        {
            return new Verre(TypeVerres.VIN);
        }

        public static IVaisselle CreateVerreFlute()
        {
            return new Verre(TypeVerres.FLUTE);
        }

        public static IVaisselle CreateCouvertFourchette()
        {
            return new Couverts(TypeCouverts.FOURCHETTES);
        }

        public static IVaisselle CreateCouvertCouteaux()
        {
            return new Couverts(TypeCouverts.COUTEAUX);
        }

        public static IVaisselle CreateCouvertCuillereSoupe()
        {
            return new Couverts(TypeCouverts.CUILLERE_SOUPE);
        }

        public static IVaisselle CreateCouvertCuillereCafe()
        {
            return new Couverts(TypeCouverts.CUILLERE_CAFE);
        }
    }
}
