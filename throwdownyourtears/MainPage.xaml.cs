using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page, INotifyPropertyChanged
    {
        private User User;

        private Shop Shop;

        public string shopname { get; set; }

        public string username { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public MainPage(Shop SelectedData)
        {
            InitializeComponent();
            Shop = SelectedData;
            User = ThrowdownyourtearsContext.GetInstance().Users.Where(s => s.Id == SelectedData.Iduser).First();
            username = User.Name;
            shopname = Shop.Name;
            DataContext = this;
        }
        private void clickOpenlistproduct(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new listproduct(Shop));
        }

        private void clickOpenlistsales(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new listsales(Shop));
        }

        private void clickOpenlistreport(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new listreport(Shop));
        }

        private void clickOpenlisthistory(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new listhistory(Shop));
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new signin.signin());
        }

        private void clickOpenSvyaz(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1(Shop));
        }
    }
}
