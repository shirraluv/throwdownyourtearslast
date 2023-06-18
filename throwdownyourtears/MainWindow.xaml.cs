using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using throwdownyourtears.list;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.CompilerServices;
using MaterialDesignThemes.Wpf;
using System.Windows.Controls.Primitives;
using System.Printing;

namespace throwdownyourtears
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void SignalChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public Page CurrentPage { get; set; }
        public MainWindow() 
        {
            InitializeComponent();
            CurrentPage = new signin.signin();
            DataContext = this;
        }
        private void ChangeThemeClick(object sender, RoutedEventArgs e)
        {
            var helper = new PaletteHelper();
            var theme = helper.GetTheme();
            if (((ToggleButton)sender).IsChecked == true)
            {
                theme.SetBaseTheme(MaterialDesignThemes.Wpf.Theme.Dark);
            }
            else
            {
                theme.SetBaseTheme(MaterialDesignThemes.Wpf.Theme.Light);
            }
            helper.SetTheme(theme);
        }
    }
}
