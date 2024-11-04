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
using Path = System.IO.Path;
using System.Runtime.Remoting.Contexts;

namespace CarDealership
{
    /// <summary>
    /// Логика взаимодействия для ClientCars.xaml
    /// </summary>
    public partial class ClientCars : Window
    {
        public int SelectedID = 0;

        public ClientCars()
        {
            InitializeComponent();
            DataloadHelper.LoadUserLabel(FILabel);
            LoadCarsData();
            LoadCB();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void LoadCB()
        {
            using (var context = new user100_dbEntities())
            {
                var makes = context.iiMakes.ToList();
                makes.Add(new iiMakes
                {
                    make = "все",
                    country = "Россия"
                });

                MakesCB.ItemsSource = makes;
                MakesCB.DisplayMemberPath = "make";
                MakesCB.SelectedValuePath = "id";

                var colors = context.iiColors.ToList();
                colors.Add(new iiColors
                {
                    color = "все"
                });

                ColorsCB.ItemsSource = colors;
                ColorsCB.DisplayMemberPath = "color";
                ColorsCB.SelectedValuePath = "id";
            }
        }

        public void LoadCarsData()
        {
            using (var context = new user100_dbEntities())
            {
                var selectedMake = MakesCB.SelectedItem as iiMakes;
                var selectedColor = ColorsCB.SelectedItem as iiColors;
                string selectedPrice= (PriceCB.SelectedItem as ComboBoxItem)?.Content.ToString();

                string searchText = SearchBox.Text?.Trim().ToLower(); // 
                                                                      // Создаем базовый запрос на получение всех клиентов
                var carsQuery = context.iiCars
                    .Include(c => c.iiModels)
                    .Include(c => c.iiModels.iiMakes)
                    .Include(c => c.iiColors)
                    .Include(c => c.iiStatus_car)
                    .Where(c => c.id_status == 1)
                    .AsQueryable();

                if (selectedMake != null && selectedMake.make != "все")
                {
                    carsQuery = carsQuery.Where(c => c.iiModels.iiMakes.make == selectedMake.make);
                }

                if (selectedColor != null && selectedColor.color != "все")
                {
                    carsQuery = carsQuery.Where(c => c.iiColors.color == selectedColor.color);
                }

                if (!string.IsNullOrEmpty(selectedPrice) && selectedPrice != "по умолчанию")
                {
                    if (selectedPrice == "по возрастанию")
                    {
                        carsQuery = carsQuery.OrderBy(c => c.price);
                    }
                    else if (selectedPrice == "по убыванию")
                    {
                        carsQuery = carsQuery.OrderByDescending(c => c.price);
                    }
                }

                if (!string.IsNullOrEmpty(searchText))
                {
                    carsQuery = carsQuery.Where(c =>
                        (c.iiModels.iiMakes.make + " " + c.iiModels.model + " " + c.iiModels.year).ToLower().Contains(searchText));
                }

                var cars = carsQuery
                    .Select(c => new
                    {
                        c.id,
                        c.vin,
                        c.mileage,
                        c.price,
                        c.photo_path,
                        Color = c.iiColors.color,
                        ModelName = c.iiModels.model,
                        ModelYear = c.iiModels.year,
                        ModelMakeName = c.iiModels.iiMakes.make,
                        ModelMakeCountry = c.iiModels.iiMakes.country,
                        Status = c.iiStatus_car.status
                    }).ToList();

                var carsFormated = cars.Select(c => new
                {
                    c.id,
                    vin = "VIN: " + c.vin,
                    mileage = "Пробег: " + c.mileage + "км",
                    price = "Цена: " + c.price + " руб.",
                    photo_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Images", Path.GetFileName(c.photo_path)), // Путь на уровень выше, где находится папка Images
                    Color = "Цвет: " + c.Color,
                    ModelInfo = c.ModelMakeName + " " + c.ModelName + " " + c.ModelYear,
                    ModelMakeCountry = "Страна: " + c.ModelMakeCountry,
                    c.Status
                }).ToList();

                CarsListView.ItemsSource = carsFormated;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var form = new Client();
            form.Show();
            this.Hide();
        }

        private void PriceCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadCarsData();
        }

        private void MakesCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadCarsData();
        }

        private void ColorsCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadCarsData();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadCarsData();
        }

        private void BookCarButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedID != 0)
            {
                using (var context = new user100_dbEntities())
                {
                    var selectedCar = context.iiCars.FirstOrDefault(c => c.id == SelectedID);

                    var changeDialog = new ClientCarBooking(selectedCar, this);
                    changeDialog.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Выберите машину для брони", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CarsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CarsListView.SelectedItem != null)
            {
                var selectedCar = (dynamic)CarsListView.SelectedItem;
                SelectedID = selectedCar.id;
            }
        }
    }
}
