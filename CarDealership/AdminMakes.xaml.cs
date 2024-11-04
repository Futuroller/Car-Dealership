using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// Логика взаимодействия для AdminMakes.xaml
    /// </summary>
    public partial class AdminMakes : Page
    {
        public int SelectedID = 0;

        public AdminMakes()
        {
            InitializeComponent();
            LoadDataGrid();
        }
        public void LoadDataGrid()
        {
            using (var context = new user100_dbEntities())
            {
                var makes = context.iiMakes
                    .Select(m => new
                    {
                        m.id,
                        m.make,
                        m.country
                    }).ToList();

                MakesDataGrid.ItemsSource = makes;
            }
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedID != 0)
            {
                using (var context = new user100_dbEntities())
                {
                    var selectedMake = context.iiMakes.FirstOrDefault(m => m.id == SelectedID);

                    var changeDialog = new AdminMakesChangeDialog(selectedMake, this);
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
            var form = new AdminMakesAddDialog(this);
            form.ShowDialog();
        }

        private void MakesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MakesDataGrid.SelectedItem != null)
            {
                // Пытаемся получить значение id из первой колонки
                var selectedRow = (dynamic)MakesDataGrid.SelectedItem;
                SelectedID = selectedRow.id;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedID != 0)
            {
                using (var context = new user100_dbEntities())
                {
                    var selectedMake = context.iiMakes.FirstOrDefault(m => m.id == SelectedID);
                    var relatedModels = context.iiModels.Where(m => m.id_make == SelectedID).ToList();

                    foreach (var model in relatedModels)
                    {
                        var relatedCars = context.iiCars.Where(c => c.id_model == model.id).ToList();

                        foreach (var car in relatedCars)
                        {
                            var relatedOrders = context.iiOrders.Where(o => o.id_car == car.id).ToList();
                            context.iiOrders.RemoveRange(relatedOrders);
                        }

                        context.iiCars.RemoveRange(relatedCars);
                    }

                    context.iiModels.RemoveRange(relatedModels);
                    context.iiMakes.Remove(selectedMake);
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
    }
}
