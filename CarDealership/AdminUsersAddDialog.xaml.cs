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
using System.Drawing;
using System.Windows.Media.Media3D;

namespace CarDealership
{
    /// <summary>
    /// Логика взаимодействия для AdminUsersAddDialog.xaml
    /// </summary>
    public partial class AdminUsersAddDialog : Window
    {
        private AdminUsers adminUsersWindow;

        public AdminUsersAddDialog(AdminUsers adminUsersWindow)
        {
            InitializeComponent();
            DataloadHelper.LoadUserLabel(FILabel);
            LoadCB();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.adminUsersWindow = adminUsersWindow;
        }

        private void LoadCB()
        {
            using (var context = new user100_dbEntities())
            {
                var prestige = context.iiPrestige.ToList();

                PrestigeCB.ItemsSource = prestige;
                PrestigeCB.DisplayMemberPath = "name";
                PrestigeCB.SelectedValuePath = "id";

                var roles = context.iiRoles.ToList();

                RoleCB.ItemsSource = roles;
                RoleCB.DisplayMemberPath = "role";
                RoleCB.SelectedValuePath = "id";
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(LastnameTextBox.Text) &&
                !string.IsNullOrEmpty(NameTextBox.Text) &&
                !string.IsNullOrEmpty(PatronymicTextBox.Text) &&
                !string.IsNullOrEmpty(AddressPathTextBox.Text) &&
                !string.IsNullOrEmpty(PhoneTextBox.Text) &&
                !string.IsNullOrEmpty(LoginTextBox.Text) &&
                !string.IsNullOrEmpty(PasswordTextBox.Text) &&
                PrestigeCB.SelectedValue != null &&
                RoleCB.SelectedValue != null)
            {
                using (var context = new user100_dbEntities())
                {
                    var user = new iiUsers
                    {
                        lastname = LastnameTextBox.Text,
                        name = NameTextBox.Text,
                        patronymic = PatronymicTextBox.Text,
                        address = AddressPathTextBox.Text,
                        phone = PhoneTextBox.Text,
                        login = LoginTextBox.Text,
                        password = PasswordTextBox.Text,
                        id_prestige = Convert.ToInt32(PrestigeCB.SelectedValue),
                        id_role = Convert.ToInt32(RoleCB.SelectedValue)
                    };

                    context.iiUsers.Add(user);
                    context.SaveChanges();
                    adminUsersWindow.LoadDataGrid();
                    MessageBox.Show("Пользователь добавлен");
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
