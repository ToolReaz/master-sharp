using System;
using System.Collections.Generic;
using System.Linq;
using MasterSharp.Model.Salle;

namespace Model.Salle
{
     public class Carre
    {
        public List<Table> tables { get; set; }
        public static int TableNumber = 0;

        public Carre()
        {
            //Console.WriteLine("Carré intancié > ");
            tables = new List<Table>();
            initTable();
        }

        //useless ?
        public Carre(List<Table> table)
        {
            this.tables = table;
            initTable();
        }

        private void initTable()
        {
            int i;


            //We need 10 tables of 2 
            for (i = 0; i < 9; i++)
                tables.Add(new Table(2, TableNumber, 0));
                TableNumber++;

            //We need 8 tables of 4
            for (i = 0; i < 7; i++)
                tables.Add(new Table(4, TableNumber,0));
                TableNumber++;

            //We need 4 tables of 6 
            for (i = 0; i < 3; i++)
                tables.Add(new Table(6, TableNumber, 0));
                TableNumber++;

            //We need 4 tables of 8 
            for (i = 0; i < 3; i++)
                tables.Add(new Table(8, TableNumber, 0));
                TableNumber++;

            //We need 2 tables of 10 
            for (i = 0; i < 1; i++)
                tables.Add(new Table(10, TableNumber, 0));
                TableNumber++;
        }
    }
}
