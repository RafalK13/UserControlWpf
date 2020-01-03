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
        public Guid guid { get; set; }
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
            DependencyProperty.Register("fontSizeRafALL", typeof(int), typeof(DataGridRaf), new PropertyMetadata(12));

        #endregion

        #region heightRafALL
        public int heightRafALL
        {
            get { return (int)GetValue(heightRafALLProperty); }
            set { SetValue(heightRafALLProperty, value); }
        }

        public static readonly DependencyProperty heightRafALLProperty =
            DependencyProperty.Register("heightRafALL", typeof(int), typeof(DataGridRaf), new PropertyMetadata(18));
        #endregion

        #region colNameGUID

        public string colNameGUID
        {
            get { return (string)GetValue(colNameGUIDProperty); }
            set { SetValue(colNameGUIDProperty, value); }
        }

        public static readonly DependencyProperty colNameGUIDProperty =
            DependencyProperty.Register("colNameGUID", typeof(string), typeof(DataGridRafALL), new PropertyMetadata(null));

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
            DependencyProperty.Register("itemSourceRafALL", typeof(IEnumerable), typeof(DataGridRafALL), new PropertyMetadata(null, new PropertyChangedCallback( onItemSourceRafALLChanged) ));

        private static void onItemSourceRafALLChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //MessageBox.Show("itemSourceRafALL");
        }
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

        #region selectedGUID

        public Guid selectedGUID
        {
            get { return (Guid)GetValue(selectedGUIDProperty); }
            set { SetValue(selectedGUIDProperty, value); }
        }
        
        public static readonly DependencyProperty selectedGUIDProperty =
            DependencyProperty.Register("selectedGUID", typeof(Guid), typeof( DataGridRafALL), new PropertyMetadata(null));

        #endregion

        #region TekstPropALL
        public string TekstPropALL
        {
            get { return (string)GetValue(TekstPropALLProperty); }
            set { SetValue(TekstPropALLProperty, value); }
        }
        public static readonly DependencyProperty TekstPropALLProperty =
            DependencyProperty.Register("TekstPropALL", typeof(string), typeof(DataGridRafALL), new PropertyMetadata(null, new PropertyChangedCallback(OnTekstPropChangedALL)));

        private static void OnTekstPropChangedALL(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataGridRafALL u = d as DataGridRafALL;

            if (u.TekstPropALL != null)
            {
                if (u.TekstPropALL.Length >= 2)
                {
                    u.listToDisplay = u.itemSourceList.Where(r => r.nazwa.ToUpper().Contains(u.TekstPropALL.ToUpper()) == true).ToList();

                    if (u.listToDisplay.Count() == 0)
                        u.selectedIdRafALL = -3;
                    else
                    {
                        var v = u.listToDisplay.FirstOrDefault(row => row.nazwa == u.TekstPropALL);
                        //var v = u.listToDisplay.FirstOrDefault(row => row.nazwa.Contains(u.TekstPropALL));
                        if (v != null)
                        {
                            u.selectedIdRafALL = v.id;
                            //MessageBox.Show(u.selectedIdRafALL.ToString());
                        }
                        else
                        {
                            u.selectedIdRafALL = -3;
                        }
                    }
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
            DependencyProperty.Register("selectedItemRafALL", typeof(DataGridTab), typeof(DataGridRafALL), new PropertyMetadata(null, onSelectedItemRafALLChenged));

        private static void onSelectedItemRafALLChenged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataGridRafALL u = d as DataGridRafALL;

            if (u.selectedItemRafALL != null)
            {
                u.TekstPropALL = u.selectedItemRafALL.nazwa;
                u.selectedIdRafALL = u.selectedItemRafALL.id;
                u.selectedGUID = u.selectedItemRafALL.guid;
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
            DependencyProperty.Register("selectedIdRafALL", typeof(int), typeof(DataGridRafALL), new PropertyMetadata(0, new PropertyChangedCallback(onChangeSelectedIdRafALL)));

        private static void onChangeSelectedIdRafALL(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataGridRafALL u = d as DataGridRafALL;

            if (u.itemSourceList != null)
            {
                var v = u.itemSourceList.FirstOrDefault(r => r.id == u.selectedIdRafALL);

                if (v != null)
                {
                    u.TekstPropALL = v.nazwa;
                    u.selectedGUID = v.guid;
                }
                else
                {
                    if (u.selectedIdRafALL != -3)
                    {
                        //u.TekstPropALL = string.Empty;    //2020-01-03
                        u.listToDisplay = null;
                    }
                }
            }
        }

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
                if (TekstPropALL.Count() >= 2)
                    UserControlChanged(this, EventArgs.Empty);
            }
        }

        #region podmiotDelButton_ClickALL
        private void podmiotDelButton_ClickALL(object sender, RoutedEventArgs e)
        {
            clsValues();
        }
        #endregion

        public void initItemSourceList()
        {
            if (itemSourceRafALL != null)
            {
                if (colNameGUID == null)
                {
                    //MessageBox.Show("No GUID");
                    itemSourceList = itemSourceRafALL.Cast<object>().Select(row => new DataGridTab()
                    {
                        id = int.Parse(row.GetType().GetProperty(colNameIdRaf).GetValue(row).ToString()),
                        nazwa = row.GetType().GetProperty(colNameRaf).GetValue(row).ToString()
                    }).ToList();
                }
                else
                {
                    //MessageBox.Show("With GUID");
                    itemSourceList = itemSourceRafALL.Cast<object>().Select(row => new DataGridTab()
                    {
                        id = int.Parse(row.GetType().GetProperty(colNameIdRaf).GetValue(row).ToString()),
                        nazwa = row.GetType().GetProperty(colNameRaf).GetValue(row).ToString(),
                        guid = Guid.Parse(row.GetType().GetProperty(colNameGUID).GetValue(row).ToString())
                    }).ToList();
                }
            }
        }

        private void DockPanel_Loaded(object sender, RoutedEventArgs e)
        {
            initItemSourceList();
        }

        private void TekstPropRafALL_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TekstPropALL != null)
            {
                if (TekstPropALL.Count() >= 2)
                {
                    if (clearTekstOnExit == true)
                    {
                        TekstPropALL = string.Empty;
                        selectedIdRafALL = -3;
                        selectedItemRafALL = null;
                    }
                    else
                    {
                        //var sel = listToDisplay.FirstOrDefault(r => r.nazwa == TekstPropALL);

                        //if (sel != null)
                        //{
                        //    selectedIdRafALL = sel.id;
                        //}
                        //else
                        //{
                        //    selectedIdRafALL = -1;
                        //}
                    }
                }
            }
        }
        #endregion
        
        public int selectedId
        {
            get { return (int)GetValue(selectedIdProperty); }
            set { SetValue(selectedIdProperty, value); }
        }

        public static readonly DependencyProperty selectedIdProperty =
            DependencyProperty.Register("selectedId", typeof(int), typeof(DataGridRafALL));
        
    }
}
