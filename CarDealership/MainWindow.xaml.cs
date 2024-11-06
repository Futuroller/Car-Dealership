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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int UserID;
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void IHaveNoAccountLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var form = new Registration();
            form.Show();
            this.Hide();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Password;

            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {

                using (var context = new user100_dbEntities())
                {
                    var user = context.iiUsers.Include(u => u.iiRoles).FirstOrDefault(u => u.login == login && u.password == password);

                    if (user != null)
                    {
                        UserID = user.id;
                        if (user.iiRoles.role == "admin")
                        {
                            var form = new Admin();
                            form.Show();
                            this.Hide();
                        }
                        else if (user.iiRoles.role == "soldmanager")
                        {
                            var form = new Manager();
                            form.Show();
                            this.Hide();
                        }
                        else
                        {
                            var form = new Client();
                            form.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
            } 
            else
            {
                MessageBox.Show("Заполните оба поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
