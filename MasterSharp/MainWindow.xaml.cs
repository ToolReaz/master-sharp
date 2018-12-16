using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MasterSharp.Model.EDM;
using View;
using System.ComponentModel;


namespace MasterSharp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        //Vars LIVE UPDATE
        public String test = "Oh non, ca marche!";
        public List<String> clients = new List<string>();
        public List<String> salleCommandes = new List<string>();
        public List<String> cuisineCommandes = new List<string>();
        public List<String> preparations = new List<string>();
        public List<String> Clients
        {
            get { return clients; }
            set
            {
                if (value == clients)
                    return;
                clients = value;
                NotifyPropertyChanged("Clients");
            }
        }
        public List<String> SalleCommandes
        {
            get { return salleCommandes; }
            set
            {
                if (value == salleCommandes)
                    return;
                salleCommandes = value;
                NotifyPropertyChanged("SalleCommandes");
            }
        }
        public List<String> CuisineCommandes
        {
            get { return cuisineCommandes; }
            set
            {
                if (value == cuisineCommandes)
                    return;
                cuisineCommandes = value;
                NotifyPropertyChanged("CuisineCommandes");
            }
        }
        public List<String> Preparations
        {
            get { return preparations; }
            set
            {
                if (value == preparations)
                    return;
                preparations = value;
                NotifyPropertyChanged("Preparations");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string nomPropriete)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
        }

        //Random menu of the day
        MenuOfTheDay motd = new MenuOfTheDay();
        Recipe starterOfTheDay,plateOfTheDay,dessertOfTheDay;

        //Sockets
        Thread sockServerCuisine;


        /*---ENTRY POINT---*/
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Init View
            View.View.Instance.winPassRef(this);

            //DB querys for stocks displays
            InitializeDB.Food_Stock();
            InitializeDB.Dish_Stock();
            InitializeDB.Textil_Stock();
            InitializeDB.Utensil_Stock();
            starterOfTheDay = motd.ofTheDay("Entrée");
            Starter.Text = starterOfTheDay.Name;
            plateOfTheDay = motd.ofTheDay("Plat");
            Plate.Text = plateOfTheDay.Name;
            dessertOfTheDay = motd.ofTheDay("Dessert");
            Dessert.Text = dessertOfTheDay.Name;

            //CUISINE (launch server socket)
            Console.WriteLine("Création du socket server (cuisine) :");
            sockServerCuisine = new Thread(new ThreadStart(CuisineController.Instance.ServerSockLaunch));
            sockServerCuisine.Start();

            //SALLE
            SalleController.Instance.CriateMi();
        }
        /*-----------------*/


        /*---IHM ACTIONS EVENTS---*/
        private void ButtonStockTextil_Click(object sender, RoutedEventArgs e)
        {
            DisplayStock disp = new DisplayStock("Textil");
            disp.Show();
        }

        private void ButtonStockDish_Click(object sender, RoutedEventArgs e)
        {
            DisplayStock disp = new DisplayStock("Dish");
            disp.Show();
        }

        private void ButtonStockUtensil_Click(object sender, RoutedEventArgs e)
        {
            DisplayStock disp = new DisplayStock("Utensil");
            disp.Show();
        }

        private void ButtonStockFood_Click(object sender, RoutedEventArgs e)
        {
            DisplayStock disp = new DisplayStock("Food");
            disp.Show();
        }

    }
}
