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

namespace CarDealership
{
    /// <summary>
    /// Логика взаимодействия для ClientCarBooking.xaml
    /// </summary>
    public partial class ClientCarBooking : Window
    {
        iiCars selectedCar;
        private ClientCars clientCarsWindow;
        private int FinalPrice;
        public ClientCarBooking(iiCars car, ClientCars clientCarsWindow)
        {
            InitializeComponent();
            selectedCar = car;
            LoadCarsData(car);
            DataloadHelper.LoadUserLabel(FILabel);
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.clientCarsWindow = clientCarsWindow;
        }

        private void LoadCarsData(iiCars car)
        {
            using (var context = new user100_dbEntities())
            {
                var selectedCar = context.iiCars
                    .Include(c => c.iiModels)
                    .Include(c => c.iiModels.iiMakes)
                    .Include(c => c.iiColors)
                    .Include(c => c.iiStatus_car)
                    .FirstOrDefault(c => c.id == car.id);

                MakeLbl.Content = selectedCar.iiModels.iiMakes.make;
                ModelLbl.Content = selectedCar.iiModels.model;
                YearLbl.Content = selectedCar.iiModels.year;
                ColorLbl.Content = selectedCar.iiColors.color;
                MileageLbl.Content = selectedCar.mileage + " км.";

                var user = context.iiUsers.FirstOrDefault(u => u.id == MainWindow.UserID);
                double finalPrice = selectedCar.price;

                if (user.id_prestige == 2)
                {
                    finalPrice *= 0.95;
                }

                FinalPrice = (int)finalPrice;

                PriceLbl.Content = (int)finalPrice + "руб.";
                string photoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Images", Path.GetFileName(selectedCar.photo_path));

                // Создаем объект BitmapImage и устанавливаем его в Source элемента Image
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(photoPath, UriKind.Absolute);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();

                // Устанавливаем полученное изображение в Image элемент
                CarImage.Source = bitmap; // CarImage - это ваш элемент Image
            }
        }

        private int GetRandomManagerId()
        {
            using (var context = new user100_dbEntities())
            {
                // Получаем всех менеджеров (пользователей с id_role = 2)
                var managers = context.iiUsers
                    .Where(u => u.id_role == 2)
                    .Select(u => u.id)
                    .ToList();

                if (managers.Count == 0)
                {
                    throw new InvalidOperationException("Нет доступных менеджеров.");
                }

                // Создаем объект для генерации случайных чисел
                Random random = new Random();
                // Случайно выбираем менеджера из списка
                int randomIndex = random.Next(managers.Count);
                return managers[randomIndex];
            }
        }

        private void BookCarButton_Click(object sender, RoutedEventArgs e)
        {
            if (DateDP.SelectedDate != null)
            {
                if (DateDP.SelectedDate >= DateTime.Now)
                {
                    if (DateDP.SelectedDate < DateTime.Now.AddDays(15))
                    {
                        using (var context = new user100_dbEntities())
                        {
                            var car = context.iiCars
                                .Include(c => c.iiModels)
                                .Include(c => c.iiModels.iiMakes)
                                .Include(c => c.iiColors)
                                .Include(c => c.iiStatus_car)
                                .FirstOrDefault(c => c.id == selectedCar.id);

                            var order = new iiOrders
                            {
                                order_date = DateTime.Now,
                                price = FinalPrice,
                                id_car = car.id,
                                id_status = 1,
                                id_client = MainWindow.UserID,
                                id_manager = GetRandomManagerId(),
                            };

                            car.id_status = 2;

                            car.id_status = 2;

                            context.iiOrders.Add(order);
                            context.SaveChanges();
                            clientCarsWindow.LoadCarsData();
                            MessageBox.Show($"Машина забронирована до {DateDP.SelectedDate}");
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Бронь не может осуществляться более чем на 15 дней вперёд", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Выберите корректную дату", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите дату", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
