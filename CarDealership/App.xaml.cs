using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CarDealership
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            EventManager.RegisterClassHandler(typeof(Window), Window.LoadedEvent, new RoutedEventHandler(Window_Loaded));
            base.OnStartup(e);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is Window window)
            {
                window.Icon = new BitmapImage(new Uri("pack://application:,,,/icon.png"));
            }
        }
    }
}
