using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterSharp.Model.Salle;

namespace MasterSharp.Model
{
    class Restaurant
    {
        private SalleElements.Salle Salle { get; }
        private Cuisine Cuisine { get; }

        public Restaurant() {
            this.Cuisine = new Cuisine();
            this.Salle = new SalleElements.Salle();
        }

        public void ClientArrived(IClient client) {

        }
    }
}