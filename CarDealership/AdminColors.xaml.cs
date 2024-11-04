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
    /// Логика взаимодействия для AdminColors.xaml
    /// </summary>
    public partial class AdminColors : Page
    {
        public int SelectedID = 0;

        public AdminColors()
        {
            InitializeComponent();
            LoadDataGrid();
        }
        public void LoadDataGrid()
        {
            using (var context = new user100_dbEntities())
            {
                var colors = context.iiColors.ToList();

                ColorsDataGrid.ItemsSource = colors;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var form = new AdminColorsAddDialog(this);
            form.ShowDialog();
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedID != 0)
            {
                using (var context = new user100_dbEntities())
                {
                    var selectedColor = context.iiColors.FirstOrDefault(c => c.id == SelectedID);

                    var changeDialog = new AdminColorsChangeDialog(selectedColor, this);
                    changeDialog.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для изменения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedID != 0)
            {
                using (var context = new user100_dbEntities())
                {
                    var selectedColor = context.iiColors.FirstOrDefault(m => m.id == SelectedID);
                    var relatedCars = context.iiCars.Where(c => c.id_color == SelectedID).ToList();

                    foreach (var car in relatedCars)
                    {
                        // Удаляем все заказы, связанные с каждым автомобилем
                        var relatedOrders = context.iiOrders.Where(o => o.id_car == car.id).ToList();
                        context.iiOrders.RemoveRange(relatedOrders);
                    }

                    context.iiCars.RemoveRange(relatedCars);
                    context.iiColors.Remove(selectedColor);

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

        private void ColorsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ColorsDataGrid.SelectedItem != null)
            {
                // Пытаемся получить значение id из первой колонки
                var selectedRow = (dynamic)ColorsDataGrid.SelectedItem;
                try
                {
                    SelectedID = selectedRow.id;

                }
                catch
                {

                }
            }
        }
    }
}
