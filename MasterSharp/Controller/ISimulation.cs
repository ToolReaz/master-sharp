using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSharp.Controller
{
    interface ISimulation
    {

        void Start();
        void Pause();
        void Resume();
    }
}
