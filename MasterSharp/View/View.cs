using MasterSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;   

namespace View
{
    //public access and sealed "scellée" (Singleton DP)
    public class View 
    {
        //static ref to the object (Singleton DP)
        private static  View instance = null;
        //Thread-safe : only one thread can instanciate the class
        private static readonly object padlock = new object();

        MainWindow winForm;

        //Private unique constructor & without parameters (Singleton DP)
        public View()
        {
            //Console.WriteLine("View instanciée >");
        }


        public static View Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new View();
                    }
                    return instance;
                }
            }
        }

        public void winPassRef(MainWindow _winForm)
        {
            winForm = _winForm;
        }

        //Add columns indicators
        public void AddClient(string text2Print)
        {
            winForm.Clients.Add(text2Print);
        }
        public void AddSalleCommande(string text2Print)
        {
            winForm.SalleCommandes.Add(text2Print);
        }
        public void AddCuisineCommandes(string text2Print)
        {
            winForm.CuisineCommandes.Add(text2Print);
        }
        public void AddPreparations(string text2Print)
        {
            winForm.Preparations.Add(text2Print);
        }

        //Remove columns indicators
        public void RemoveClient(string obj2Remove)
        {
            winForm.Clients.Remove(obj2Remove);
        }
        public void RemoveSalleCommande(string obj2Remove)
        {
            winForm.SalleCommandes.Remove(obj2Remove);
        }
        public void RemoveCuisineCommandes(string obj2Remove)
        {
            winForm.CuisineCommandes.Remove(obj2Remove);
        }
        public void RemovePreparations(string obj2Remove)
        {
            winForm.Preparations.Remove(obj2Remove);
        }
    }
}
