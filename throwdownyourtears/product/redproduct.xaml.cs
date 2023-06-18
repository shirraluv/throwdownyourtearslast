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
using throwdownyourtears.list;

namespace throwdownyourtears.product
{
    /// <summary>
    /// Логика взаимодействия для redproduct.xaml
    /// </summary>
    public partial class redproduct : Page
    {
        public Product Edit { get; set; }
        public List<Shop> Shops { get; set; }

        private Shop Shop1;

        private Product Product;

        public Shop SelectedData { get; set; }
        public List<Product> Products { get; set; }

        public string shop2 { get; set; }
        public string Name123 { get; set; }
        public int Price { get; set; }
        public int PurchasePrice { get; set; }
        public string Minimum { get; set; }

        private Historybuy Historybuy;
        private Historysale Historysale;
        private Stat Stat;
        public int Quantity { get; set; }
        public int Sho1p { get; set; }
        public redproduct(Shop Shop, Product SelectedData2)
        {
            InitializeComponent();
            shop2 = Shop.Name;
            Edit = new Product();
            if (SelectedData2 != null) { Name123 = SelectedData2.Name; Price = SelectedData2.Price; PurchasePrice = SelectedData2.PurchasePrice; Minimum = SelectedData2.Minimum; Quantity = SelectedData2.Quantity; }
            Sho1p = Shop.Id;
            Stat = ThrowdownyourtearsContext.GetInstance().Stats.Where(s => s.Name == SelectedData2.Name).FirstOrDefault();
            Historybuy = ThrowdownyourtearsContext.GetInstance().Historybuys.Where(s => s.Productname == SelectedData2.Name).FirstOrDefault();
            Historysale = ThrowdownyourtearsContext.GetInstance().Historysales.Where(s => s.Productname == SelectedData2.Name).FirstOrDefault();
            Product = SelectedData2;
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
                        Product.Name = Name123; Product.Price = Price; Product.PurchasePrice = PurchasePrice; Product.Quantity = Quantity; Product.Minimum = Minimum;
                        ThrowdownyourtearsContext.GetInstance().Products.Update(Product);
                        ThrowdownyourtearsContext.GetInstance().SaveChanges();
                        if (Stat != null)
                        {
                            Stat.Name = Name123;
                            ThrowdownyourtearsContext.GetInstance().Stats.Update(Stat);
                            ThrowdownyourtearsContext.GetInstance().SaveChanges();
                        }
                        if (Historybuy != null)
                        {
                            Historybuy.Productname = Name123;
                            ThrowdownyourtearsContext.GetInstance().Historybuys.Update(Historybuy);
                            ThrowdownyourtearsContext.GetInstance().SaveChanges();
                        }
                        if (Historysale != null)
                        {
                            Historysale.Productname = Name123;
                            ThrowdownyourtearsContext.GetInstance().Historysales.Update(Historysale);
                            ThrowdownyourtearsContext.GetInstance().SaveChanges();
                        }
                        MessageBox.Show("Товар Обновлен!");
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


    
