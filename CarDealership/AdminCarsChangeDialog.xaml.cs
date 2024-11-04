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
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Contexts;

namespace CarDealership
{
    /// <summary>
    /// Логика взаимодействия для AdminCarsChangeDialog.xaml
    /// </summary>
    public partial class AdminCarsChangeDialog : Window
    {
        iiCars selectedCar;
        private AdminCars adminCarsWindow;
        public AdminCarsChangeDialog(iiCars car, AdminCars adminCarsWindow)
        {
            InitializeComponent();
            selectedCar = car;
            LoadCB();
            LoadData(car);
            DataloadHelper.LoadUserLabel(FILabel);
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.adminCarsWindow = adminCarsWindow;
        }

        private void LoadData(iiCars car)
        {
            VINTextBox.Text = Convert.ToString(car.vin);
            MileageTextBox.Text = Convert.ToString(car.mileage);
            PriceTextBox.Text = Convert.ToString(car.price);
            PhotoPathTextBox.Text = Convert.ToString(car.photo_path);
            ColorCB.SelectedValue = car.id_color;
            ModelCB.SelectedValue = car.id_model;
            StatusCB.SelectedValue = car.id_status;
        }

        private void LoadCB()
        {
            using (var context = new user100_dbEntities())
            {
                var colors = context.iiColors
                    .Select(c => new
                    {
                        c.id,
                        c.color
                    })
                    .ToList();

                ColorCB.ItemsSource = colors;
                ColorCB.DisplayMemberPath = "color";
                ColorCB.SelectedValuePath = "id";

                var model = context.iiModels.Include(m => m.iiMakes).ToList();

                var modelFormatted = model
                    .Select(m => new
                    {
                        m.id,
                        FullModel = $"{m.iiMakes.make} {m.model} {m.year}"
                    }).ToList();

                ModelCB.ItemsSource = modelFormatted;
                ModelCB.DisplayMemberPath = "FullModel";
                ModelCB.SelectedValuePath = "id";

                var status = context.iiStatus_car
                    .Select(m => new
                    {
                        m.id,
                        m.status
                    })
                    .ToList();

                StatusCB.ItemsSource = status;
                StatusCB.DisplayMemberPath = "status";
                StatusCB.SelectedValuePath = "id";
            }
        }
        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(VINTextBox.Text) &&
                !string.IsNullOrEmpty(MileageTextBox.Text) &&
                !string.IsNullOrEmpty(PriceTextBox.Text) &&
                !string.IsNullOrEmpty(PhotoPathTextBox.Text) &&
                ColorCB.SelectedValue != null &&
                ModelCB.SelectedValue != null &&
                StatusCB.SelectedValue != null)
            {
                using (var context = new user100_dbEntities())
                {
                    var car = context.iiCars.FirstOrDefault(m => m.id == selectedCar.id);
                    car.vin = VINTextBox.Text;
                    car.mileage = Convert.ToInt32(MileageTextBox.Text);
                    car.price = Convert.ToInt32(PriceTextBox.Text);
                    car.photo_path = PhotoPathTextBox.Text;
                    car.id_color = Convert.ToInt32(ColorCB.SelectedValue);
                    car.id_model = Convert.ToInt32(ModelCB.SelectedValue);
                    car.id_status = Convert.ToInt32(StatusCB.SelectedValue);

                    context.SaveChanges();
                    adminCarsWindow.LoadDataGrid();
                    MessageBox.Show("Данные изменены");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AnyTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
