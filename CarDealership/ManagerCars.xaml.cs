using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
using System.IO;
using Path = System.IO.Path;

namespace CarDealership
{
    /// <summary>
    /// Логика взаимодействия для ManagerCars.xaml
    /// </summary>
    public partial class ManagerCars : Window
    {
        public ManagerCars()
        {
            InitializeComponent();
            DataloadHelper.LoadUserLabel(FILabel);
            LoadCarsData();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void LoadCarsData()
        {
            using (var context = new user100_dbEntities())
            {
                var cars = context.iiCars
                    .Include(c => c.iiModels)
                    .Include(c => c.iiModels.iiMakes)
                    .Include(c => c.iiColors)
                    .Include(c => c.iiStatus_car)
                    .Select(c => new
                    {
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
            var form = new Manager();
            form.Show();
            this.Hide();
        }
    }
}
