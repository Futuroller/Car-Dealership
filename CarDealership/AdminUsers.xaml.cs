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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace CarDealership
{
    /// <summary>
    /// Логика взаимодействия для AdminUsers.xaml
    /// </summary>
    public partial class AdminUsers : Page
    {
        public int SelectedID = 0;

        public AdminUsers()
        {
            InitializeComponent();
            LoadDataGrid();
        }

        public void LoadDataGrid()
        {
            using (var context = new user100_dbEntities())
            {
                var users = context.iiUsers
                    .Include(u => u.iiPrestige)
                    .Include(u => u.iiRoles)
                    .ToList();

                var usersFormatted = users
                    .Select(u => new
                    {
                        u.id,
                        u.lastname,
                        u.name,
                        u.patronymic,
                        u.address,
                        u.phone,
                        u.login,
                        u.password,
                        Prestige = u.iiPrestige != null ? u.iiPrestige.name : "",
                        Role = u.iiRoles.role
                    }).ToList();

                UsersDataGrid.ItemsSource = usersFormatted;
            }
        }

        private void UsersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem != null)
            {
                // Пытаемся получить значение id из первой колонки
                var selectedRow = (dynamic)UsersDataGrid.SelectedItem;
                SelectedID = selectedRow.id;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var form = new AdminUsersAddDialog(this);
            form.ShowDialog();
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedID != 0)
            {
                using (var context = new user100_dbEntities())
                {
                    var selectedUser = context.iiUsers.FirstOrDefault(u => u.id == SelectedID);

                    var changeDialog = new AdminUsersChangeDialog(selectedUser, this);
                    changeDialog.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для изменения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedID != 0)
            {
                using (var context = new user100_dbEntities())
                {
                    var selectedUser = context.iiUsers.FirstOrDefault(u => u.id == SelectedID);
                    var selectedUserIn = context.iiOrders.Where(o => o.id_client == SelectedID || o.id_manager == SelectedID);

                    context.iiUsers.Remove(selectedUser);
                    if (selectedUserIn != null)
                    {
                        context.iiOrders.RemoveRange(selectedUserIn);
                    }

                    context.SaveChanges();
                    LoadDataGrid();
                    MessageBox.Show("Запись удалена");
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
