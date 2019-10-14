using System;
using System.Collections.Generic;
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


namespace WpfControlLibraryRaf
{

    public class NumberRows : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int result;

            if (value == null)
                return 0;

            if (int.TryParse(value.ToString(), out result) == true)
                return result * 13;
            else
                return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


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
            DependencyProperty.Register("TekstProp", typeof(string), typeof(DataGridRaf), new PropertyMetadata(null,  new PropertyChangedCallback( OnTekstPropChanged)));

        #endregion
        private static void OnTekstPropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //int a = 1;

            //MessageBox.Show("OnTekstPropChanged");

            DataGridRaf u = d as DataGridRaf;
            if (u.TekstProp != null)
            {
                if (u.dvSource != null)
                {
                    string query = $"{ u.colName} LIKE '%{ u.TekstProp}%'";
                    u.dvSource.RowFilter = query;
                }
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
        private static object OnCoerceSelectedItemRaf(DependencyObject d, object baseValue)
        {
            //MessageBox.Show("OnCoerceSelectedItemRaf");
            return baseValue;
        }

        private static void OnSelectedItemRaf(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //int a = 1;
            //MessageBox.Show("OnSelectedItemRaf");
            //DataGridRaf u = d as DataGridRaf;

            //if (u.selectedItemRaf != null)
            //{
            //    //var v = u.dataGridSource.AsEnumerable().Where(r => r["id"].ToString() == result.ToString()).FirstOrDefault())
            //        u.TekstProp = u.selectedItemRaf[u.colName].ToString();
            //}

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
            DependencyProperty.Register("selectedValueRaf", typeof(object), typeof(DataGridRaf), new PropertyMetadata(null, new PropertyChangedCallback(OnSelectedValue), new CoerceValueCallback( OnCoerceValueRaf)));

        #endregion
        private static object OnCoerceValueRaf(DependencyObject d, object baseValue)
        {
            //MessageBox.Show( $"OnCoerceValueRaf, baseValue: {baseValue.ToString()}");
            //DataGridRaf u = d as DataGridRaf;
            //int result;

            //if (int.TryParse(baseValue.ToString().ToString(), out result) == true)
            //{
            //    u.selectedItemRaf = u.dataGridSource.DefaultView.Cast<DataRowView>().Where(r => r["id"].ToString() == result.ToString()).FirstOrDefault();
            //}

            return baseValue;
            
            //DataGridRaf u = d as DataGridRaf;
            //int result;
            //if (baseValue != null)
            //{
            //    if (int.TryParse(baseValue.ToString().ToString(), out result) == true)
            //    {
            //        if (result == 0)
            //        {
            //            u.selectedItemRaf = null;
            //            u.TekstProp = string.Empty;
            //        }
            //        else
            //        {
            //            u.selectedItemRaf = u.dataGridSource.DefaultView.Cast<DataRowView>().Where(r => r["id"].ToString() == result.ToString()).FirstOrDefault();
            //            if (u.selectedItemRaf == null)
            //            {
            //                u.TekstProp = null;
            //            }
            //        }
            //    }
            //}

            //return baseValue;
        }

        private static void OnSelectedValue(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataGridRaf u = d as DataGridRaf;
            int result;

            if (u.selectedValueRaf != null)
            {
                if (Convert.IsDBNull(u.selectedValueRaf))
                {
                    u.selectedItemRaf = null;
                    u.TekstProp = string.Empty;
                }
                else
                {
                    int.TryParse(u.selectedValueRaf.ToString().ToString(), out result);

                    if (result == 0)
                    {
                        u.selectedItemRaf = null;
                        u.TekstProp = string.Empty;
                    }
                    else
                    {
                        u.selectedItemRaf = u.dataGridSource.DefaultView.Cast<DataRowView>().Where(r => r["ID"].ToString() == result.ToString()).FirstOrDefault();

                        if (u.selectedItemRaf == null)
                        {
                            u.TekstProp = string.Empty;
                        }
                        else
                        {
                            
                            u.TekstProp = u.selectedItemRaf[u.colName].ToString();
                        }
                    }
                }
                
            }
        }
        #endregion

        #region selectedValuePathRaf
        #region MyRegion
        public string selectedValuePathRaf
        {
            get { return (string)GetValue(selectedValuePathRafProperty); }
            set { SetValue(selectedValuePathRafProperty, value); }
        }

        public static readonly DependencyProperty selectedValuePathRafProperty =
           DependencyProperty.Register("selectedValuePathRaf", typeof(string), typeof(DataGridRaf), new PropertyMetadata("ID"));
        #endregion

        #endregion

        public void clsValues()
        {
            TekstProp = string.Empty;
            selectedItemRaf = null;
            selectedValueRaf = 0;
            
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