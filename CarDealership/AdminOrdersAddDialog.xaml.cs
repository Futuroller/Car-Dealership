using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Data.Entity;

namespace CarDealership
{
    /// <summary>
    /// Логика взаимодействия для AdminOrdersAddDialog.xaml
    /// </summary>
    public partial class AdminOrdersAddDialog : Window
    {
        private AdminOrders adminOrdersWindow;

        public AdminOrdersAddDialog(AdminOrders adminOrdersWindow)
        {
            InitializeComponent();
            DataloadHelper.LoadUserLabel(FILabel);
            LoadCB();
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

        private void AddButton_Click(object sender, RoutedEventArgs e)
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
                    var order = new iiOrders
                    {
                        order_date = (DateTime)DateDP.SelectedDate,
                        price = Convert.ToInt32(PriceTextBox.Text),
                        id_car = Convert.ToInt32(CarCB.SelectedValue),
                        id_status = Convert.ToInt32(StatusCB.SelectedValue),
                        id_client = Convert.ToInt32(ClientCB.SelectedValue),
                        id_manager = Convert.ToInt32(ManagerCB.SelectedValue)
                    };

                    context.iiOrders.Add(order);
                    context.SaveChanges();
                    adminOrdersWindow.LoadDataGrid();
                    MessageBox.Show("Заказ добавлен");
                    this.Close();
                }
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
