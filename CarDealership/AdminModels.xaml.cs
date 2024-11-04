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
    /// Логика взаимодействия для AdminModels.xaml
    /// </summary>
    public partial class AdminModels : Page
    {
        public int SelectedID = 0;

        public AdminModels()
        {
            InitializeComponent();
            LoadDataGrid();
        }
        public void LoadDataGrid()
        {
            using (var context = new user100_dbEntities())
            {
                var models = context.iiModels
                    .Include(m => m.iiMakes).ToList();

                var modelsFormatted = models
                    .Select(m => new
                    {
                        m.id,
                        m.model,
                        m.year,
                        Make = m.iiMakes.make
                    }).ToList();

                ModelsDataGrid.ItemsSource = modelsFormatted;
            }
        }

        private void ModelsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ModelsDataGrid.SelectedItem != null)
            {
                // Пытаемся получить значение id из первой колонки
                var selectedRow = (dynamic)ModelsDataGrid.SelectedItem;
                SelectedID = selectedRow.id;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedID != 0)
            {
                using (var context = new user100_dbEntities())
                {
                    var selectedModel = context.iiModels.FirstOrDefault(m => m.id == SelectedID);
                    var relatedCars = context.iiCars.Where(c => c.id_model == SelectedID).ToList();

                    foreach (var car in relatedCars)
                    {
                        // Удаляем все заказы, связанные с каждым автомобилем
                        var relatedOrders = context.iiOrders.Where(o => o.id_car == car.id).ToList();
                        context.iiOrders.RemoveRange(relatedOrders);
                    }

                    context.iiCars.RemoveRange(relatedCars);
                    context.iiModels.Remove(selectedModel);
                    context.SaveChanges();
                    LoadDataGrid();
                    MessageBox.Show("Запись удалена");
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedID != 0)
            {
                using (var context = new user100_dbEntities())
                {
                    var selectedModel = context.iiModels.FirstOrDefault(m => m.id == SelectedID);

                    var changeDialog = new AdminModelsChangeDialog(selectedModel, this);
                    changeDialog.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для изменения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var form = new AdminModelsAddDialog(this);
            form.ShowDialog();
        }
    }
}
