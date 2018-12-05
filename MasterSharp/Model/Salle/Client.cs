using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSharp.Model.Salle
{
    class Client
    {
        private List<Recette> Command { get; }
        
        public Client(int EatTime, List<Recette> Command)
        {
            this.Command = Command;

        }


    }
}
