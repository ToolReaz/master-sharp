using System;
using System.Linq;

namespace Model.Salle
{
    public class Table
    {
        private int GroupeClient { get; set; }

        public Table(int GroupeClient)
        {
            this.GroupeClient = GroupeClient;
        }
    }
}
