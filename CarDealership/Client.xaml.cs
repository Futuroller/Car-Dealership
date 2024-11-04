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
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Window
    {
        public Client()
        {
            InitializeComponent();
            DataloadHelper.LoadUserLabel(FILabel);
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void CarsBtn_Click(object sender, RoutedEventArgs e)
        {
            var form = new ClientCars();
            form.Show();
            this.Hide();
        }

        private void OrdersHistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new user100_dbEntities())
            {
                var client = context.iiUsers.FirstOrDefault(u => u.id == MainWindow.UserID);
                var form = new ClientOrdersHistory(client);
                form.Show();
                this.Hide();
            }
                
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var form = new MainWindow();
            form.Show();
            this.Hide();
        }
    }
}
