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
    /// Логика взаимодействия для ManagerChangeClientDialog.xaml
    /// </summary>
    public partial class ManagerChangeClientDialog : Window
    {
        iiUsers selectedUser;
        private ManagerClients managerClientWindow; // Ссылка на окно ManagerOrders
        public ManagerChangeClientDialog(iiUsers user, ManagerClients managerClientWindow)
        {
            InitializeComponent();
            selectedUser = user;
            LoadUserData(user);
            DataloadHelper.LoadUserLabel(FILabel);
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.managerClientWindow = managerClientWindow;
        }

        private void LoadUserData(iiUsers user)
        {
            AddressTextBox.Text = Convert.ToString(user.address);
            PhoneTextBox.Text = Convert.ToString(user.phone);
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(AddressTextBox.Text) &&
                !string.IsNullOrEmpty(PhoneTextBox.Text))
            {
                using (var context = new user100_dbEntities())
                {
                    var user = context.iiUsers.FirstOrDefault(u => u.id == selectedUser.id);
                    user.address = AddressTextBox.Text;
                    user.phone = PhoneTextBox.Text;
                    context.SaveChanges();
                }

                managerClientWindow.LoadDataGrid();
                MessageBox.Show("Данные изменены");

                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PhoneTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
