using System;
using System.Collections;
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

    public partial class UserControl4 : UserControl
    {
        public UserControl4()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string colName
        {
            get { return (string)GetValue(colNameProperty); }
            set { SetValue(colNameProperty, value); }
        }

        public static readonly DependencyProperty colNameProperty =
            DependencyProperty.Register("colName", typeof(string), typeof(UserControl4));



        public string selItem
        {
            get { return (string)GetValue(selItemProperty); }
            set { SetValue(selItemProperty, value); }
        }

        public static readonly DependencyProperty selItemProperty =
            DependencyProperty.Register("selItem", typeof(string), typeof(UserControl4));

        public IEnumerable tabRaf
        {
            get { return (IEnumerable)GetValue(tabRafProperty); }
            set { SetValue(tabRafProperty, value); }
        }

        public object selectedItemRaf
        {
            get { return (object)GetValue(selectedItemRafProperty); }
            set { SetValue(selectedItemRafProperty, value); }
        }

        public static readonly DependencyProperty selectedItemRafProperty =
            DependencyProperty.Register("selectedItemRaf", typeof(object), typeof(UserControl4), new PropertyMetadata( null, onChangedselectedItemRaf));

        private static void onChangedselectedItemRaf(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //DataGridRaf u = d as DataGridRaf;
            UserControl4 u = d as UserControl4;
            u.selItem = u.selectedItemRaf.GetType().GetProperty("nazwa").GetValue(u.selectedItemRaf).ToString();
        }

        public static readonly DependencyProperty tabRafProperty =
            DependencyProperty.Register("tabRaf", typeof(IEnumerable), typeof(UserControl4));

        public List<object> listObj
        {
            get { return (List<object>)GetValue(listObjProperty); }
            set { SetValue(listObjProperty, value); }
        }

        public static readonly DependencyProperty listObjProperty =
            DependencyProperty.Register("listObj", typeof(List<object>), typeof(UserControl4));

        public List<Podmiot> tabIn
        {
            get { return (List<Podmiot>)GetValue(tabInProperty); }
            set { SetValue(tabInProperty, value); }
        }

        public static readonly DependencyProperty tabInProperty =
            DependencyProperty.Register("tabIn", typeof(List<Podmiot>), typeof(UserControl4));

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {

            tabIn = tabRaf.Cast<object>().Select(row => new Podmiot()
            {
                id = int.Parse( row.GetType().GetProperty("id").GetValue(row).ToString()),
                nazwa = row.GetType().GetProperty(colName).GetValue(row).ToString()
            }).ToList();
        }
    }
}
