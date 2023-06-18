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
    /// Логика взаимодействия для listsales.xaml
    /// </summary>
#pragma warning disable CS8981 // Имя типа "listsales" содержит только строчные символы ASCII. Такие имена могут резервироваться для языка.
    public partial class listsales : Page
#pragma warning restore CS8981 // Имя типа "listsales" содержит только строчные символы ASCII. Такие имена могут резервироваться для языка.
    {
        public List<Product> Data { get; set; }
        public Product Selectedproduct { get; set; }

        private Shop Shop;
        public Shop SelectedData2 { get; set; }

        public string shopname { get; set; }

        private User User;

        public string username { get; set; }
        public listsales(Shop SelectedData)
        {
            InitializeComponent();
            Data = ThrowdownyourtearsContext.GetInstance().Products.Where(s => s.Shopid == SelectedData.Id).ToList();
            SelectedData2 = SelectedData;
            Shop = SelectedData;
            User = ThrowdownyourtearsContext.GetInstance().Users.Where(s => s.Id == SelectedData.Iduser).First();
            username = User.Name;
            shopname = Shop.Name;
            DataContext = this;
        }

        private void opensale(object sender, RoutedEventArgs e)
        {
            if (Selectedproduct != null)
            {
                if (Selectedproduct.Quantity > 0)
                {
                    NavigationService.Navigate(new product.saleproduct(SelectedData2, Selectedproduct));
                    ss.ItemsSource = ThrowdownyourtearsContext.GetInstance().Products.Where(s => s.Shopid == Selectedproduct.Id).ToList();
                }
                else
                {
                    MessageBox.Show("Товар закончился");
                }
            }
            else
            {
                MessageBox.Show("Выберите товар");
            }

        }

        private void clickOpenlistsales(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы уже на данной странице!");
        }

        private void clickOpenlistreport(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new listreport(Shop));
        }

        private void clickOpenlistproduct(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new listproduct(Shop));
        }

        private void clickOpenlisthistory(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new listhistory(Shop));
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
                            c.Productsales.ToString().Contains(searchText) ||
                            c.Quantity.ToString().Contains(searchText) ||
                            c.Productgain.ToString().Contains(searchText))
                        .ToList();

                    ss.ItemsSource = filteredData;
                }
                else
                {
                    ss.ItemsSource = ThrowdownyourtearsContext.GetInstance().Products.Local.ToObservableCollection();

                }
            }
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
