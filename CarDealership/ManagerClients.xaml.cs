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
    /// Логика взаимодействия для ManagerClients.xaml
    /// </summary>
    public partial class ManagerClients : Window
    {
        public int ClientID = 0;
        public ManagerClients()
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
                var users = context.iiUsers
                    .Include(u => u.iiPrestige)
                    .Include(u => u.iiRoles)
                    .Include(u => u.iiOrders)
                    .Where(u => u.id_role == 3)
                    .ToList();

                var customUsers = users.Select(o => new
                {
                    o.id,
                    o.lastname,
                    o.name,
                    o.patronymic,
                    o.address,
                    o.phone,
                    o.login,
                    o.password,
                    Prestige = o.iiPrestige.name,
                    Role = o.iiRoles.role,
                }).ToList();

                ClientsDataGrid.ItemsSource = customUsers;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var form = new Manager();
            form.Show();
            this.Hide();
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClientID != 0)
            {
                using (var context = new user100_dbEntities())
                {
                    var selectedClient = context.iiUsers.FirstOrDefault(u => u.id == ClientID);

                    var changeClientDialog = new ManagerChangeClientDialog(selectedClient, this);
                    changeClientDialog.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Выберите клиента для изменения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClientsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClientsDataGrid.SelectedItem != null)
            {
                // Пытаемся получить значение id из первой колонки
                var selectedRow = (dynamic)ClientsDataGrid.SelectedItem;
                ClientID = selectedRow.id;
            }
        }
        private void OrdersHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClientID != 0)
            {
                using (var context = new user100_dbEntities())
                {
                    var selectedClient = context.iiUsers.FirstOrDefault(u => u.id == ClientID);

                    var form = new ManagerClientsOrdersHistory(selectedClient);
                    form.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Выберите клиента для просмотра истории заказов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
