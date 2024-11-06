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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(LastnameTextBox.Text) &&
                !string.IsNullOrEmpty(NameTextBox.Text) &&
                !string.IsNullOrEmpty(PatronymicTextBox.Text) &&
                !string.IsNullOrEmpty(AddressPathTextBox.Text) &&
                !string.IsNullOrEmpty(PhoneTextBox.Text) &&
                !string.IsNullOrEmpty(LoginTextBox.Text) &&
                !string.IsNullOrEmpty(PasswordTextBox.Password) &&
                !string.IsNullOrEmpty(RepeatPasswordTextBox.Password))
            {
                if (PasswordTextBox.Password == RepeatPasswordTextBox.Password)
                {
                    using (var context = new user100_dbEntities())
                    {
                        var currentLogin = context.iiUsers.FirstOrDefault(u => u.login == LoginTextBox.Text.Trim());

                        if (currentLogin == null)
                        {
                            if (PhoneTextBox.Text.Length == 11)
                            {
                                if (PasswordTextBox.Password.Length >= 8)
                                {
                                    var user = new iiUsers
                                    {
                                        lastname = LastnameTextBox.Text,
                                        name = NameTextBox.Text,
                                        patronymic = PatronymicTextBox.Text,
                                        address = AddressPathTextBox.Text,
                                        phone = PhoneTextBox.Text,
                                        login = LoginTextBox.Text,
                                        password = PasswordTextBox.Password,
                                        id_prestige = 1,
                                        id_role = 3
                                    };

                                    context.iiUsers.Add(user);
                                    context.SaveChanges();
                                    MessageBox.Show("Вы успешно зарегистрировались");
                                    var form = new MainWindow();
                                    form.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Пароль должен состоять минимум из 8-ми символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Номер телефона должен состоять из 11 цифр", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Логин занят", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BlockLettersTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void BlockNumsTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (char.IsDigit(c))
                {
                    e.Handled = true; // Если не число, блокируем ввод
                    return;
                }
            }
        }

        private void IHaveAccountLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var form = new MainWindow();
            form.Show();
            this.Hide();
        }
    }
}
