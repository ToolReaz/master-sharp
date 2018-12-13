using System;
using System.Linq;
using System.Threading;
using MasterSharp.Model.Salle;

namespace Model.Salle
{
    public class CommisSallle : IEmployeSalle
    {
        private Salle salle;
        private Thread thread;
        private int watter = 40;
        private int bread = 40;

        public CommisSallle()
        {
            this.salle = salle;
            this.thread = new Thread(new ThreadStart(this.DoWork));
           // thread.Start();
        }
        public void DoWork()
        {
            while (true)
            {

            }
        }

        public void ServeWaterBread()
        {
          
        }

    }
}
