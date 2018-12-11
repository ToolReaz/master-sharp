using System;
using System.Collections.Generic;
using System.Linq;
using MasterSharp.Model.Salle;

namespace Model.Salle
{
     public class Carre
    {
        private List<Table> Rang;

        public Carre(List<Table> Rang)
        {
            this.Rang = Rang;
            initTable();
            
        }

        private void initTable()
        {
            int i;

            //We need 10 tables of 2 but we divide by 2 becasue we use 2 squarre (carre)
            for (i = 0; i < 4; i++)
                Rang.Add(new Table(2));   

            //We need 8 tables of 4 but we divide by 2 becasue we use 2 squarre (carre)
            for (i = 0; i < 4; i++)
                Rang.Add(new Table(4));

            //We need 4 tables of 6 but we divide by 2 becasue we use 2 squarre (carre)
            for (i = 0; i < 2; i++)
                Rang.Add(new Table(6));

            //We need 4 tables of 8 but we divide by 2 becasue we use 2 squarre (carre)
            for (i = 0; i < 2; i++)
                Rang.Add(new Table(8));

            //We need 2 tables of 10 but we divide by 2 becasue we use 2 squarre (carre)
            for (i = 0; i <= 1; i++)
                Rang.Add(new Table(10));
        }
    }
}
