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
using System.Windows.Navigation;
using System.Windows.Shapes;
using throwdownyourtears.shop;

namespace throwdownyourtears.list
{
    /// <summary>
    /// Логика взаимодействия для listhistory.xaml
    /// </summary>
    public partial class listhistory : Page
    {

        public List<Historybuy> Buy { get; set; }

        public List<Historysale> Sale { get; set; }

        public Historybuy Selectedbuy { get; set; }

        public Historysale Selectedsale { get; set; }


        public List<Product> Product { get; set; }

        public Product Product1 { get; set; }

        public string shopname { get; set; }

        private Shop Shop;

        private User User;

        private Product Product2;
        public string username { get; set; }



        public listhistory(Shop SelectedShop)
        {
            InitializeComponent();
            Shop = SelectedShop;
            Buy = ThrowdownyourtearsContext.GetInstance().Historybuys.Where(s => s.Shopid == SelectedShop.Id).ToList();
            Sale = ThrowdownyourtearsContext.GetInstance().Historysales.Where(s => s.Shopid == SelectedShop.Id).ToList();
            User = ThrowdownyourtearsContext.GetInstance().Users.Where(s => s.Id == SelectedShop.Iduser).First();
            username = User.Name;
            shopname = Shop.Name;
            DataContext = this;

        }
        private void clickOpenlistsales(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new listsales(Shop));
        }

        private void clickOpenlistreport(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new listreport(Shop));
        }
        private void clickOpenSvyaz(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1(Shop));
        }

        private void clickOpenlistproduct(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new listproduct(Shop));
        }

        private void clickOpenlisthistory(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы уже на данной странице!");
        }

        private void historydelete(object sender, RoutedEventArgs e)
        {
            if (Selectedsale != null)
            {
                MessageBoxResult m = MessageBox.Show("Вы уверены?", "История удалена", MessageBoxButton.YesNo);
                if (m == MessageBoxResult.Yes)
                {
                    Product2 = ThrowdownyourtearsContext.GetInstance().Products.Where(s => s.Name == Selectedbuy.Productname).SingleOrDefault();
                    if (Product2 != null)
                    {
                        Product2.Quantity -= Selectedbuy.Productquantity;
                        Product2.Productbuys -= Selectedbuy.Productquantity;
                        Product2.Productgain2 -= Selectedbuy.Buys;
                        ThrowdownyourtearsContext.GetInstance().Products.Update(Product2);
                        ThrowdownyourtearsContext.GetInstance().SaveChanges();
                        ThrowdownyourtearsContext.GetInstance().Historybuys.Remove(Selectedbuy);
                        ThrowdownyourtearsContext.GetInstance().SaveChanges();
                        ss.ItemsSource = ThrowdownyourtearsContext.GetInstance().Historybuys.Where(s => s.Shopid == Shop.Id).ToList();
                    }
                    else
                    {
                        ThrowdownyourtearsContext.GetInstance().Historybuys.Remove(Selectedbuy);
                        ThrowdownyourtearsContext.GetInstance().SaveChanges();
                        ss.ItemsSource = ThrowdownyourtearsContext.GetInstance().Historybuys.Where(s => s.Shopid == Shop.Id).ToList();
                    }
                }
                else
                {
                    ss.ItemsSource = ThrowdownyourtearsContext.GetInstance().Historybuys.Where(s => s.Shopid == Shop.Id).ToList();
                }
            }
            else
            {
                MessageBox.Show("Выберите действие");
            }


        }

        private void historydelete2(object sender, RoutedEventArgs e)
        {
            if (Selectedsale != null)
            {
                MessageBoxResult m = MessageBox.Show("Вы уверены?", "История удалена", MessageBoxButton.YesNo);
                if (m == MessageBoxResult.Yes)
                {
                    Product2 = ThrowdownyourtearsContext.GetInstance().Products.Where(s => s.Name == Selectedsale.Productname).SingleOrDefault();
                    if (Product2 != null)
                    {

                        Product2.Quantity += Selectedsale.Productquantity;
                        Product2.Productsales -= Selectedsale.Productquantity;
                        Product2.Productgain -= Selectedsale.Gain;
                        ThrowdownyourtearsContext.GetInstance().Products.Update(Product2);
                        ThrowdownyourtearsContext.GetInstance().SaveChanges();
                        ThrowdownyourtearsContext.GetInstance().Historysales.Remove(Selectedsale);
                        ThrowdownyourtearsContext.GetInstance().SaveChanges();
                        s.ItemsSource = ThrowdownyourtearsContext.GetInstance().Historysales.Where(s => s.Shopid == Shop.Id).ToList();
                    }
                    else
                    {
                        ThrowdownyourtearsContext.GetInstance().Historysales.Remove(Selectedsale);
                        ThrowdownyourtearsContext.GetInstance().SaveChanges();
                        s.ItemsSource = ThrowdownyourtearsContext.GetInstance().Historysales.Where(s => s.Shopid == Shop.Id).ToList();
                    }
                }
                else
                {
                    s.ItemsSource = ThrowdownyourtearsContext.GetInstance().Historybuys.Where(s => s.Shopid == Shop.Id).ToList();
                }
            }
            else
            {
                MessageBox.Show("Выберите действие");
            }
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new signin.signin());
        }
    }
}
