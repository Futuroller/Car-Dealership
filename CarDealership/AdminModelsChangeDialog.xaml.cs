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
    /// Логика взаимодействия для AdminModelsChangeDialog.xaml
    /// </summary>
    public partial class AdminModelsChangeDialog : Window
    {
        iiModels selectedModel;
        private AdminModels adminModelsPage; // Ссылка на окно ManagerOrders
        public AdminModelsChangeDialog(iiModels model, AdminModels adminModelsPage)
        {
            InitializeComponent();
            selectedModel = model;
            LoadCB();
            LoadData(model);
            DataloadHelper.LoadUserLabel(FILabel);
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.adminModelsPage = adminModelsPage;
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

        private void LoadData(iiModels model)
        {
            ModelTextBox.Text = Convert.ToString(model.model);
            YearTextBox.Text = Convert.ToString(model.year);
            MakesCB.SelectedValue = model.id_make;
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ModelTextBox.Text) &&
                !string.IsNullOrEmpty(YearTextBox.Text) &&
                MakesCB.SelectedValue != null)
            {
                using (var context = new user100_dbEntities())
                {
                    var model = context.iiModels.FirstOrDefault(m => m.id == selectedModel.id);
                    model.model = ModelTextBox.Text;
                    model.year = Convert.ToInt32(YearTextBox.Text);
                    model.id_make = Convert.ToInt32(MakesCB.SelectedValue);
                    context.SaveChanges();
                }

                // Обновляем DataGrid в ManagerOrders
                adminModelsPage.LoadDataGrid();
                MessageBox.Show("Данные изменены");

                this.Close();
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
