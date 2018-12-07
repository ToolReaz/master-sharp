using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Salle
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
