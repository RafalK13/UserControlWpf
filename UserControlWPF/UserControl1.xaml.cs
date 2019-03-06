using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace UserControlWPF
{
    /// <summary>
    /// Logika interakcji dla klasy UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            DataContext = this;
        }

        #region TekstProp
        //zmienna wyświetlana w teksBox
        public string TekstProp
        {
            get { return (string)GetValue(TekstPropProperty); }
            set { SetValue(TekstPropProperty, value); }
        }
        public static readonly DependencyProperty TekstPropProperty =
            DependencyProperty.Register("TekstProp", typeof(string), typeof(UserControl1), new PropertyMetadata(null, new PropertyChangedCallback(OnCurrentReadingChanged)));

        private static void OnCurrentReadingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //UserControl1 u = (UserControl1)d;
            //if (u.dvSource != null)
            //{
            //    string query = $"name LIKE '%{u.TekstProp}%'";
            //    u.dvSource.RowFilter = query;
            //}
        }
        #endregion

        public DataTable dataGridSource
        {
            get { return (DataTable)GetValue(dataGridSourceProperty); }
            set { SetValue(dataGridSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for dataGridSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty dataGridSourceProperty =
            DependencyProperty.Register("dataGridSource", typeof(DataTable), typeof(UserControl1), new PropertyMetadata( null, new PropertyChangedCallback( OnInit)));

        private static void OnInit(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl1 u = (UserControl1)d;
            u.dvSource = new DataView (u.dataGridSource);
        }
        
        public DataView dvSource
        {
            get { return (DataView)GetValue(dvSourceProperty); }
            set { SetValue(dvSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for dvSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty dvSourceProperty =
            DependencyProperty.Register("dvSource", typeof(DataView), typeof(UserControl1));








    }
}
