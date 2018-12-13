using System;
using System.Linq;
using System.Threading;
using MasterSharp.Model.Salle;

namespace Model.Salle
{
    public class Serveur : IEmployeSalle
    {
        private Salle salle;
        private Thread thread;
        private Table table;
        private GroupeClient groupe;

        public Serveur()
        {
            Console.Write("Serveur intancié > ");
            this.salle = salle;
            this.thread = new Thread(new ThreadStart(this.DoWork));
            
        }
        public void DoWork()
        {
            throw new NotImplementedException();
        }

        public void ServeClient(Client client)
        {
            throw new NotImplementedException();
        }

        //debarrasser la table
        public void RidOff()
        {
            throw new NotImplementedException();
        }

        public void BringFood()
        {
            throw new NotImplementedException();
        }
    }

}
