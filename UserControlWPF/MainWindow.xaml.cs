﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserControlWPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string resultS = string.Empty;

        public MainWindow()
        {
            //Debug.AutoFlush = false;
            InitializeComponent();
           
            

            //FindLogicalTree(this);
        }

      
        //private void FindLogicalTree(DependencyObject parent)
        //{
        //    if (parent == null)
        //        return;

        //    var childs = LogicalTreeHelper.GetChildren( parent);

        //    foreach (var item in childs)
        //    {
        //        FrameworkElement s = item as FrameworkElement;
        //        if( s!= null)
        //        Debug.WriteLine($"Type: {item.GetType().ToString()}{'\t'}, Name: {s.Name}");
        //        FindLogicalTree(item as DependencyObject);

        //    }
        //}
    }
}
