using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSharp.Model.Salle
{
    class Salle
    {
        private List<Carre> Carre;

        public Salle(List<Carre> Carre)
        {
            this.Carre = Carre;
        }
    }
}
