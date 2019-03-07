using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            DataContext = this;

            //col1.Binding = new Binding(dataGridSource.Columns[colName].ColumnName);
        }

        #region colName
        
        public string colName
        {
            get { return (string)GetValue(colNameProperty); }
            set { SetValue(colNameProperty, value); }
        }
        
        public static readonly DependencyProperty colNameProperty =
            DependencyProperty.Register("colName", typeof(string), typeof(UserControl1));
        
        #endregion

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
            UserControl1 u = (UserControl1)d;
            if (u.dvSource != null)
            {
                setFilter(u.dvSource, u.TekstProp);
            }
        }
        #endregion

        #region tekstSelected

        public string tekstSelected
        {
            get { return (string)GetValue(tekstSelectedProperty); }
            set { SetValue(tekstSelectedProperty, value); }
        }

        public static readonly DependencyProperty tekstSelectedProperty =
            DependencyProperty.Register("tekstSelected", typeof(string), typeof(UserControl1));

        #endregion

        #region dataGridSource
        public DataTable dataGridSource
        {
            get { return (DataTable)GetValue(dataGridSourceProperty); }
            set { SetValue(dataGridSourceProperty, value); }
        }

        public static readonly DependencyProperty dataGridSourceProperty =
            DependencyProperty.Register("dataGridSource", typeof(DataTable), typeof(UserControl1));
        #endregion

        #region dvSource
        public DataView dvSource
        {
            get { return (DataView)GetValue(dvSourceProperty); }
            set { SetValue(dvSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for dvSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty dvSourceProperty =
            DependencyProperty.Register("dvSource", typeof(DataView), typeof(UserControl1));
        #endregion
    
        #region setFilter
        private static void setFilter(DataView dv, string t)
        {
            string query = $"name LIKE '%{t}%'";
            dv.RowFilter = query;
        }
        #endregion

        #region selectedRow

        public DataRowView selectedRow
        {
            get { return (DataRowView)GetValue(selectedRowProperty); }
            set { SetValue(selectedRowProperty, value); }
        }

        public static readonly DependencyProperty selectedRowProperty =
            DependencyProperty.Register("selectedRow", typeof(DataRowView), typeof(UserControl1), new PropertyMetadata( null, new PropertyChangedCallback(OnSelectRow)));

        private static void OnSelectRow(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl1 u = (UserControl1)d;
            if (u.selectedRow != null)
            {
                u.tekstSelected = u.selectedRow[u.colName].ToString();
                u.TekstProp = u.selectedRow[u.colName].ToString();
            }
        }

        #endregion

        #region fontSize
        
        public int fontSize
        {
            get { return (int)GetValue(fontSizeProperty); }
            set { SetValue(fontSizeProperty, value); }
        }

        public static readonly DependencyProperty fontSizeProperty =
            DependencyProperty.Register("fontSize", typeof(int), typeof(UserControl1));

        #endregion

        #region height

        public int height
        {
            get { return (int)GetValue(heightProperty); }
            set { SetValue(heightProperty, value); }
        }
        
        public static readonly DependencyProperty heightProperty =
            DependencyProperty.Register("height", typeof(int), typeof(UserControl1));

        #endregion
        
        private void clsValues()
        {
            TekstProp = string.Empty;
            tekstSelected = string.Empty;
        }

        private void podmiotDelButton_Click(object sender, RoutedEventArgs e)
        {
            clsValues();
        }

        private void TekstPropRaf_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TekstProp != null)
                if (dataGridSource.AsEnumerable().Where(row => row.Field<string>(colName).Contains(TekstProp) == true).Count() == 0)
                    clsValues();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dvSource = new DataView(dataGridSource);
            setFilter( dvSource, TekstProp);
            col1.Binding = new Binding(dataGridSource.Columns[colName].ColumnName);
        }
    }
}
