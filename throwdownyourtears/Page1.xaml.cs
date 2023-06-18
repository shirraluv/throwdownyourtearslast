using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using throwdownyourtears.list;
using throwdownyourtears.shop;

namespace throwdownyourtears
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private Shop Shop;
        private Shop SelectedData;
        public Page1(Shop SelectedShop)
        {
            InitializeComponent();
            Shop = SelectedShop;
            SelectedData = SelectedShop;
            DataContext = this;
        }

        private void tg(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://t.me/babyfromyourmum/") { UseShellExecute = true });
            NavigationService.Navigate(new listproduct(Shop));
        }

        private void github(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/shirraluv/") { UseShellExecute = true });
            NavigationService.Navigate(new listproduct(Shop));
        }

        private void vk(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://vk.com/") { UseShellExecute = true });
            NavigationService.Navigate(new listproduct(Shop));
        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage(SelectedData));
        }
    }
}
