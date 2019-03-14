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
    /// Logika interakcji dla klasy DataGridRaf.xaml
    /// </summary>
    public partial class DataGridRaf : UserControl
    {

        #region KONSTRUKTOR
        public DataGridRaf()
        {
            InitializeComponent();
            DataContext = this;
            
        }
        #endregion

        #region colName

        public string colName
        {
            get { return (string)GetValue(colNameProperty); }
            set { SetValue(colNameProperty, value); }
        }

        public static readonly DependencyProperty colNameProperty =
            DependencyProperty.Register("colName", typeof(string), typeof(DataGridRaf));

        #endregion
        
        #region dataGridSource
        public DataTable dataGridSource
        {
            get { return (DataTable)GetValue(dataGridSourceProperty); }
            set { SetValue(dataGridSourceProperty, value); }
        }

        public static readonly DependencyProperty dataGridSourceProperty =
            DependencyProperty.Register("dataGridSource", typeof(DataTable), typeof(DataGridRaf));
        #endregion

        #region dvSource
        public DataView dvSource
        {
            get { return (DataView)GetValue(dvSourceProperty); }
            set { SetValue(dvSourceProperty, value); }
        }

        public static readonly DependencyProperty dvSourceProperty =
            DependencyProperty.Register("dvSource", typeof(DataView), typeof(DataGridRaf));
        #endregion

        #region setFilter
        private void setFilter(DataView dv, string t)
        {
            string query = $"{ colName} LIKE '%{t}%'";
            dv.RowFilter = query;
        }
        #endregion

        #region fontSize

        public int fontSize
        {
            get { return (int)GetValue(fontSizeProperty); }
            set { SetValue(fontSizeProperty, value); }
        }

        public static readonly DependencyProperty fontSizeProperty =
            DependencyProperty.Register("fontSize", typeof(int), typeof(DataGridRaf));

        #endregion

        #region height

        public int height
        {
            get { return (int)GetValue(heightProperty); }
            set { SetValue(heightProperty, value); }
        }

        public static readonly DependencyProperty heightProperty =
            DependencyProperty.Register("height", typeof(int), typeof(DataGridRaf));

        #endregion

        #region DockPanel_Loaded
        private void DockPanel_Loaded(object sender, RoutedEventArgs e)
        {
            dvSource = new DataView(dataGridSource);
            col1.Binding = new Binding(dataGridSource.Columns[colName].ColumnName);
            setFilter(dvSource, TekstProp);
        }
        #endregion

        #region podmiotDelButton_Click
        private void podmiotDelButton_Click(object sender, RoutedEventArgs e)
        {
            clsValues();
        }
        #endregion

        #region TekstProp
        public string TekstProp
        {
            get { return (string)GetValue(TekstPropProperty); }
            set { SetValue(TekstPropProperty, value); }
        }
        public static readonly DependencyProperty TekstPropProperty =
            DependencyProperty.Register("TekstProp", typeof(string), typeof(DataGridRaf), new PropertyMetadata(null, OnTekstPropClick));

        private static void OnTekstPropClick(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataGridRaf u = d as DataGridRaf;
            string query = $"{ u.colName} LIKE '%{ u.TekstProp}%'";
            u.dvSource.RowFilter = query;
            //if (u.dataGridSource.AsEnumerable().Where(row => row.Field<string>(u.colName) == u.TekstProp).Count() == 1)
            //    u.selectedRow = u.dataGridSource[];
        }

        #endregion 
        
        #region selectedRow

        public DataRowView selectedRow
        {
            get { return (DataRowView)GetValue(selectedRowProperty); }
            set { SetValue(selectedRowProperty, value); }
        }

        public static readonly DependencyProperty selectedRowProperty =
            DependencyProperty.Register("selectedRow", typeof(DataRowView), typeof(DataGridRaf), new PropertyMetadata(null, new PropertyChangedCallback(OnSelectRow)));

        private static void OnSelectRow(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataGridRaf u = d as DataGridRaf;
            if (u.selectedRow != null)
            {
                u.TekstProp = u.selectedRow[u.colName].ToString();
            }
        }
        #endregion

        private void clsValues()
        {
            TekstProp = string.Empty;
            selectedRow = null;
        }
       
        private void TekstPropRaf_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (!(e.NewFocus is DataGridCell))
            {
                if (selectedRow != null)
                {
                    if (selectedRow[colName].ToString() != TekstProp)
                        clsValues();
                }
                else
                {
                    clsValues();
                }
            }
        }
    }
}