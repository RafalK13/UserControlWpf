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

            TekstPropRafALL.TextChanged += TekstPropRafALL_TextChanged;
        }

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

        #region itemSourceRafALL
        public IEnumerable itemSourceRafALL
        {
            get { return (IEnumerable)GetValue(itemSourceRafALLProperty); }
            set { SetValue(itemSourceRafALLProperty, value); }
        }

        public static readonly DependencyProperty itemSourceRafALLProperty =
            DependencyProperty.Register("itemSourceRafALL", typeof(IEnumerable), typeof(DataGridRafALL));
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

        #region listToDisplay
        public List<DataGridTab> listToDisplay
        {
            get { return (List<DataGridTab>)GetValue(listToDisplayProperty); }
            set { SetValue(listToDisplayProperty, value); }
        }

        public static readonly DependencyProperty listToDisplayProperty =
            DependencyProperty.Register("listToDisplay", typeof(List<DataGridTab>), typeof(DataGridRafALL));
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
                    u.listToDisplay = u.itemSourceList.Where(r => r.nazwa.ToUpper().Contains(u.TekstPropALL.ToUpper()) == true).ToList();
                }
            }
        }
        #endregion

        #region selectedItemRafALL
        public DataGridTab selectedItemRafALL
        {
            get { return (DataGridTab)GetValue(selectedItemRafALLProperty); }
            set { SetValue(selectedItemRafALLProperty, value); }
        }

        public static readonly DependencyProperty selectedItemRafALLProperty =
            DependencyProperty.Register("selectedItemRafALL", typeof(DataGridTab), typeof(DataGridRafALL), new PropertyMetadata( null, onSelectedItemRafALLChenged));

        private static void onSelectedItemRafALLChenged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataGridRafALL u = d as DataGridRafALL;

            if (u.selectedItemRafALL != null)
            {
                u.TekstPropALL = u.selectedItemRafALL.nazwa;
                u.selectedIdRafALL = u.selectedItemRafALL.id;
            }
        }
        #endregion

        #region selectedIdRafALL
        public int selectedIdRafALL
        {
            get { return (int)GetValue(selectedIdRafALLProperty); }
            set { SetValue(selectedIdRafALLProperty, value); }
        }

        public static readonly DependencyProperty selectedIdRafALLProperty =
            DependencyProperty.Register("selectedIdRafALL", typeof(int), typeof(DataGridRafALL));

        #endregion

        #region clsValues
        public void clsValuesOnExit()
        {
            selectedItemRafALL = null;
        }

        public void clsValues()
        {
            TekstPropALL = string.Empty;
            selectedItemRafALL = null;
            selectedIdRafALL = 0;
            listToDisplay = null;
        }

        public bool clearTekstOnExit
        {
            get { return (bool)GetValue(clearTekstOnExitProperty); }
            set { SetValue(clearTekstOnExitProperty, value); }
        }
        public static readonly DependencyProperty clearTekstOnExitProperty =
           DependencyProperty.Register("clearTekstOnExit", typeof(bool), typeof(DataGridRafALL), new PropertyMetadata(true));
        #endregion

        #region events
        public event EventHandler UserControlChanged;

        private void TekstPropRafALL_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (UserControlChanged != null)
            {
                if (TekstPropALL.Count() >= 3)
                    UserControlChanged(this, EventArgs.Empty);
            }
        }

        

        #region podmiotDelButton_ClickALL
        private void podmiotDelButton_ClickALL(object sender, RoutedEventArgs e)
        {
            clsValues();
        }
        #endregion

       private void DockPanel_Loaded(object sender, RoutedEventArgs e)
        {
            if (itemSourceRafALL != null)
            {
                itemSourceList = itemSourceRafALL.Cast<object>().Select(row => new DataGridTab()
                {
                    id = int.Parse(row.GetType().GetProperty(colNameIdRaf).GetValue(row).ToString()),
                    nazwa = row.GetType().GetProperty(colNameRaf).GetValue(row).ToString()
                }).ToList();
            }
        }

        private void TekstPropRafALL_LostFocus(object sender, RoutedEventArgs e)
        {
            if(TekstPropALL != null)
            {
                if (TekstPropALL.Count() >= 3)
                {
                    if (clearTekstOnExit == true)
                    {
                        TekstPropALL = string.Empty;
                        selectedIdRafALL = 0;
                        selectedItemRafALL = null;
                    }
                    else
                    {
                        selectedItemRafALL = listToDisplay.FirstOrDefault(r => r.nazwa == TekstPropALL);

                        if (selectedItemRafALL != null)
                        {
                            selectedIdRafALL = selectedItemRafALL.id;
                        }
                    }
                }
            }
        }
        #endregion
    }
}
