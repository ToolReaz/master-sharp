using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSharp.Model.Salle
{
    class ClientFactory
    {
        public IClient CreateClient(string type) {
            switch (type) {
                case "COOL": return new Client(90);
                case "BUSY": return new Client(30);
                default: return new Client(60);
            }
        }
    }
}
