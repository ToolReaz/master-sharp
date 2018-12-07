using System;
using System.Linq;

namespace Model.Salle
{
    public class Table
    {
        private int GroupeClient { get; }

        public Table(int GroupeClient)
        {
            this.GroupeClient = GroupeClient;
        }
    }
}
