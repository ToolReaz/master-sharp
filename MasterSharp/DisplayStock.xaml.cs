using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Controller;
using Model.EDM;

namespace MasterSharp
{
    /// <summary>
    /// Logique d'interaction pour DisplayStock.xaml
    /// </summary>
    public partial class DisplayStock : Window
    {
        public DisplayStock()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CuisineController cuisineSock = new CuisineController();
            var stock = cuisineSock.GetStock();
            DataGridViewStock.AutoGenerateColumns = true;
            DataGridViewStock.ItemsSource = stock;
        }
    }
}
