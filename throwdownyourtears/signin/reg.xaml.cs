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

namespace throwdownyourtears.signin
{
    /// <summary>
    /// Логика взаимодействия для reg.xaml
    /// </summary>
    public partial class reg : Page
    {

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public User User { get; set; }



        public reg()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void reg1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            else
            {
                try
                {
                    var user = ThrowdownyourtearsContext.GetInstance().Users.FirstOrDefault(s => s.Login == Login);
                    if (user != null)
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует");
                        return;
                    }
                    else
                    {
                        User = new User() { Lastname = LastName, Name = FirstName, Login = Login, Password = Password };
                        ThrowdownyourtearsContext.GetInstance().Users.Add(User);
                        ThrowdownyourtearsContext.GetInstance().SaveChanges();
                        MessageBox.Show("Вы успешно зарегистрировались!");
                        NavigationService.Navigate(new signin());
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка связи с БД");
                    return;
                }
            }
        }

        private void signin(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new signin());
        }
    }
}
