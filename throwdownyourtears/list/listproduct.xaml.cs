using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
using throwdownyourtears.product;

namespace throwdownyourtears.list
{
    /// <summary>
    /// Логика взаимодействия для listproduct.xaml
    /// </summary>
#pragma warning disable CS8981 // Имя типа "listproduct" содержит только строчные символы ASCII. Такие имена могут резервироваться для языка.
    public partial class listproduct : Page
#pragma warning restore CS8981 // Имя типа "listproduct" содержит только строчные символы ASCII. Такие имена могут резервироваться для языка.
    {
        public List<Provider> Providers { get; set; }

        private Shop Shop;
        public List<Product> Data { get; set; }
        public Product SelectedData2 { get; set; }

        private User User;

        private Stat Stat;
        public string shopname { get; set; }

        public List<Historybuy> Historybuy;
        public List<Historysale> Historysale;
        public string username { get; set; }

        public listproduct(Shop SelectedData)
        {
            InitializeComponent();
            Data = ThrowdownyourtearsContext.GetInstance().Products.Where(s => s.Shopid == SelectedData.Id).ToList();
            Shop = SelectedData;
            User = ThrowdownyourtearsContext.GetInstance().Users.Where(s => s.Id == SelectedData.Iduser).First();
            username = User.Name;
            shopname = Shop.Name;
            DataContext = this;

        }

        private void productadd(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new addproduct(Shop));
        }

        private void productdelete(object sender, RoutedEventArgs e)
        {
            MessageBoxResult m = MessageBox.Show("Вы уверены?", "История удалена", MessageBoxButton.YesNo);
            if (m == MessageBoxResult.Yes)
            {
                
                    Stat = ThrowdownyourtearsContext.GetInstance().Stats.Where(s => s.Name == SelectedData2.Name).FirstOrDefault();
                if (Stat != null)
                {
                    ThrowdownyourtearsContext.GetInstance().Stats.Remove(Stat);
                    ThrowdownyourtearsContext.GetInstance().Products.Remove(SelectedData2);
                    ThrowdownyourtearsContext.GetInstance().SaveChanges();
                    s.ItemsSource = ThrowdownyourtearsContext.GetInstance().Products.Where(s => s.Shopid == Shop.Id).ToList();
                }
                else
                {
                    ThrowdownyourtearsContext.GetInstance().Products.Remove(SelectedData2);
                    ThrowdownyourtearsContext.GetInstance().SaveChanges();
                    s.ItemsSource = ThrowdownyourtearsContext.GetInstance().Products.Where(s => s.Shopid == Shop.Id).ToList();
                }
            }
            else
            {
                s.ItemsSource = ThrowdownyourtearsContext.GetInstance().Products.Where(s => s.Shopid == Shop.Id).ToList();
            }
        }

        private void buyproduct(object sender, RoutedEventArgs e)
        {
            {
                if (SelectedData2 != null)
                {

                    NavigationService.Navigate(new buyproduct(Shop, SelectedData2));
                    s.ItemsSource = ThrowdownyourtearsContext.GetInstance().Products.Where(s => s.Shopid == Shop.Id).ToList();
                }
                else
                {
                    MessageBox.Show("Выберите товар");
                }
            }
        }

        private void clickOpenlistsales(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new listsales(Shop));
        }

        private void clickOpenlistreport(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new listreport(Shop));
        }

        private void clickOpenlistproduct(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы уже на данной странице!");
        }

        private void clickOpenlisthistory(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new listhistory(Shop));
        }
        private void clickOpenSvyaz(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1(Shop));
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            {
                string searchText = SearchTextBox.Text.Trim();

                if (!string.IsNullOrEmpty(searchText))
                {
                    var filteredData = ThrowdownyourtearsContext.GetInstance().Products.Local
                        .Where(c => c.Shopid == Shop.Id && c.Name.Contains(searchText) ||
                            c.Price.ToString().Contains(searchText) ||
                            c.Id.ToString().Contains(searchText) ||
                            c.PurchasePrice.ToString().Contains(searchText) ||
                            c.Quantity.ToString().Contains(searchText) ||
                            c.Minimum.ToString().Contains(searchText))
                        .ToList();

                    s.ItemsSource = filteredData;
                }
                else
                {
                    s.ItemsSource = ThrowdownyourtearsContext.GetInstance().Products.Local.ToObservableCollection();

                }
            }
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new signin.signin());
        }

        private void productred(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new redproduct(Shop, SelectedData2));
        }
    }
}
