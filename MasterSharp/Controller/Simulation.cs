using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterSharp.Model;

namespace MasterSharp.Controller
{
    class Simulation : ISimulation
    {
        private Restaurant restaurant { get; }

        public Simulation() {
            this.restaurant = new Restaurant();
        }

        public void Start() {
            // View creation
            throw new NotImplementedException();
        }

        public void Pause() {
            // All Threads paused
            throw new NotImplementedException();
        }

        public void Resume() {
            // All Threads resumed
            throw new NotImplementedException();
        }
    }
}
