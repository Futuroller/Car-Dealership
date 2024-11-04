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
    /// Логика взаимодействия для AdminColorsAddDialog.xaml
    /// </summary>
    public partial class AdminColorsAddDialog : Window
    {
        private AdminColors adminColorsWindow;

        public AdminColorsAddDialog(AdminColors adminColorsWindow)
        {
            InitializeComponent();
            DataloadHelper.LoadUserLabel(FILabel);
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.adminColorsWindow = adminColorsWindow;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ColorTextBox.Text))
            {
                using (var context = new user100_dbEntities())
                {
                    var color = new iiColors
                    {
                        color = ColorTextBox.Text
                    };

                    context.iiColors.Add(color);
                    context.SaveChanges();
                    adminColorsWindow.LoadDataGrid();
                    MessageBox.Show("Цвет добавлен");
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
