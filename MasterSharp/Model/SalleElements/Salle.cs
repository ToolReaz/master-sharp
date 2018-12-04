using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSharp.Model.SalleElements
{
    class Salle
    {
        private ChefRang ChefRang { get; }
        private MaitreHotel MaitreHotel { get; }
        private Serveur Serveur { get; }
        private CommisSalle CommisSalle { get; }

        public Salle() {
            this.ChefRang = new ChefRang();
            this.MaitreHotel = new MaitreHotel();
            this.Serveur = new Serveur();
            this.CommisSalle = new CommisSalle();
        }
    }
}
