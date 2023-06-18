using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using throwdownyourtears.shop;

namespace throwdownyourtears.signin
{
    /// <summary>
    /// Логика взаимодействия для signin.xaml
    /// </summary>
    public partial class signin : Page, INotifyPropertyChanged
    {

        public string Login { get; set; }
        public string Password { get; set; }

        public signin()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void SignalChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void signin1(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = ThrowdownyourtearsContext.GetInstance().Users.FirstOrDefault(s => s.Login == Login && s.Password == Password);
                if (user != null)
                {
                    NavigationService.Navigate(new selectshop(user));
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка связи с БД");
                return;
            }
        }

        private void reg(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new reg());
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void WButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://vk.com/") { UseShellExecute = true });
        }
    }
}
