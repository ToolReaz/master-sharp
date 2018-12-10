using MasterSharp.Model.Stock;
using Model.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Model.Cuisine
{
    public class CommisCuisine : IEmployeCuisine
    {

        private Thread thread;
        bool ShouldRun = true;


        public CommisCuisine() {
            this.thread = new Thread(new ThreadStart(this.DoWork));
        }

        public void DoWork() {
            while (ShouldRun) {

            }
        }

        public void Cut(Aliment _Aliment)
        {
            throw new NotImplementedException();
        }

        public void Find(Aliment _Aliment)
        {
            throw new NotImplementedException();
        }
    }
}
