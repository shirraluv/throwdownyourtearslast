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
    /// Логика взаимодействия для saleproduct.xaml
    /// </summary>
    public partial class saleproduct : Page

    {

        public string shop2 { get; set; }
        public string Name123 { get; set; }
        public int Quantity2 { get; set; }

        public Historysale Historysale { get; set; }

        public Stat Stat { get; set; }
        public Shop SelectedData { get; set; }
        public Product SelectedProduct { get; set; }
        private Stat Stat2;
        public saleproduct(Shop SelectedData2, Product Selectedproduct)
        {
            InitializeComponent();
            SelectedProduct = Selectedproduct;


            SelectedData = SelectedData2;
            Name123 = Selectedproduct.Name;
            shop2 = SelectedData2.Name;
            DataContext = this;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (Quantity2 < 1)
            {
                MessageBox.Show("Введите количество");
                return;
            }
            else if (Quantity2 > SelectedProduct.Quantity)
            {
                MessageBox.Show("Недостаточно товара");
                return;
            }
            else
            {
                try
                {
                    var stat = ThrowdownyourtearsContext.GetInstance().Stats.FirstOrDefault(s => s.Name == SelectedProduct.Name);
                    if (stat != null)
                    {
                        Stat2 = ThrowdownyourtearsContext.GetInstance().Stats.Where(s => s.Name == SelectedProduct.Name).Single();
                        Stat2.Quantity += Quantity2;
                        Stat2.Gain = SelectedProduct.Price * Quantity2;
                        ThrowdownyourtearsContext.GetInstance().Stats.Update(Stat2);
                        ThrowdownyourtearsContext.GetInstance().SaveChanges();

                    }
                    else
                    {
                        Stat = new Stat() { Name = SelectedProduct.Name, Quantity = Quantity2, Gain = SelectedProduct.Price * Quantity2, Shopid = SelectedData.Id };
                        ThrowdownyourtearsContext.GetInstance().Stats.Add(Stat);
                        ThrowdownyourtearsContext.GetInstance().SaveChanges();
                    }

                    Historysale = new Historysale() { Shopid = SelectedData.Id, Productname = SelectedProduct.Name, Productquantity = Quantity2, Gain = SelectedProduct.Price * Quantity2, Date = DateTime.Now };
                    ThrowdownyourtearsContext.GetInstance().Historysales.Add(Historysale);
                    ThrowdownyourtearsContext.GetInstance().SaveChanges();
                    SelectedProduct.Productsales += Quantity2;
                    SelectedProduct.Quantity -= Quantity2;
                    SelectedProduct.Productgain += SelectedProduct.Price * Quantity2;
                    ThrowdownyourtearsContext.GetInstance().SaveChanges();
                    MessageBox.Show("Товар продан!");
                    NavigationService.Navigate(new listsales(SelectedData));

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
            NavigationService.Navigate(new listsales(SelectedData));
        }
    }
}

