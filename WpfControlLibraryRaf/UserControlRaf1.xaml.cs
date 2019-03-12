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

        public string tekstRaf
        {
            get { return (string)GetValue(tekstRafProperty); }
            set { SetValue(tekstRafProperty, value); }
        }

        public static readonly DependencyProperty tekstRafProperty =
            DependencyProperty.Register("tekstRaf", typeof(string), typeof(UserControlRaf1));

        public DataView dv
        {
            get { return (DataView)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("dv", typeof(DataView), typeof(UserControlRaf1) );
    }
}
