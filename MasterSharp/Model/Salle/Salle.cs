using System;
using System.Collections.Generic;
using System.Linq;
using MasterSharp.Model.Salle;

namespace Model.Salle
{
    public class Salle
    {
        public Carre Carre { get; set; }
        private Restaurant restaurant { get; }
        private Salle salle;

        //Employees
        private ChefRang chefRang;
        private CommisSallle commisSallle;
        private Serveur serveur;
        //private MaitreHotel maitreHotel;

        public Salle(Restaurant _restaurant, Carre Carre)
        {
            Console.Write("Salle intanciée > ");
            initSalle();
            this.restaurant = _restaurant;
            this.salle = this;
            this.Carre = Carre;
            Carre = new Carre();
        }


        private void initSalle()
        {
            commisSallle = new CommisSallle();
            serveur = new Serveur();
            //maitreHotel = new MaitreHotel(restaurant, salle);
            chefRang = new ChefRang();
        }
    }
}
