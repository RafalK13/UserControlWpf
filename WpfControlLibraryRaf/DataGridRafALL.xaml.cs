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

        #region colNameRaf
        public string colNameRaf
        {
            get { return (string)GetValue(colNameRafProperty); }
            set { SetValue(colNameRafProperty, value); }
        }

        public static readonly DependencyProperty colNameRafProperty =
            DependencyProperty.Register("colNameRaf", typeof(string), typeof(DataGridRafALL), new PropertyMetadata("nazwa"));
        #endregion

        #region colNameIdRaf
        public string colNameIdRaf
        {
            get { return (string)GetValue(colNameIdRafProperty); }
            set { SetValue(colNameIdRafProperty, value); }
        }

        public static readonly DependencyProperty colNameIdRafProperty =
            DependencyProperty.Register("colNameIdRaf", typeof(string), typeof(DataGridRafALL), new PropertyMetadata("id"));
        #endregion

        #region listToDisplay
        public List<DataGridTab> listToDisplay
        {
            get { return (List<DataGridTab>)GetValue(listToDisplayProperty); }
            set { SetValue(listToDisplayProperty, value); }
        }

        public static readonly DependencyProperty listToDisplayProperty =
            DependencyProperty.Register("listToDisplay", typeof(List<DataGridTab>), typeof(DataGridRafALL));
        #endregion

        #region itemSourceList
        public List<DataGridTab> itemSourceList
        {
            get { return (List<DataGridTab>)GetValue(itemSourceListProperty); }
            set { SetValue(itemSourceListProperty, value); }
        }

        public static readonly DependencyProperty itemSourceListProperty =
            DependencyProperty.Register("itemSourceList", typeof(List<DataGridTab>), typeof(DataGridRafALL));
        #endregion

        #region fontSizeRafALL
        public int fontSizeRafALL
        {
            get { return (int)GetValue(fontSizeRafALLProperty); }
            set { SetValue(fontSizeRafALLProperty, value); }
        }
        public static readonly DependencyProperty fontSizeRafALLProperty =
            DependencyProperty.Register("fontSizeRafALL", typeof(int), typeof(DataGridRaf), new PropertyMetadata(14));

        #endregion
       
        #region heightRafALL
        public int heightRafALL
        {
            get { return (int)GetValue(heightRafALLProperty); }
            set { SetValue(heightRafALLProperty, value); }
        }

        public static readonly DependencyProperty heightRafALLProperty =
            DependencyProperty.Register("heightRafALL", typeof(int), typeof(DataGridRaf), new PropertyMetadata(25));
        #endregion

        #region podmiotDelButton_ClickALL
        private void podmiotDelButton_ClickALL(object sender, RoutedEventArgs e)
        {
            clsValues();
        }
        #endregion

        #region TekstPropALL
        public string TekstPropALL
        {
            get { return (string)GetValue(TekstPropALLProperty); }
            set { SetValue(TekstPropALLProperty, value); }
        }
        public static readonly DependencyProperty TekstPropALLProperty =
            DependencyProperty.Register("TekstPropALL", typeof(string), typeof(DataGridRafALL), new PropertyMetadata(null,  new PropertyChangedCallback(OnTekstPropChangedALL)));

        private static void OnTekstPropChangedALL(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataGridRafALL u = d as DataGridRafALL;
            
            if (u.TekstPropALL != null)
            {
                if (u.TekstPropALL.Length >= 3)
                {
                    u.listToDisplay = u.itemSourceList.Where(r => r.nazwa.Contains(u.TekstPropALL) == true).ToList();
                }
            }
        }
        #endregion

        #region ToHide
        #region selectedItemRafALL
        public DataGridTab selectedItemRafALL
        {
            get { return (DataGridTab)GetValue(selectedItemRafALLProperty); }
            set { SetValue(selectedItemRafALLProperty, value); }
        }

        public static readonly DependencyProperty selectedItemRafALLProperty =
            DependencyProperty.Register("selectedItemRafALL", typeof(DataGridTab), typeof(DataGridRafALL));

        #endregion

        #region selectedValueRafALL
        #region MyRegion
        public object selectedValueRafALL
        {
            get { return (object)GetValue(selectedValueRafALLProperty); }
            set { SetValue(selectedValueRafALLProperty, value); }
        }

        public static readonly DependencyProperty selectedValueRafALLProperty =
            DependencyProperty.Register("selectedValueRafALL", typeof(object), typeof(DataGridRafALL), new PropertyMetadata(null, new PropertyChangedCallback(OnSelectedValue), new CoerceValueCallback(OnCoerceValueRaf)));

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
                        u.selectedItemRafALL = u.listToDisplay.Where(r => r.id == result).FirstOrDefault();

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
            listToDisplay = null;
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
        #endregion

        private void DockPanel_Loaded(object sender, RoutedEventArgs e)
        {
            itemSourceList = itemSourceRafALL.Cast<object>().Select(row => new DataGridTab()
            {
                id = int.Parse(row.GetType().GetProperty(colNameIdRaf).GetValue(row).ToString()),
                nazwa = row.GetType().GetProperty(colNameRaf).GetValue(row).ToString()
            }).ToList();

            listToDisplay = itemSourceList;
           
        }
    }
}
