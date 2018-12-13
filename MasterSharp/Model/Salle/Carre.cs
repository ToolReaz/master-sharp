using System;
using System.Collections.Generic;
using System.Linq;
using MasterSharp.Model.Salle;

namespace Model.Salle
{
     public class Carre
    {
        public List<Table> tables;
        public static int TableNumber = 0;

        public Carre()
        {
            initTable();
        }

        //useless ?
        public Carre(List<Table> table)
        {
            this.tables = table;  
        }

        private void initTable()
        {
            int i;


            //We need 10 tables of 2 but we divide by 2 becasue we use 2 squarre (carre)
            for (i = 0; i < 4; i++)
                tables.Add(new Table(2, TableNumber, 0));
                TableNumber++;

            //We need 8 tables of 4 but we divide by 2 becasue we use 2 squarre (carre)
            for (i = 0; i < 4; i++)
                tables.Add(new Table(4, TableNumber,0));
                TableNumber++;

            //We need 4 tables of 6 but we divide by 2 becasue we use 2 squarre (carre)
            for (i = 0; i < 2; i++)
                tables.Add(new Table(6, TableNumber, 0));
                TableNumber++;

            //We need 4 tables of 8 but we divide by 2 becasue we use 2 squarre (carre)
            for (i = 0; i < 2; i++)
                tables.Add(new Table(8, TableNumber, 0));
                TableNumber++;

            //We need 2 tables of 10 but we divide by 2 becasue we use 2 squarre (carre)
            for (i = 0; i <= 1; i++)
                tables.Add(new Table(10, TableNumber, 0));
                TableNumber++;
        }
    }
}
