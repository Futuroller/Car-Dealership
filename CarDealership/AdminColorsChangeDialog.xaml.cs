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
    /// Логика взаимодействия для AdminColorsChangeDialog.xaml
    /// </summary>
    public partial class AdminColorsChangeDialog : Window
    {
        iiColors selectedColor;
        private AdminColors adminColorPage;
        public AdminColorsChangeDialog(iiColors color, AdminColors adminColorPage)
        {
            InitializeComponent();
            selectedColor = color;
            LoadData(color);
            DataloadHelper.LoadUserLabel(FILabel);
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.adminColorPage = adminColorPage;
        }
        private void LoadData(iiColors color)
        {
            ColorTextBox.Text = Convert.ToString(color.color);
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ColorTextBox.Text))
            {
                using (var context = new user100_dbEntities())
                {
                    var color = context.iiColors.FirstOrDefault(c => c.id == selectedColor.id);
                    color.color = ColorTextBox.Text;
                    context.SaveChanges();
                }

                // Обновляем DataGrid в ManagerOrders
                adminColorPage.LoadDataGrid();
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
