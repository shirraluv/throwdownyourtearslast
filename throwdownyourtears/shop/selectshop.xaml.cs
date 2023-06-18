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
using System.Xml.Linq;
using throwdownyourtears.list;

namespace throwdownyourtears.shop
{
    /// <summary>
    /// Логика взаимодействия для selectshop.xaml
    /// </summary>
    public partial class selectshop : Page, INotifyPropertyChanged
    {

        public string Namesss { get; set; }

        private User User;

        public Shop Shop { get; set; }

        public List<Shop> Shops { get; set; } = new List<Shop>();

        public Shop SelectedData { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public selectshop(User user)
        {
            InitializeComponent();
            User = user;
            Shops = ThrowdownyourtearsContext.GetInstance().Shops.Where(s => s.Iduser == user.Id).ToList();
            DataContext = this;

        }

        private void sign(object sender, RoutedEventArgs e)
        {
            if (SelectedData != null)
            {
                NavigationService.Navigate(new MainPage(SelectedData));
            }
            else
            {
                MessageBox.Show("Выберите предприятие");
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(Namesss))
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            else
            {
                try
                {
                    var iduser = ThrowdownyourtearsContext.GetInstance().Users.ToList().LastOrDefault();
                    var shop = ThrowdownyourtearsContext.GetInstance().Shops.FirstOrDefault(s => s.Name == Namesss && s.Iduser == User.Id);
                    if (shop != null)
                    {
                        MessageBox.Show("Предприятие с таким именем уже существует");
                        return;
                    }
                    else
                    {
                        Shop = new Shop() { Iduser = User.Id, Name = Namesss };
                        ThrowdownyourtearsContext.GetInstance().Shops.Add(Shop);
                        ThrowdownyourtearsContext.GetInstance().SaveChanges();
                        MessageBox.Show("Предприятие добавлено!");
                        s.ItemsSource = ThrowdownyourtearsContext.GetInstance().Shops.Where(s => s.Iduser == User.Id).ToList();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка связи с БД");
                    return;
                }
            }
        }
    }
}
