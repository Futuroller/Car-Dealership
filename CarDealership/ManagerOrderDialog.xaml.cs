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
    /// Логика взаимодействия для ManagerOrderDialog.xaml
    /// </summary>
    public partial class ManagerOrderDialog : Window
    {
        private ManagerOrders managerOrdersWindow;

        public ManagerOrderDialog(ManagerOrders managerOrdersWindow)
        {
            InitializeComponent();
            LoadCB();
            DataloadHelper.LoadUserLabel(FILabel);
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.managerOrdersWindow = managerOrdersWindow;
        }

        private void LoadCB()
        {
            using (var context = new user100_dbEntities())
            {
                var cars = context.iiCars
                    .Include(c => c.iiModels)
                    .Include(c => c.iiModels.iiMakes)
                    .Where(c => c.id_status == 1)
                    .Select(c => new
                    {
                        c.id,
                        Make = c.iiModels.iiMakes.make,
                        Model = c.iiModels.model,
                        Year = c.iiModels.year,
                        Color = c.iiColors.color
                    })
                    .ToList();
                var carsFormatted = cars.Select(c => new
                {
                    c.id,
                    Title = $"{c.Make} {c.Model} {c.Year} {c.Color}"
                }).ToList();

                CarCB.ItemsSource = carsFormatted;
                CarCB.DisplayMemberPath = "Title";
                CarCB.SelectedValuePath = "id";


                var clients = context.iiUsers
                    .Include(c => c.iiRoles)
                    .Where(c => c.id_role == 3)
                    .Select(c => new
                    {
                        c.id,
                        c.lastname,
                        c.name,
                        c.patronymic
                    })
                    .ToList();

                var clientsFormatted = clients.Select(c => new
                {
                    c.id,
                    Fullname = $"{c.lastname} {c.name} {c.patronymic}",
                }).ToList();

                ClientCB.ItemsSource = clientsFormatted;
                ClientCB.DisplayMemberPath = "Fullname";
                ClientCB.SelectedValuePath = "id";
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (CarCB.SelectedItem != null &&
                ClientCB.SelectedItem != null)
            {
                using (var context = new user100_dbEntities())
                {
                    int selectedCarId = (int)CarCB.SelectedValue;
                    int selectedClientId = (int)ClientCB.SelectedValue;

                    var car = context.iiCars.FirstOrDefault(c => c.id == selectedCarId);
                    var client = context.iiUsers.FirstOrDefault(u => u.id == selectedClientId);

                    double finalPrice = car.price;

                    if (client.id_prestige == 2)
                    {
                        finalPrice = finalPrice * 0.95;
                    }

                    var order = new iiOrders
                    {
                        order_date = DateTime.Now,
                        price = (int)finalPrice,
                        id_car = selectedCarId,
                        id_status = 1,
                        id_client = selectedClientId,
                        id_manager = MainWindow.UserID
                    };

                    car.id_status = 2;

                    context.iiOrders.Add(order);
                    context.SaveChanges();
                    managerOrdersWindow.LoadDataGrid();
                    MessageBox.Show("Заказ добавлен");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Заполните оба поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
