using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace throwdownyourtears.menu
{
    /// <summary>
    /// Логика взаимодействия для salemenu.xaml
    /// </summary>
#pragma warning disable CS8981 // Имя типа "salemenu" содержит только строчные символы ASCII. Такие имена могут резервироваться для языка.
    public partial class salemenu : Page
#pragma warning restore CS8981 // Имя типа "salemenu" содержит только строчные символы ASCII. Такие имена могут резервироваться для языка.
    {

        public Shop Shop123;
        public Product AddData { get; set; }
        public List<Product> Products { get; set; }
        public Product SelectedProduct { get; set; }
        string shop3 { get; set; }
        
        public salemenu(Shop Shop)
        {
            InitializeComponent();
            AddData = new Product();
            Products = ThrowdownyourtearsContext.GetInstance().Products.Where(s => s.Shopid == Shop.Id).ToList();
            Shop123 = Shop;
            DataContext = this;

        }

        public salemenu(Product addData)
        {

        }
        private void Save(object sender, RoutedEventArgs e)
        {
            Navigation.GetInstance().CurrentPage = new list.listsales(Shop123);
        }

        private void sale(object sender, RoutedEventArgs e)
        {

        }

    }


}
