using System;
using System.Collections.Generic;
using System.Linq;

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
