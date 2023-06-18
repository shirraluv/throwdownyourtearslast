using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace throwdownyourtears
{
    internal class Navigation : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(prop));
        }

        static Navigation instance;
        public static Navigation GetInstance()
        {
            if (instance == null)
                instance = new Navigation();
            return instance;
        }
        private Page currentPage;
        public Page CurrentPage
        {
            get => currentPage;
            set
            {
                currentWindow = null;
                currentPage = value;
                Signal();
            }
        }
        private Window currentWindow;
        public Window CurrentWindow
        {
            get => currentWindow;
            set
            {
                currentPage = null;
                currentWindow = value;
                Signal();
            }
        }
    }
}