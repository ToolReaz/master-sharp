using System;
using System.Collections.Generic;
using System.Linq;
using MasterSharp.Model.Salle;

namespace Model.Salle
{
    public class Salle
    {
        private List<Carre> Carres;
        private Restaurant restaurant;
        private Salle salle;

        //Employees
        private ChefRang chefRang;
        private CommisSallle commisSallle;
        private Serveur serveur;
        private MaitreHotel maitreHotel;

        public Salle(List<Carre> Carre)
        {
            initSalle();
            this.Carres = Carres;
            Carres.Add(new Carre(new List<Table>()));
            Carres.Add(new Carre(new List<Table>()));
        }


        private void initSalle()
        {
            commisSallle = new CommisSallle();
            serveur = new Serveur();
            maitreHotel = new MaitreHotel(salle);
            chefRang = new ChefRang();
        }
    }
}
