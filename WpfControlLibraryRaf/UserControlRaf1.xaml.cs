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

        public DataTable dataTable
        {
            get { return (DataTable)GetValue(dataTableProperty); }
            set { SetValue(dataTableProperty, value); }
        }

        public static readonly DependencyProperty dataTableProperty =
            DependencyProperty.Register("dataTable", typeof(DataTable), typeof(UserControlRaf1));

        public DataRowView dataRowView
        {
            get { return (DataRowView)GetValue(dataRowViewProperty); }
            set { SetValue(dataRowViewProperty, value); }
        }

        public static readonly DependencyProperty dataRowViewProperty =
            DependencyProperty.Register("dataRowView", typeof(DataRowView), typeof(UserControlRaf1));





    }
}
