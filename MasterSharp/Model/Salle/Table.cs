using System;
using System.Linq;

namespace Model.Salle
{
    public class Table
    {
        private int GroupeClient { get; set; }
        private GroupeClient Client;

        public Table(int GroupeClient, int Place)
        {
            this.GroupeClient = GroupeClient;
            Client = new GroupeClient(GroupeClient);
        }
    }
}
