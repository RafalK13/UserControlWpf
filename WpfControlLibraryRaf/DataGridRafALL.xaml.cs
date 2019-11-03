using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfControlLibraryRaf
{
    public class DataGridTab
    {
        public int id { get; set; }
        public string nazwa { get; set; }
    }

    public partial class DataGridRafALL : UserControl
    {
        public DataGridRafALL()
        {
            InitializeComponent();
            DataContext = this;
        }

        #region itemSourceRafALL
        public IEnumerable itemSourceRafALL
        {
            get { return (IEnumerable)GetValue(itemSourceRafALLProperty); }
            set { SetValue(itemSourceRafALLProperty, value); }
        }

        public static readonly DependencyProperty itemSourceRafALLProperty =
            DependencyProperty.Register("itemSourceRafALL", typeof(IEnumerable), typeof(DataGridRafALL)  );
        #endregion

       

        public List<DataGridTab> listToDisp
        {
            get
            {
                if (itemSourceRafALL != null)
                {
                    Type rowType = itemSourceRafALL.GetType().GetGenericArguments().First();

                    var tab = itemSourceRafALL.Cast<object>();

                    var t = tab.Select(row => new
                    {
                        id = rowType.GetType().GetProperty("id").GetValue(row),
                        nazwa = rowType.GetType().GetProperty("nazwa").GetValue(row)
                    });
                    var n = t.Cast<DataGridTab>().ToList();

                    //int a = 13;

                    return n;
                }
                return null;
            }
        }

        #region fontSizeRaf

        //public int fontSizeRaf
        //{
        //    get { return (int)GetValue(fontSizeProperty); }
        //    set { SetValue(fontSizeProperty, value); }
        //}

        //public static readonly DependencyProperty fontSizeProperty =
        //    DependencyProperty.Register("fontSizeRaf", typeof(int), typeof(DataGridRaf), new PropertyMetadata(14));

        #endregion       

        #region heightRaf
        //public int heightRaf
        //{
        //    get { return (int)GetValue(heightRafProperty); }
        //    set { SetValue(heightRafProperty, value); }
        //}

        //public static readonly DependencyProperty heightRafProperty =
        //    DependencyProperty.Register("heightRaf", typeof(int), typeof(DataGridRaf), new PropertyMetadata(25));
        #endregion

        #region podmiotDelButton_ClickALL
        private void podmiotDelButton_ClickALL(object sender, RoutedEventArgs e)
        {
            clsValues();
        }
        #endregion

        #region TekstPropALL
        #region MyRegion
        public string TekstPropALL
        {
            get { return (string)GetValue(TekstPropALLProperty); }
            set { SetValue(TekstPropALLProperty, value); }
        }
        public static readonly DependencyProperty TekstPropALLProperty =
            DependencyProperty.Register("TekstPropALL", typeof(string), typeof(DataGridRaf), new PropertyMetadata(null, new PropertyChangedCallback(OnTekstPropChangedALL)));

        #endregion
        private static void OnTekstPropChangedALL(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataGridRafALL u = d as DataGridRafALL;
            if (u.TekstPropALL != null)
            {
                if (u.TekstPropALL.Length >= 3)
                {
                    //u.podmiotListView = u.podmiotList.Where(r => r.nazwa.Contains(u.TekstPropALL) == true).ToList();
                }
            }
        }
        #endregion

        #region selectedItemRafALL
        public Podmiot selectedItemRafALL
        {
            get { return (Podmiot)GetValue(selectedItemRafALLProperty); }
            set { SetValue(selectedItemRafALLProperty, value); }
        }

        public static readonly DependencyProperty selectedItemRafALLProperty =
            DependencyProperty.Register("selectedItemRafALL", typeof(Podmiot), typeof(DataGridRaf));

        #endregion

        #region selectedValueRafALL
        #region MyRegion
        public object selectedValueRafALL
        {
            get { return (object)GetValue(selectedValueRafALLProperty); }
            set { SetValue(selectedValueRafALLProperty, value); }
        }

        public static readonly DependencyProperty selectedValueRafALLProperty =
            DependencyProperty.Register("selectedValueRafALL", typeof(object), typeof(DataGridRaf), new PropertyMetadata(null, new PropertyChangedCallback(OnSelectedValue), new CoerceValueCallback(OnCoerceValueRaf)));

        #endregion
        private static object OnCoerceValueRaf(DependencyObject d, object baseValue)
        {
            return baseValue;
        }

        private static void OnSelectedValue(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataGridRafALL u = d as DataGridRafALL;
            int result;

            if (u.selectedValueRafALL != null)
            {
                if (Convert.IsDBNull(u.selectedValueRafALL))
                {
                    u.selectedItemRafALL = null;
                    u.TekstPropALL = string.Empty;
                }
                else
                {
                    int.TryParse(u.selectedValueRafALL.ToString().ToString(), out result);

                    if (result == 0)
                    {
                        u.selectedItemRafALL = null;
                        u.TekstPropALL = string.Empty;
                    }
                    else
                    {


                        //u.selectedItemRaf = u.podmiotListView.Where(r => r.id == result).FirstOrDefault();

                        if (u.selectedItemRafALL == null)
                        {
                            u.TekstPropALL = string.Empty;
                        }
                        else
                        {
                            u.TekstPropALL = u.selectedItemRafALL.nazwa;
                        }
                    }
                }

            }
        }
        #endregion

        #region selectedValuePathRafALL
        #region MyRegion
        public string selectedValuePathRafALL
        {
            get { return (string)GetValue(selectedValuePathRafProperty); }
            set { SetValue(selectedValuePathRafProperty, value); }
        }

        public static readonly DependencyProperty selectedValuePathRafProperty =
           DependencyProperty.Register("selectedValuePathRafALL", typeof(string), typeof(DataGridRaf), new PropertyMetadata("ID"));
        #endregion

        #endregion

        public void clsValues()
        {
            TekstPropALL = string.Empty;
            selectedItemRafALL = null;
            selectedValueRafALL = 0;
            //podmiotListView = null;
        }

        private void TekstPropRafALL_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (!(e.NewFocus is DataGridCell))
            {
                if (selectedItemRafALL != null)
                {
                    if (selectedItemRafALL.nazwa.ToString() != TekstPropALL)
                        clsValues();
                }
                else
                {
                    clsValues();
                }
            }
        }

        private void DockPanel_Loaded(object sender, RoutedEventArgs e)
        {
          
        }
    }
}
