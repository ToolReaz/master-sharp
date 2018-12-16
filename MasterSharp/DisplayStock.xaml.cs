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
using MasterSharp.Model.EDM;

namespace MasterSharp
{
    /// <summary>
    /// Logique d'interaction pour DisplayStock.xaml
    /// </summary>
    public partial class DisplayStock : Window
    {
        string stockType;

        public DisplayStock(string stockType)
        {
            InitializeComponent();
            this.stockType = stockType;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<dynamic> stock;

            if (stockType == "Food") {
                stock = CuisineController.Instance.GetFoodStock();
            }
            else if (stockType == "Dish")
            {
                stock = CuisineController.Instance.GetDishStock();
            }
            else if (stockType == "Textil")
            {
                stock = CuisineController.Instance.GetTextilStock();
            }
            else if (stockType == "Utensil")
            {
                stock = CuisineController.Instance.GetUtensilStock();
            }
            else
            {
                stock = null;
            }
            
            DataGridViewStock.AutoGenerateColumns = true;
            DataGridViewStock.ItemsSource = stock;
        }
    }
}
