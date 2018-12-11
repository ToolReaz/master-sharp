using System;
using System.Linq;
using System.Threading;
using MasterSharp.Model.Salle;

namespace Model.Salle
{
    public class MaitreHotel : IEmployeSalle
    {
        private Salle salle;
        private Thread thread;
        private Table table;

        public MaitreHotel(Salle salle)
        {
            this.salle = salle;
            this.thread = new Thread(new ThreadStart(this.DoWork));
        }
        public void DoWork()
        {
            
            throw new NotImplementedException();
        }

        public void Welcome()
        {
            throw new NotImplementedException();
        }
    }
}
