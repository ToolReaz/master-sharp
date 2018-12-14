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

        //Sockets
        CuisineController objCuisine;
        Thread sockServerCuisine;
        SalleController objSalle;
        Thread sockClientSalle;


        /*---ENTRY POINT---*/
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

            //launch server socket (cuisine)
            Console.WriteLine("Création du socket server (cuisine) :");
            objCuisine = new CuisineController();
            sockServerCuisine = new Thread(new ThreadStart(objCuisine.ServerSockLaunch));
            sockServerCuisine.Start();

            //instanciate salle
            objSalle = new SalleController();

        }

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Lambda expression with no arguments (threadstart with parameters methods was impossible) :
            sockClientSalle = new Thread(() => objSalle.SalleCommandSend(starterOfTheDay.ID));
            sockClientSalle.Start();
            
            /*objSalle.SalleCommandSend(starterOfTheDay.ID);
            objSalle.SalleCommandSend(plateOfTheDay.ID);
            objSalle.SalleCommandSend(dessertOfTheDay.ID);*/
        }

    }
}
