using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
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
using System.Security.Cryptography.X509Certificates;
using System.DirectoryServices;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace throwdownyourtears.list
{
    /// <summary>
    /// Логика взаимодействия для listreport.xaml
    /// </summary>
#pragma warning disable CS8981 // Имя типа "listreport" содержит только строчные символы ASCII. Такие имена могут резервироваться для языка.
    public partial class listreport : Page, INotifyPropertyChanged
#pragma warning restore CS8981 // Имя типа "listreport" содержит только строчные символы ASCII. Такие имена могут резервироваться для языка.
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


        public List<Historysale> general { get; set; }
        public List<Historybuy> general2 { get; set; }
        public List<Historysale> yeargeneral { get; set; }
        public List<Historybuy> yeargeneral2 { get; set; }
        public List<Historysale> monthgeneral { get; set; }
        public List<Historybuy> monthgeneral2 { get; set; }
        public List<Historysale> daygeneral { get; set; }
        public List<Historybuy> daygeneral2 { get; set; }

        public Decimal Allgeneralquantity { get; set; }
        public Decimal Allgeneralbuys { get; set; }
        public Decimal Allgeneralgain { get; set; }
        public Decimal Allgeneralgain2 { get; set; }

        public Decimal yearAllgeneralquantity { get; set; }
        public Decimal yearAllgeneralbuys { get; set; }
        public Decimal yearAllgeneralgain { get; set; }
        public Decimal yearAllgeneralgain2 { get; set; }
        public Decimal monthAllgeneralquantity { get; set; }
        public Decimal monthAllgeneralbuys { get; set; }
        public Decimal monthAllgeneralgain { get; set; }
        public Decimal monthAllgeneralgain2 { get; set; }
        public Decimal dayAllgeneralquantity { get; set; }
        public Decimal dayAllgeneralbuys { get; set; }
        public Decimal dayAllgeneralgain { get; set; }
        public Decimal dayAllgeneralgain2 { get; set; }

        public string shopname { get; set; }

        private User User;

        public string username { get; set; }

        public string Today { get; set; }

        public List<Shop> Shops { get; set; }

        public string plus { get; set; }
        public string minus { get; set; }

        public List<Product> Product { get; set; }

        private Product Products;

        private Historybuy Historybuy;
        public List<Historybuy> Historybuys { get; set; }

        public List<Stat> Stat { get; set; }

        private decimal sum;

        public decimal Sum
        {
            get => sum;
            set
            {
                sum = value;
                Signal();
            }
        }

        private Shop Shop;



        public listreport(Shop SelectedShop)
        {
            InitializeComponent();
            Shop = SelectedShop;
            var products = ThrowdownyourtearsContext.GetInstance().Products.Where(s => s.Shopid == SelectedShop.Id).ToList();
            Shops = ThrowdownyourtearsContext.GetInstance().Shops.Where(s => s.Name == SelectedShop.Name).ToList();
            User = ThrowdownyourtearsContext.GetInstance().Users.Where(s => s.Id == SelectedShop.Iduser).First();
            Stat = ThrowdownyourtearsContext.GetInstance().Stats.Where(s => s.Shopid == SelectedShop.Id).ToList();
            Product = ThrowdownyourtearsContext.GetInstance().Products.Where(s => s.Shopid == SelectedShop.Id).ToList();

            username = User.Name;
            shopname = Shop.Name;
            DataContext = this;


            daygeneral2 = ThrowdownyourtearsContext.GetInstance().Historybuys.Where(s => s.Shopid == SelectedShop.Id && s.Date.Day == DateTime.Now.Day && s.Date.Month == DateTime.Now.Month && s.Date.Year == DateTime.Now.Year).ToList();
            foreach (var num in daygeneral2)
            {
                dayAllgeneralbuys += num.Buys;
            }

            daygeneral = ThrowdownyourtearsContext.GetInstance().Historysales.Where(s => s.Shopid == SelectedShop.Id && s.Date.Day == DateTime.Now.Day && s.Date.Month == DateTime.Now.Month && s.Date.Year == DateTime.Now.Year).ToList();
            foreach (var num in daygeneral)
            {
                dayAllgeneralquantity += num.Productquantity;
                dayAllgeneralgain += num.Gain;
                dayAllgeneralgain2 = dayAllgeneralgain - dayAllgeneralbuys;
            }

            monthgeneral2 = ThrowdownyourtearsContext.GetInstance().Historybuys.Where(s => s.Shopid == SelectedShop.Id && s.Date.Month == DateTime.Now.Month && s.Date.Year == DateTime.Now.Year).ToList();
            foreach (var num1 in monthgeneral2)
            {
                monthAllgeneralbuys += num1.Buys;
            }
            monthgeneral = ThrowdownyourtearsContext.GetInstance().Historysales.Where(s => s.Shopid == SelectedShop.Id && s.Date.Month == DateTime.Now.Month && s.Date.Year == DateTime.Now.Year).ToList();
            foreach (var num1 in monthgeneral)
            {
                monthAllgeneralquantity += num1.Productquantity;
                monthAllgeneralgain += num1.Gain;
                monthAllgeneralgain2 = monthAllgeneralgain - monthAllgeneralbuys;
            }

            yeargeneral2 = ThrowdownyourtearsContext.GetInstance().Historybuys.Where(s => s.Shopid == SelectedShop.Id && s.Date.Year == DateTime.Now.Year).ToList();
            foreach (var num2 in yeargeneral2)
            {
                yearAllgeneralbuys += num2.Buys;
            }
            yeargeneral = ThrowdownyourtearsContext.GetInstance().Historysales.Where(s => s.Shopid == SelectedShop.Id && s.Date.Year == DateTime.Now.Year).ToList();
            foreach (var num2 in yeargeneral)
            {
                yearAllgeneralquantity += num2.Productquantity;
                yearAllgeneralgain += num2.Gain;
                yearAllgeneralgain2 = yearAllgeneralgain - yearAllgeneralbuys;
            }

            general2 = ThrowdownyourtearsContext.GetInstance().Historybuys.Where(s => s.Shopid == SelectedShop.Id).ToList();
            foreach (var num3 in general2)
            {
                Allgeneralbuys += num3.Buys;
            }
            general = ThrowdownyourtearsContext.GetInstance().Historysales.Where(s => s.Shopid == SelectedShop.Id).ToList();
            foreach (var num3 in general)
            {
                Allgeneralquantity += num3.Productquantity;
                Allgeneralgain += num3.Gain;
                Allgeneralgain2 = Allgeneralgain - Allgeneralbuys;
            }
        }

        private void clickOpenlistsales(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new listsales(Shop));
        }

        private void clickOpenlistreport(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы уже на данной странице!");
        }

        private void clickOpenlistproduct(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new listproduct(Shop));
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

