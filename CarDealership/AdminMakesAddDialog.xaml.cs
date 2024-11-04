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
    /// Логика взаимодействия для AdminMakesAddDialog.xaml
    /// </summary>
    public partial class AdminMakesAddDialog : Window
    {
        private AdminMakes adminMakesWindow;

        public AdminMakesAddDialog(AdminMakes adminMakesWindow)
        {
            InitializeComponent();
            DataloadHelper.LoadUserLabel(FILabel);
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.adminMakesWindow = adminMakesWindow;

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(MakeTextBox.Text) &&
                !string.IsNullOrEmpty(CountryTextBox.Text))
            {
                using (var context = new user100_dbEntities())
                {
                    var make = new iiMakes
                    {
                        make = MakeTextBox.Text,
                        country = CountryTextBox.Text
                    };

                    context.iiMakes.Add(make);
                    context.SaveChanges();
                    adminMakesWindow.LoadDataGrid();
                    MessageBox.Show("Марка добавлена");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
