using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using throwdownyourtears.list;

namespace throwdownyourtears.product
{
    /// <summary>
    /// Логика взаимодействия для addproduct.xaml
    /// </summary>
    public partial class addproduct : Page
    {
        public Product Edit { get; set; }
        public List<Shop> Shops { get; set; }

        private Shop Shop1;

        public Product Product { get;set; }

        public Shop SelectedData { get; set; }
        public List<Product> Products { get; set; }

        public string shop2 { get; set; }
        public string Name123 { get;set; }
        public int Price { get; set; }
        public int PurchasePrice { get; set; }
        public string Minimum { get; set; }
        public int Quantity { get; set; }
        public int Sho1p { get; set; }
        public addproduct(Shop Shop)
        {
            InitializeComponent();
            shop2 = Shop.Name;
            Edit = new Product();
          
            Sho1p = Shop.Id;
            Shop1 = Shop;
            SelectedData = Shop1;
            DataContext = this;
        }


        private void Save(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Name123) || Price < 1 || PurchasePrice < 1 || string.IsNullOrEmpty(Minimum))
             
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            else
            {
                try
                {
                    var product = ThrowdownyourtearsContext.GetInstance().Products.FirstOrDefault(s => s.Name == Name123 && s.Shopid == Sho1p);
                    if (product != null)
                    {
                        MessageBox.Show("Товар с таким названием уже существует");
                        return;
                    }
                    else
                    {
                        Product = new Product() { Name = Name123, Price = Price, PurchasePrice = PurchasePrice, Quantity = Quantity, Minimum = Minimum, Shopid = Sho1p };
                        ThrowdownyourtearsContext.GetInstance().Products.Add(Product);
                        ThrowdownyourtearsContext.GetInstance().SaveChanges();
                        MessageBox.Show("Товар добавлен!");
                        NavigationService.Navigate(new listproduct(SelectedData));
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка связи с БД");
                    return;
                }
            }
            

        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new listproduct(SelectedData));
        }
    }
}

