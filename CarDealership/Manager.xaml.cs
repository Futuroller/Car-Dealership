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
    /// Логика взаимодействия для Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        public Manager()
        {
            InitializeComponent();
            DataloadHelper.LoadUserLabel(FILabel);
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void OrdersBtn_Click(object sender, RoutedEventArgs e)
        {
            var form = new ManagerOrders();
            form.Show();
            this.Hide();
        }

        private void PopularMakesBtn_Click(object sender, RoutedEventArgs e)
        {
            var form = new ManagerPopularModels();
            form.Show();
            this.Hide();
        }

        private void ClientsBtn_Click(object sender, RoutedEventArgs e)
        {
            var form = new ManagerClients();
            form.Show();
            this.Hide();
        }

        private void CarsBtn_Click(object sender, RoutedEventArgs e)
        {
            var form = new ManagerCars();
            form.Show();
            this.Hide();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var form = new MainWindow();
            form.Show();
            this.Hide();
        }

        private void PopularModelsBtn_Click(object sender, RoutedEventArgs e)
        {
            var form = new ManagerPopularModels();
            form.Show();
            this.Hide();
        }
    }
}
