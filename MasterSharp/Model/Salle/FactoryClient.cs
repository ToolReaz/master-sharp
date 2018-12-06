using Model.Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSharp.Model.Salle
{
   abstract class FactoryClient
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
