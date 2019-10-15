using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

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

    public class Podmiot
    {
        public int id { get; set; }
        public string nazwa { get; set; }
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

        #region PodmiotList
        public List<Podmiot> podmiotList
        {
            get { return (List<Podmiot>)GetValue(podmiotListProperty); }
            set { SetValue(podmiotListProperty, value); }
        }

        public static readonly DependencyProperty podmiotListProperty =
            DependencyProperty.Register("podmiotList", typeof(List<Podmiot>), typeof(DataGridRaf));
        #endregion

        #region PodmiotListView
        public List<Podmiot> podmiotListView
        {
            get { return (List<Podmiot>)GetValue(podmiotListViewProperty); }
            set { SetValue(podmiotListViewProperty, value); }
        }

        public static readonly DependencyProperty podmiotListViewProperty =
            DependencyProperty.Register("podmiotListView", typeof(List<Podmiot>), typeof(DataGridRaf));

        #endregion

        #region DataTableGridSource
        public DataTable dataGridSource
        {
            get { return (DataTable)GetValue(dataGridSourceProperty); }
            set { SetValue(dataGridSourceProperty, value); }
        }

        public static readonly DependencyProperty dataGridSourceProperty =
            DependencyProperty.Register("dataGridSource", typeof(DataTable), typeof(DataGridRaf));
        #endregion

        #region DataViewdvSource
        public DataView dvSource
        {
            get { return (DataView)GetValue(dvSourceProperty); }
            set { SetValue(dvSourceProperty, value); }
        }

        public static readonly DependencyProperty dvSourceProperty =
            DependencyProperty.Register("dvSource", typeof(DataView), typeof(DataGridRaf));
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
            DataGridRaf u = d as DataGridRaf;
            if (u.TekstProp != null)
            {
                if (u.TekstProp.Length >= 3)
                {
                    u.podmiotListView = u.podmiotList.Where( r=> r.nazwa.Contains(u.TekstProp) == true).ToList();
                }
            }
        }
        #endregion

        #region selectedItemRaf
        public Podmiot selectedItemRaf
        {
            get { return (Podmiot)GetValue(selectedItemRafProperty); }
            set { SetValue(selectedItemRafProperty, value); }
        }

        public static readonly DependencyProperty selectedItemRafProperty =
            DependencyProperty.Register("selectedItemRaf", typeof(Podmiot), typeof(DataGridRaf));

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
            return baseValue;
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
                        //u.selectedItemRaf = u.dataGridSource.DefaultView.Cast<DataRowView>().Where(r => r["ID"].ToString() == result.ToString()).FirstOrDefault();

                        u.selectedItemRaf = u.podmiotListView.Where(r => r.id == result).FirstOrDefault();

                        if (u.selectedItemRaf == null)
                        {
                            u.TekstProp = string.Empty;
                        }
                        else
                        {
                            u.TekstProp = u.selectedItemRaf.nazwa;
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
            podmiotListView = null;
        }       

        private void TekstPropRaf_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (!(e.NewFocus is DataGridCell))
            {
                if (selectedItemRaf != null)
                {
                    if (selectedItemRaf.nazwa.ToString() != TekstProp)
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