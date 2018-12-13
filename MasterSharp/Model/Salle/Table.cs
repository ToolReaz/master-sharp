using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Salle
{
    public class Table
    {

        public Salle salle { get; set; }
        public Carre carre { get; set; }
        public int Place { get; set; }
        public int TableNumber { get; set; }
        public int NumeroGroupe { get; set; }


        public Table( int Place, int TableNumber, int NumeroGroupe)
        {
            this.Place = Place;
            this.TableNumber = TableNumber;
            this.NumeroGroupe = NumeroGroupe;
            

           
        }

    }
}
