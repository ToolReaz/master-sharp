using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSharp.Model.Salle
{
    public class GroupeClient
    {
        private List<Client> Groupe;


        public GroupeClient(List<Client> Groupe)
        {
            this.Groupe = Groupe;
        }
    }
}
