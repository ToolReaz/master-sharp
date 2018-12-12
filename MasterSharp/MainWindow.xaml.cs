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

namespace MasterSharp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MenuOfTheDay motd = new MenuOfTheDay();
        Recipe starterOfTheDay,plateOfTheDay,dessertOfTheDay;

        /*---SOCKETS---*/
        SalleController SalleSock;
        Thread SockServer;
        CuisineController CuisineSock;
        Thread SockClient;


        public MainWindow()
        {
            Console.WriteLine("Création des sockets :");
            CuisineSock = new CuisineController();
            SockServer = new Thread(new ThreadStart(CuisineSock.ServerSock));
            SockServer.Start();

            SalleSock = new SalleController();
            SockClient = new Thread(new ThreadStart(SalleSock.ClientSock));
            SockClient.Start();
        }

        private void ButtonStock_Click(object sender, RoutedEventArgs e)
        {
            DisplayStock disp = new DisplayStock();
            disp.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CuisineSock.RecipeTakeStock(starterOfTheDay.ID);
            CuisineSock.RecipeTakeStock(plateOfTheDay.ID);
            CuisineSock.RecipeTakeStock(dessertOfTheDay.ID);
        }

    }
}
