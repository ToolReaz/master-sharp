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
            Console.WriteLine("Chef de rang intancié");
            this.salle = salle;
            this.thread = new Thread(new ThreadStart(this.DoWork));
            thread.Start();
        }
      
        public void DoWork()
        {
            //A COMPLETER
            return;
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
