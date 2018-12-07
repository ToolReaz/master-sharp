using System;
using System.Collections.Generic;
using System.Linq;
using MasterSharp.Model.Salle;

namespace Model.Salle
{
    public class Salle
    {
        private List<Carre> Carre;

        public Salle(List<Carre> Carre)
        {
            this.Carre = Carre;
        }
    }
}
