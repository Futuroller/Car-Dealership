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
using System.Data.Entity;

namespace CarDealership
{
    /// <summary>
    /// Логика взаимодействия для ManagerClientsOrdersHistory.xaml
    /// </summary>
    public partial class ManagerClientsOrdersHistory : Window
    {
        public ManagerClientsOrdersHistory(iiUsers client)
        {
            InitializeComponent();
            LoadDataGrid(client);
            DataloadHelper.LoadUserLabel(FILabel);
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

        public void LoadDataGrid(iiUsers client)
        {
            using (var context = new user100_dbEntities())
            {
                var orders = context.iiOrders
                    .Include(o => o.iiCars)
                    .Include(o => o.iiCars.iiModels)
                    .Include(o => o.iiCars.iiModels.iiMakes)
                    .Include(o => o.iiStatus_order)
                    .Include(o => o.iiUsers)
                    .Where(c => c.id_client == client.id)
                    .ToList();
                var customOrders = orders.Select(o => new
                {
                    o.id,
                    o.order_date,
                    o.price,
                    Car = $"{o.iiCars.iiModels.iiMakes.make} {o.iiCars.iiModels.model} {o.iiCars.iiModels.year}",
                    Status = o.iiStatus_order.status,
                    Client = $"{o.iiUsers1.lastname} {o.iiUsers1.name} {o.iiUsers1.patronymic}",
                    Manager = $"{o.iiUsers.lastname} {o.iiUsers.name} {o.iiUsers.patronymic}",
                }).ToList();

                OrderDataGrid.ItemsSource = customOrders;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var form = new ManagerClients();
            form.Show();
            this.Hide();
        }
    }
}
