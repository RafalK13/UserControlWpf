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

namespace WpfControlLibraryRaf
{
    /// <summary>
    /// Logika interakcji dla klasy UserControl3.xaml
    /// </summary>
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string  tekstUserRaf
        {
            get { return (string )GetValue(tekstUserRafProperty); }
            set { SetValue(tekstUserRafProperty, value); }
        }

        public static readonly DependencyProperty tekstUserRafProperty =
            DependencyProperty.Register("tekstUserRaf", typeof(string ), typeof(UserControl3), new PropertyMetadata( onChange));

        private static void onChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl3 c = d as UserControl3;

            MessageBox.Show(c.tekstUserRaf);
        }
    }
}
