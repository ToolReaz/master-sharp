using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Salle
{
    public class Table
    {
        private int GroupeClient { get; set; }
        public Salle salle;
        public Carre carre;
        public Restaurant resto;
        public int Place;
        public int TableNumber;
        public int NumeroGroupe;


        public Table( int Place, int TableNumber, int NumeroGroupe)
        {
            this.Place = Place;
            this.TableNumber = TableNumber;
            this.NumeroGroupe = NumeroGroupe;
            

           
        }

    }
}
