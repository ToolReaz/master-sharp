using System;
using System.Linq;
using MasterSharp.Model.Salle;

namespace Model.Salle
{
    public abstract class FactoryClient
    {

        public static IClient CreateCoolClient()
        {
            return new Client(TypeClient.COOL);
        }

        public static IClient CreateBusyClient()
        {
            return new Client(TypeClient.BUSY);
        }

        public static IClient CreateStandardClient()
        {
            return new Client(TypeClient.STANDARD);
        }
    }
}
