using System;
using System.Collections.Generic;
using System.Linq;
using MasterSharp.Model.Salle;

namespace Model.Salle
{
    public class Salle
    {
        private List<Carre> Carre;
        private Restaurant restaurant;

        //Employees
        private ChefRang chefRang;
        private CommisSallle commisSallle;
        private Serveur serveur;
        private MaitreHotel maitreHotel;

        public Salle(List<Carre> Carre)
        {
            initSalle();
            this.Carre = Carre;
            Carre.Add(new Carre(new List<Table>()));
            Carre.Add(new Carre(new List<Table>()));
        }


        private void initSalle()
        {
            commisSallle = new CommisSallle();
            serveur = new Serveur();
            maitreHotel = new MaitreHotel();
            chefRang = new ChefRang();
        }
    }
}
