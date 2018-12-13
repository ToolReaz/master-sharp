using System;
using System.Collections.Generic;
using System.Linq;
using MasterSharp.Model.Salle;

namespace Model.Salle
{
    public class Salle
    {
        public List<Carre> Carres;
        private Restaurant restaurant;
        private Salle salle;

        //Employees
        private ChefRang chefRang;
        private CommisSallle commisSallle;
        private Serveur serveur;
        private MaitreHotel maitreHotel;

        public Salle(Restaurant _restaurant, List<Carre> Carres)
        {
            initSalle();
            this.restaurant = _restaurant;
            this.Carres = Carres;
            Carres.Add(new Carre());
            Carres.Add(new Carre());
        }


        private void initSalle()
        {
            commisSallle = new CommisSallle();
            serveur = new Serveur();
            maitreHotel = new MaitreHotel(restaurant, salle);
            chefRang = new ChefRang();
        }
    }
}
