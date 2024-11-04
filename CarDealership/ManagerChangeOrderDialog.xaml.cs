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
    /// Логика взаимодействия для ManagerChangeOrderDialog.xaml
    /// </summary>
    public partial class ManagerChangeOrderDialog : Window
    {
        iiOrders selectedOrder;
        private ManagerOrders managerOrdersWindow; // Ссылка на окно ManagerOrders

        public ManagerChangeOrderDialog(iiOrders order, ManagerOrders managerOrdersWindow)
        {
            InitializeComponent();
            LoadCB();
            selectedOrder = order;
            LoadOrderData(order);
            DataloadHelper.LoadUserLabel(FILabel);
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.managerOrdersWindow = managerOrdersWindow;
        }

        private void LoadOrderData(iiOrders order)
        {
            PriceTextBox.Text = Convert.ToString(order.price);
            StatusCB.SelectedValue = order.iiStatus_order.id;
            ManagerCB.SelectedValue = order.iiUsers.id;
        }

        private void LoadCB()
        {
            using (var context = new user100_dbEntities())
            {
                var statuses = context.iiStatus_order
                    .Select(c => new
                    {
                        c.id,
                        c.status
                    })
                    .ToList();

                StatusCB.ItemsSource = statuses;
                StatusCB.DisplayMemberPath = "status";
                StatusCB.SelectedValuePath = "id";


                var managers = context.iiUsers
                    .Where(c => c.id_role == 2)
                    .Select(c => new
                    {
                        c.id,
                        c.lastname,
                        c.name,
                        c.patronymic
                    })
                    .ToList();

                var managersFormatted = managers.Select(c => new
                {
                    c.id,
                    Fullname = $"{c.lastname} {c.name} {c.patronymic}",
                }).ToList();

                ManagerCB.ItemsSource = managersFormatted;
                ManagerCB.DisplayMemberPath = "Fullname";
                ManagerCB.SelectedValuePath = "id";
            }
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(PriceTextBox.Text) &&
                ManagerCB.SelectedValue != null && 
                StatusCB.SelectedValue != null)
            {
                using (var context = new user100_dbEntities())
                {
                    var order = context.iiOrders.FirstOrDefault(o => o.id == selectedOrder.id);
                    order.price = Convert.ToInt32(PriceTextBox.Text);
                    order.id_status = Convert.ToInt32(StatusCB.SelectedValue);
                    order.id_manager = Convert.ToInt32(ManagerCB.SelectedValue);
                    context.SaveChanges();
                }
                    
                // Обновляем DataGrid в ManagerOrders
                managerOrdersWindow.LoadDataGrid();
                MessageBox.Show("Данные изменены");

                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PriceTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
