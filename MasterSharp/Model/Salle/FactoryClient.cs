using System;
using System.Linq;
using MasterSharp.Model.Salle;

namespace Model.Salle
{
    public abstract class FactoryClient
    {

        public static IClient CreateCoolClient(GroupeClient groupeClient)
        {
            return new Client(TypeClient.COOL, groupeClient);
        }

        public static IClient CreateBusyClient(GroupeClient groupeClient)
        {
            return new Client(TypeClient.BUSY, groupeClient);
        }

        public static IClient CreateStandardClient(GroupeClient groupeClient)
        {
            return new Client(TypeClient.STANDARD, groupeClient);
        }
    }
}
