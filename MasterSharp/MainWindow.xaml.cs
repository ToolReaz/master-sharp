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
using Controller;

namespace MasterSharp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MenuOfTheDay motd = new MenuOfTheDay();
        Recipe starterOfTheDay;
        Recipe plateOfTheDay;
        Recipe dessertOfTheDay;

        public MainWindow()
        {
            Console.WriteLine("Création des sockets :");
            CuisineController CuisineSock = new CuisineController();
            Thread SockServer = new Thread(new ThreadStart(CuisineSock.ServerSock));
            SockServer.Start();

            SalleController SalleSock = new SalleController();
            Thread SalleServer = new Thread(new ThreadStart(SalleSock.ClientSock));
            SalleServer.Start();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            starterOfTheDay = motd.ofTheDay("Entrée");
            plateOfTheDay = motd.ofTheDay("Plat");
            dessertOfTheDay = motd.ofTheDay("Dessert");

        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Entrée : "+starterOfTheDay.Name+" \nPlat : "+plateOfTheDay.Name+" \nDessert : "+dessertOfTheDay.Name);
        }
    }
}
