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
using System.Data;

namespace CarDealership
{
    /// <summary>
    /// Логика взаимодействия для ManagerOrders.xaml
    /// </summary>
    public partial class ManagerOrders : Window
    {
        public int OrderID = 0;
        public ManagerOrders()
        {
            InitializeComponent();
            LoadDataGrid();
            DataloadHelper.LoadUserLabel(FILabel);
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

        public void LoadDataGrid()
        {
            using (var context = new user100_dbEntities())
            {
                var orders = context.iiOrders
                    .Include(o => o.iiCars)
                    .Include(o => o.iiCars.iiModels)
                    .Include(o => o.iiCars.iiModels.iiMakes)
                    .Include(o => o.iiStatus_order)
                    .Include(o => o.iiUsers)
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
            var form = new Manager();
            form.Show();
            this.Hide();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var form = new ManagerOrderDialog(this);
            form.ShowDialog();
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrderID != 0)
            {
                using (var context = new user100_dbEntities())
                {
                    var selectedOrder = context.iiOrders.FirstOrDefault(o => o.id == OrderID);

                    var changeOrderDialog = new ManagerChangeOrderDialog(selectedOrder, this);
                    changeOrderDialog.ShowDialog();
                }                    
            }
            else
            {
                MessageBox.Show("Выберите заказ для изменения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrderID != 0)
            {
                using (var context = new user100_dbEntities())
                {
                    var selectedOrder = context.iiOrders.FirstOrDefault(o => o.id == OrderID);

                    selectedOrder.id_status = 3; // На статус завершён
                    context.SaveChanges();
                }
                MessageBox.Show("Заказ закрыт");
                LoadDataGrid();
            }
            else
            {
                MessageBox.Show("Выберите заказ для изменения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OrderDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrderDataGrid.SelectedItem != null)
            {
                // Пытаемся получить значение id из первой колонки
                var selectedRow = (dynamic)OrderDataGrid.SelectedItem;
                OrderID = selectedRow.id;
            }
        }
    }
}
