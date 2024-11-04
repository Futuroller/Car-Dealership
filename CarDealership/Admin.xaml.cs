using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarDealership
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            MakesRB.IsChecked = true;
            LoadPage(); 
            DataloadHelper.LoadUserLabel(FILabel);
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void LoadPage()
        {
            if (MakesRB.IsChecked == true)
            {
                MainFrame.Navigate(new AdminMakes());
            }
            else if (ModelsRB.IsChecked == true)
            {
                MainFrame.Navigate(new AdminModels());
            }
            else if (ColorsRB.IsChecked == true)
            {
                MainFrame.Navigate(new AdminColors());
            }
            else if (CarsRB.IsChecked == true)
            {
                MainFrame.Navigate(new AdminCars());
            }
            else if (OrdersRB.IsChecked == true)
            {
                MainFrame.Navigate(new AdminOrders());
            }
            else if (UsersRB.IsChecked == true)
            {
                MainFrame.Navigate(new AdminUsers());
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var form = new MainWindow();
            form.Show();
            this.Hide();
        }

        private void AnyRB_Checked(object sender, RoutedEventArgs e)
        {
            LoadPage();
        }
    }
}
