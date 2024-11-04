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

namespace CarDealership
{
    /// <summary>
    /// Логика взаимодействия для AdminModelsAddDialog.xaml
    /// </summary>
    public partial class AdminModelsAddDialog : Window
    {
        private AdminModels adminModelsWindow;

        public AdminModelsAddDialog(AdminModels adminModelsWindow)
        {
            InitializeComponent();
            DataloadHelper.LoadUserLabel(FILabel);
            LoadCB();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.adminModelsWindow = adminModelsWindow;
        }

        private void LoadCB()
        {
            using (var context = new user100_dbEntities())
            {
                var makes = context.iiMakes
                    .Include(m => m.iiModels)
                    .Select(m => new
                    {
                        m.id,
                        m.make
                    })
                    .ToList();

                MakesCB.ItemsSource = makes;
                MakesCB.DisplayMemberPath = "make";
                MakesCB.SelectedValuePath = "id";
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ModelTextBox.Text) &&
                !string.IsNullOrEmpty(YearTextBox.Text) &&
                MakesCB.SelectedValue != null)
            {
                using (var context = new user100_dbEntities())
                {
                    var model = new iiModels
                    {
                        model = ModelTextBox.Text,
                        year = Convert.ToInt32(YearTextBox.Text),
                        id_make = Convert.ToInt32(MakesCB.SelectedValue)
                    };

                    context.iiModels.Add(model);
                    context.SaveChanges();
                    adminModelsWindow.LoadDataGrid();
                    MessageBox.Show("Модель добавлена");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void YearTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
