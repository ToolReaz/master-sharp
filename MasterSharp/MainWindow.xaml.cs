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
using Model.EDM;

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
        CuisineController objCuisine;
        Thread sockClientCuisine;
        SalleController objSalle;
        Thread sockServerSalle;


        public MainWindow()
        {
            //launch server socket (cuisine)
            Console.WriteLine("Création du socket server (cuisine) :");
            objCuisine = new CuisineController();
            sockClientCuisine = new Thread(new ThreadStart(objCuisine.ServerSockLaunch));
            sockClientCuisine.Start();
        }

        private void ButtonStock_Click(object sender, RoutedEventArgs e)
        {
            DisplayStock disp = new DisplayStock();
            disp.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeDB.Food_Stock();
            starterOfTheDay = motd.ofTheDay("Entrée");
            Starter.Text = starterOfTheDay.Name;
            plateOfTheDay = motd.ofTheDay("Plat");
            Plate.Text = plateOfTheDay.Name;
            dessertOfTheDay = motd.ofTheDay("Dessert");
            Dessert.Text = dessertOfTheDay.Name;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            objSalle = new SalleController();

            //Lambda expression with no arguments (threadstart with parameters methods was impossible) :
            sockServerSalle = new Thread(() => objSalle.SalleCommandSend(starterOfTheDay.ID));
            sockServerSalle.Start();
            
            /*objSalle.SalleCommandSend(starterOfTheDay.ID);
            objSalle.SalleCommandSend(plateOfTheDay.ID);
            objSalle.SalleCommandSend(dessertOfTheDay.ID);*/
        }

    }
}
