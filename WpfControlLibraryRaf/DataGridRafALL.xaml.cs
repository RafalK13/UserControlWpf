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

        public bool clearTekstOnExit
        {
            get { return (bool)GetValue(clearTekstOnExitProperty); }
            set { SetValue(clearTekstOnExitProperty, value); }
        }

        public static readonly DependencyProperty clearTekstOnExitProperty =
            DependencyProperty.Register("clearTekstOnExit", typeof(bool), typeof(DataGridRafALL), new PropertyMetadata(true));
        
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

        public int selectedIdRafALL
        {
            get { return (int)GetValue(selectedIdRafALLProperty); }
            set { SetValue(selectedIdRafALLProperty, value); }
        }

        public static readonly DependencyProperty selectedIdRafALLProperty =
            DependencyProperty.Register("selectedIdRafALL", typeof(int), typeof(DataGridRafALL));

        #endregion

        //#region selectedValueRafALL

        //public object selectedValueRafALL
        //{
        //    get { return (object)GetValue(selectedValueRafALLProperty); }
        //    set { SetValue(selectedValueRafALLProperty, value); }
        //}

        //public static readonly DependencyProperty selectedValueRafALLProperty =
        //    DependencyProperty.Register("selectedValueRafALL", typeof(object), typeof(DataGridRafALL));//, new PropertyMetadata(null, new PropertyChangedCallback(OnSelectedValue)));//, new CoerceValueCallback(OnCoerceValueRaf)));

        //private static object OnCoerceValueRaf(DependencyObject d, object baseValue)
        //{
        //    //return baseValue;
        //    return baseValue;
        //}

        //private static void OnSelectedValue(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    //MessageBox.Show("selectedValueRafALL");
        //    DataGridRafALL u = d as DataGridRafALL;
        //    int result;

        //    if (u.selectedValueRafALL != null)
        //    {
        //        if (Convert.IsDBNull(u.selectedValueRafALL))
        //        {
        //            u.selectedItemRafALL = null;
        //            u.TekstPropALL = string.Empty;
        //        }
        //        else
        //        {
        //            int.TryParse(u.selectedValueRafALL.ToString().ToString(), out result);

        //            if (result == 0)
        //            {
        //                u.selectedItemRafALL = null;
        //                u.TekstPropALL = string.Empty;
        //            }
        //            else
        //            {
        //                u.selectedItemRafALL = u.listToDisplay.Where(r => r.id == result).FirstOrDefault();
                        
        //                if (u.selectedItemRafALL == null)
        //                {
        //                    u.TekstPropALL = string.Empty;
        //                }
        //                else
        //                {
        //                    u.TekstPropALL = u.selectedItemRafALL.nazwa;
        //                }
        //            }
        //        }
        //    }
        //}
        //#endregion

        //#region selectedValuePathRafALL
        //public string selectedValuePathRafALL
        //{
        //    get { return (string)GetValue(selectedValuePathRafProperty); }
        //    set { SetValue(selectedValuePathRafProperty, value); }
        //}

        //public static readonly DependencyProperty selectedValuePathRafProperty =
        //   DependencyProperty.Register("selectedValuePathRafALL", typeof(string), typeof(DataGridRaf), new PropertyMetadata("ID"));

        //#endregion

        public void clsValuesOnExit()
        {
            selectedItemRafALL = null;
        }

        public void clsValues()
        {
            TekstPropALL = string.Empty;
            selectedItemRafALL = null;
            //selectedValueRafALL = null;
            selectedIdRafALL = 0;
            listToDisplay = null;
        }

        private bool testIdentity()
        {
            var v = listToDisplay.FirstOrDefault(r => r.nazwa == TekstPropALL);

            if (v != null)
            {
                selectedIdRafALL = v.id;

                if (selectedItemRafALL != null)
                {
                    selectedItemRafALL.id = selectedIdRafALL;
                    selectedItemRafALL.nazwa = TekstPropALL;
                }
                
                return true;
            }
            selectedIdRafALL = 0;
            selectedItemRafALL = null;

            return false;
        }
        
        private void TekstPropRafALL_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {

            //MessageBox.Show("Lost");
            //clearTekstOnExit = true;

            //if (!(e.NewFocus is DataGridCell))
            //{
            //    MessageBox.Show("DataGridCell");
            //    if (selectedItemRafALL != null)
            //    {
            //        if (selectedItemRafALL.nazwa.ToString() != TekstPropALL)
            //        {
            //            MessageBox.Show("1");
            //            clsValuesOnExit();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Żart");
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("2");
            //        clsValuesOnExit();
            //    }
            //}
        }

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
            //clearTekstOnExit = false;
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

                    //if(selectedItemRafALL!= null)
                    //MessageBox.Show($"{selectedIdRafALL}\r\n{selectedItemRafALL.nazwa}");
                }
            }
        }
    }
}
