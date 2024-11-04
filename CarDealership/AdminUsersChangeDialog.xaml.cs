using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

namespace CarDealership
{
    /// <summary>
    /// Логика взаимодействия для AdminUsersChangeDialog.xaml
    /// </summary>
    public partial class AdminUsersChangeDialog : Window
    {
        iiUsers selectedUser;
        private AdminUsers adminUsersWindow;
        public AdminUsersChangeDialog(iiUsers user, AdminUsers adminUsersWindow)
        {
            InitializeComponent();
            selectedUser = user;
            LoadCB();
            LoadData(user);
            DataloadHelper.LoadUserLabel(FILabel);
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

        private void LoadData(iiUsers user)
        {
            LastnameTextBox.Text = user.lastname;
            NameTextBox.Text = user.name;
            PatronymicTextBox.Text = user.patronymic;
            AddressPathTextBox.Text = user.address;
            PhoneTextBox.Text = Convert.ToString(user.phone);
            LoginTextBox.Text = user.login;
            PasswordTextBox.Text = user.password;
            PrestigeCB.SelectedValue = user.id_prestige;
            RoleCB.SelectedValue = user.id_role;
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
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
                    var user = context.iiUsers.FirstOrDefault(c => c.id == selectedUser.id);
                    user.lastname = LastnameTextBox.Text;
                    user.name = NameTextBox.Text;
                    user.patronymic = PatronymicTextBox.Text;
                    user.address = AddressPathTextBox.Text;
                    user.phone = PhoneTextBox.Text;
                    user.login = LoginTextBox.Text;
                    user.password = PasswordTextBox.Text;
                    user.id_prestige = Convert.ToInt32(PrestigeCB.SelectedValue);
                    user.id_role = Convert.ToInt32(RoleCB.SelectedValue);

                    context.SaveChanges();
                }
                // Обновляем DataGrid в ManagerOrders
                adminUsersWindow.LoadDataGrid();
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
