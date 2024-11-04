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
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace CarDealership
{
    /// <summary>
    /// Логика взаимодействия для AdminOrdersChangeDialog.xaml
    /// </summary>
    public partial class AdminOrdersChangeDialog : Window
    {
        iiOrders selectedOrder;
        private AdminOrders adminOrdersWindow;

        public AdminOrdersChangeDialog(iiOrders order, AdminOrders adminOrdersWindow)
        {
            InitializeComponent();
            selectedOrder = order;
            LoadCB();
            LoadData(order);
            DataloadHelper.LoadUserLabel(FILabel);
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.adminOrdersWindow = adminOrdersWindow;
        }

        private void LoadCB()
        {
            using (var context = new user100_dbEntities())
            {
                var cars = context.iiCars
                    .Include(c => c.iiModels)
                    .Include(c => c.iiColors)
                    .Include(c => c.iiModels.iiMakes)
                    .ToList();

                var carsFormatted = cars
                    .Select(c => new
                    {
                        c.id,
                        FullCar = $"{c.iiModels.iiMakes.make} {c.iiModels.model} {c.iiModels.year} {c.iiColors.color}"
                    })
                    .ToList();

                CarCB.ItemsSource = carsFormatted;
                CarCB.DisplayMemberPath = "FullCar";
                CarCB.SelectedValuePath = "id";

                var statuses = context.iiStatus_order
                    .Select(s => new
                    {
                        s.id,
                        s.status
                    })
                    .ToList();

                StatusCB.ItemsSource = statuses;
                StatusCB.DisplayMemberPath = "status";
                StatusCB.SelectedValuePath = "id";

                var clients = context.iiUsers
                    .Where(c => c.id_role == 3)
                    .ToList();

                var clientsFormatted = clients
                    .Select(c => new
                    {
                        c.id,
                        FullName = $"{c.lastname} {c.name} {c.patronymic}"
                    })
                    .ToList();

                ClientCB.ItemsSource = clientsFormatted;
                ClientCB.DisplayMemberPath = "FullName";
                ClientCB.SelectedValuePath = "id";

                var managers = context.iiUsers
                    .Where(c => c.id_role == 2)
                    .ToList();

                var managersFormatted = managers
                    .Select(c => new
                    {
                        c.id,
                        FullName = $"{c.lastname} {c.name} {c.patronymic}"
                    })
                    .ToList();

                ManagerCB.ItemsSource = managersFormatted;
                ManagerCB.DisplayMemberPath = "FullName";
                ManagerCB.SelectedValuePath = "id";
            }
        }

        private void LoadData(iiOrders order)
        {
            DateDP.SelectedDate = order.order_date;
            PriceTextBox.Text = Convert.ToString(order.price);
            CarCB.SelectedValue = order.id_car;
            StatusCB.SelectedValue = order.id_status;
            ClientCB.SelectedValue = order.id_client;
            ManagerCB.SelectedValue = order.id_manager;
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (DateDP.SelectedDate != null &&
                 !string.IsNullOrEmpty(PriceTextBox.Text) &&
                 CarCB.SelectedValue != null &&
                 StatusCB.SelectedValue != null &&
                 ClientCB.SelectedValue != null &&
                 ManagerCB.SelectedValue != null)
            {
                using (var context = new user100_dbEntities())
                {
                    var order = context.iiOrders.FirstOrDefault(o => o.id == selectedOrder.id);
                    order.order_date = (DateTime)DateDP.SelectedDate;
                    order.price = Convert.ToInt32(PriceTextBox.Text);
                    order.id_car = Convert.ToInt32(CarCB.SelectedValue);
                    order.id_status = Convert.ToInt32(StatusCB.SelectedValue);
                    order.id_client = Convert.ToInt32(ClientCB.SelectedValue);
                    order.id_manager = Convert.ToInt32(ManagerCB.SelectedValue);
                    context.SaveChanges();
                }

                // Обновляем DataGrid в ManagerOrders
                adminOrdersWindow.LoadDataGrid();
                MessageBox.Show("Данные изменены");

                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void AnyTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c))
                {
                    e.Handled = true; // Если не число, блокируем ввод
                    return;
                }
            }
        }
    }
}
