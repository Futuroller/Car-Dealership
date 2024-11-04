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
    /// Логика взаимодействия для AdminCarsAddDialog.xaml
    /// </summary>
    public partial class AdminCarsAddDialog : Window
    {
        private AdminCars adminCarsWindow;

        public AdminCarsAddDialog(AdminCars adminCarsWindow)
        {
            InitializeComponent();
            DataloadHelper.LoadUserLabel(FILabel);
            LoadCB();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.adminCarsWindow = adminCarsWindow;
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

        private void AddButton_Click(object sender, RoutedEventArgs e)
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
                    var car = new iiCars
                    {
                        vin = VINTextBox.Text,
                        mileage = Convert.ToInt32(MileageTextBox.Text),
                        price = Convert.ToInt32(PriceTextBox.Text),
                        photo_path = PhotoPathTextBox.Text,
                        id_color = Convert.ToInt32(ColorCB.SelectedValue),
                        id_model = Convert.ToInt32(ModelCB.SelectedValue),
                        id_status = Convert.ToInt32(StatusCB.SelectedValue)
                    };

                    context.iiCars.Add(car);
                    context.SaveChanges();
                    adminCarsWindow.LoadDataGrid();
                    MessageBox.Show("Машина добавлена");
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
