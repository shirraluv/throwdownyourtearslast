using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для buyproduct.xaml
    /// </summary>
    public partial class buyproduct : Page
    {

        public string shop2 { get; set; }
        public string Name123 { get; set; }
        public int Quantity2 { get; set; }

        public Historybuy Historybuy { get; set; }

        public Shop SelectedData { get; set; }
        public Product SelectedProduct { get; set; }

        public buyproduct(Shop SelectedShop, Product SelectedData2)
        {
            InitializeComponent();
            InitializeComponent();
            SelectedProduct = SelectedData2;


            SelectedData = SelectedShop;
            Name123 = SelectedData2.Name;
            shop2 = SelectedShop.Name;
            DataContext = this;
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            if (Quantity2 < 1)
            {
                MessageBox.Show("Введите количество");
                return;
            }
            else
            {
                try
                {
                    Historybuy = new Historybuy() { Shopid = SelectedData.Id, Productname = SelectedProduct.Name, Productquantity = Quantity2, Buys = SelectedProduct.PurchasePrice * Quantity2, Date = DateTime.Now };
                    ThrowdownyourtearsContext.GetInstance().Historybuys.Add(Historybuy);
                    ThrowdownyourtearsContext.GetInstance().SaveChanges();
                    SelectedProduct.Productbuys += Quantity2;
                    SelectedProduct.Quantity += Quantity2;
                    SelectedProduct.Productgain2 += SelectedProduct.PurchasePrice * Quantity2;
                    ThrowdownyourtearsContext.GetInstance().SaveChanges();
                    MessageBox.Show("Товар куплен!");
                    NavigationService.Navigate(new listproduct(SelectedData));

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
