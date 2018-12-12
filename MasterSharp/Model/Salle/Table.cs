using System;
using System.Linq;

namespace Model.Salle
{
    public class Table
    {
        private int GroupeClient { get; set; }
        public Salle salle;
        public Carre carre;


        public Table( int Place, int TableNumber)
        {
            

        }

        public void CheckTable(int nbPlace)
        {
            switch(nbPlace)
            {
                case 1:
                case 2:
                    {
                        

                    }break;
                   

                case 3:
                case 4:
                    {

                    }break;

                case 5:
                case 6:
                    {

                    }break;

                case 7:
                case 8:
                    {

                    }break;

                case 9:
                case 10:
                    {

                    }break;
              
                default:
                    {
                        Console.WriteLine("Erreur, aucune table ne peux etre assigné (attendre dans la file)");
                    }
                    break;

            }

        }
    }
}
