using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfControlLibraryRaf
{
    /// <summary>
    /// Logika interakcji dla klasy UserControlRaf1.xaml
    /// </summary>
    public partial class UserControlRaf1 : UserControl
    {
        public UserControlRaf1()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string tekst1
        {
            get { return (string)GetValue(tekst1Property); }
            set { SetValue(tekst1Property, value); }
        }

        // Using a DependencyProperty as the backing store for tekst1.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty tekst1Property =
            DependencyProperty.Register("tekst1", typeof(string), typeof(UserControlRaf1));

        public string  tekst2
        {
            get { return (string )GetValue(tekst2Property); }
            set { SetValue(tekst2Property, value); }
        }

        // Using a DependencyProperty as the backing store for tekst2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty tekst2Property =
            DependencyProperty.Register("tekst2", typeof(string ), typeof(UserControlRaf1), new PropertyMetadata("DependencyProperty value"));





    }
}
