using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Cuisine;
using Model.Salle;


namespace Model
{
    public class Restaurant
    {
        private int queue;
        private Salle salle;
        private Cuisine cuisine;

        public Cuisine Cuisine { get; set; }
        public Salle Salle { get; set; }

        public Restaurant()
        {
            this.salle = new Salle();
            this.cuisine = new Cuisine();

        }

       public bool ClientArrived(GroupeClient Groupe)
        {
            if(Groupe.NewClient() == true)
            {
                return true;
            }
            return false;
        }
    }
}
