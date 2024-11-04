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
    /// Логика взаимодействия для AdminCars.xaml
    /// </summary>
    public partial class AdminCars : Page
    {
        public int SelectedID = 0;

        public AdminCars()
        {
            InitializeComponent();
            LoadDataGrid();
        }

        public void LoadDataGrid()
        {
            using (var context = new user100_dbEntities())
            {
                var cars = context.iiCars
                    .Include(c => c.iiColors)
                    .Include(c => c.iiModels)
                    .Include(c => c.iiModels.iiMakes)
                    .Include(c => c.iiStatus_car)
                    .ToList();

                var carsFormatted = cars
                    .Select(m => new
                    {
                        m.id,
                        m.vin,
                        m.mileage,
                        m.price,
                        m.photo_path,
                        Color = m.iiColors.color,
                        CarInfo = $"{m.iiModels.iiMakes.make} {m.iiModels.model} {m.iiModels.year}",
                        Status = m.iiStatus_car.status
                    }).ToList();

                CarsDataGrid.ItemsSource = carsFormatted;
            }
        }

        private void CarsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CarsDataGrid.SelectedItem != null)
            {
                // Пытаемся получить значение id из первой колонки
                var selectedRow = (dynamic)CarsDataGrid.SelectedItem;
                SelectedID = selectedRow.id;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var form = new AdminCarsAddDialog(this);
            form.ShowDialog();
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedID != 0)
            {
                using (var context = new user100_dbEntities())
                {
                    var selectedCar = context.iiCars.FirstOrDefault(c => c.id == SelectedID);

                    var changeDialog = new AdminCarsChangeDialog(selectedCar, this);
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
                    var selectedCar = context.iiCars.FirstOrDefault(c => c.id == SelectedID);
                    var selectedCarIn = context.iiOrders.Where(o => o.id_car == SelectedID);

                    context.iiCars.Remove(selectedCar);
                    if (selectedCarIn != null)
                    {
                        context.iiOrders.RemoveRange(selectedCarIn);
                    }

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
