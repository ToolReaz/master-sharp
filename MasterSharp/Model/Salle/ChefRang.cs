using System;
using System.Linq;
using System.Threading;
using MasterSharp.Model.Salle;

namespace Model.Salle
{
    public class ChefRang : IEmployeSalle
    {
        private Salle salle;
        private Thread thread;
        private Table table;

        public ChefRang()
        {
            this.salle = salle;
            this.thread = new Thread(new ThreadStart(this.DoWork));
            thread.Start();
        }
      
        public void DoWork()
        {
            throw new NotImplementedException();
        }

        public void GiveMenu()
        {
            throw new NotImplementedException();
        }

        public void TakeCommand()
        {
            throw new NotImplementedException();
        }

    }
}
