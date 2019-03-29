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

        #region fontSizeRaf

        public int fontSizeRaf
        {
            get { return (int)GetValue(fontSizeProperty); }
            set { SetValue(fontSizeProperty, value); }
        }

        public static readonly DependencyProperty fontSizeProperty =
            DependencyProperty.Register("fontSizeRaf", typeof(int), typeof(DataGridRaf), new PropertyMetadata(14));

        #endregion       

        #region heightRaf
        public int heightRaf
        {
            get { return (int)GetValue(heightRafProperty); }
            set { SetValue(heightRafProperty, value); }
        }

        public static readonly DependencyProperty heightRafProperty =
            DependencyProperty.Register("heightRaf", typeof(int), typeof(DataGridRaf), new PropertyMetadata(25));
        #endregion

        #region DockPanel_Loaded
        private void DockPanel_Loaded(object sender, RoutedEventArgs e)
        {
            dvSource = new DataView(dataGridSource);

            try
            {
                col1.Binding = new Binding(dataGridSource.Columns[colName].ColumnName);
            }
            catch (Exception exp)
            {
                string s = "DUPA Blada";
            }
            finally
            {
                setFilter(dvSource, TekstProp);
            }

            
        }
        #endregion

        #region podmiotDelButton_Click
        private void podmiotDelButton_Click(object sender, RoutedEventArgs e)
        {
            clsValues();
        }
        #endregion

        #region TekstProp
        #region MyRegion
        public string TekstProp
        {
            get { return (string)GetValue(TekstPropProperty); }
            set { SetValue(TekstPropProperty, value); }
        }
        public static readonly DependencyProperty TekstPropProperty =
            DependencyProperty.Register("TekstProp", typeof(string), typeof(DataGridRaf), new PropertyMetadata(null,  new PropertyChangedCallback( OnTekstPropClick)));

        #endregion
        private static void OnTekstPropClick(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //MessageBox.Show("OnTekstPropClick");
            DataGridRaf u = d as DataGridRaf;
  
            if (u.TekstProp != null)
            {
                string query = $"{ u.colName} LIKE '%{ u.TekstProp}%'";
                u.dvSource.RowFilter = query;
            }
        }
        #endregion

        #region selectedItemRaf
        #region MyRegion

        public DataRowView selectedItemRaf
        {
            get { return (DataRowView)GetValue(selectedItemRafProperty); }
            set { SetValue(selectedItemRafProperty, value); }
        }

        public static readonly DependencyProperty selectedItemRafProperty =
            DependencyProperty.Register("selectedItemRaf", typeof(DataRowView), typeof(DataGridRaf), new PropertyMetadata(null, new PropertyChangedCallback(OnSelectedItemRaf)));

        #endregion
        private static void OnSelectedItemRaf(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataGridRaf u = d as DataGridRaf;
            if (u.selectedItemRaf != null)
                u.TekstProp = u.selectedItemRaf[u.colName].ToString();
        }
        #endregion

        #region selectedValueRaf
        #region MyRegion
        public object selectedValueRaf
        {
            get { return (object)GetValue(selectedValueRafProperty); }
            set { SetValue(selectedValueRafProperty, value); }
        }
        
        public static readonly DependencyProperty selectedValueRafProperty =
            DependencyProperty.Register("selectedValueRaf", typeof(object), typeof(DataGridRaf), new PropertyMetadata(null, new PropertyChangedCallback(onChangeSelectedValue), new CoerceValueCallback(OnCoerceValue)));

        #endregion

        private static object OnCoerceValue(DependencyObject d, object baseValue)
        {
           
            
            
            //string s = string.Empty;
            //if (u.selectedValueRaf != null)
            //{
            //    s = u.selectedValueRaf.ToString();
            //    MessageBox.Show($"Coerce:{s}");
            //}
            //else
            //{
            //    MessageBox.Show("Coerce No value");
            //}

            return baseValue;
        }

        private static void onChangeSelectedValue(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataGridRaf u = d as DataGridRaf;

            if (u.selectedValueRaf != null)
            {
                int row = int.Parse(u.selectedValueRaf.ToString());

                if (row > 0)
                {
                    u.selectedItemRaf = u.dataGridSource.DefaultView.Cast<DataRowView>().Where(r => r["id"].ToString() == row.ToString()).FirstOrDefault();
                    int a = 13;
                    //MessageBox.Show( row.ToString());
                    //var v = u.dataGridSource.AsEnumerable().FirstOrDefault(r => r["id"].ToString() == row.ToString());

                    //if (v != null)
                    //    u.selectedItemRaf = v.Table.DefaultView[0];
                }
            }
        }

        #endregion

        #region selectedValuePathRaf
        public string selectedValuePathRaf
        {
            get { return (string)GetValue(selectedValuePathRafProperty); }
            set { SetValue(selectedValuePathRafProperty, value); }
        }
        public static readonly DependencyProperty selectedValuePathRafProperty =
            DependencyProperty.Register("selectedValuePathRaf", typeof(string), typeof(DataGridRaf));
        #endregion

        public void clsValues()
        {
            TekstProp = string.Empty;
            selectedItemRaf = null;
            
        }       
        private void TekstPropRaf_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (!(e.NewFocus is DataGridCell))
            {
                if (selectedItemRaf != null)
                {
                    if (selectedItemRaf[colName].ToString() != TekstProp)
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