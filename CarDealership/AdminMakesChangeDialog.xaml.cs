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
    /// Логика взаимодействия для AdminMakesChangeDialog.xaml
    /// </summary>
    public partial class AdminMakesChangeDialog : Window
    {
        iiMakes selectedMake;
        private AdminMakes adminMakesPage; // Ссылка на окно ManagerOrders
        public AdminMakesChangeDialog(iiMakes make, AdminMakes adminMakesPage)
        {
            InitializeComponent();
            selectedMake = make;
            LoadData(make);
            DataloadHelper.LoadUserLabel(FILabel);
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.adminMakesPage = adminMakesPage;
        }

        private void LoadData(iiMakes make)
        {
            MakeTextBox.Text = Convert.ToString(make.make);
            CountryTextBox.Text = Convert.ToString(make.country);
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(MakeTextBox.Text) &&
                !string.IsNullOrEmpty(CountryTextBox.Text))
            {
                using (var context = new user100_dbEntities())
                {
                    var make = context.iiMakes.FirstOrDefault(m => m.id == selectedMake.id);
                    make.make = MakeTextBox.Text;
                    make.country = CountryTextBox.Text;
                    context.SaveChanges();
                }

                // Обновляем DataGrid в ManagerOrders
                adminMakesPage.LoadDataGrid();
                MessageBox.Show("Данные изменены");

                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
