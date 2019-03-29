using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDependencyProperty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Employee emp = new Employee();
            emp.EmpId = 100;

            // set the same value
            emp.EmpId = 100;

            // set the different value
            emp.EmpId = 101;

            Content = emp.Message;
        }
    }

    public class Employee : DependencyObject
    {
        public String Message
        { get; set; }

        public static readonly DependencyProperty EmpIdProperty =
            DependencyProperty.Register("EmpId", typeof(int), typeof(Employee),
            new PropertyMetadata(0,
                new PropertyChangedCallback(EmpIdCallBack),
                new CoerceValueCallback(CoerceEmpId)));

        public int EmpId
        {
            get { return (int)GetValue(EmpIdProperty); }
            set { SetValue(EmpIdProperty, value); }
        }

        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(Employee));

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // If employee id is greater than 1000 then make it 1000
        static void EmpIdCallBack(DependencyObject d,
            DependencyPropertyChangedEventArgs args)
        {
            Employee emp = d as Employee;

            emp.Message += "EmpIDCallBack Value = " + emp.EmpId;
            emp.Message += "\n———————–\n";

            if (emp.EmpId >= 1000)
            {
                emp.EmpId = 1000;
            }
        }

        // If the employee Id is negative then make it positive
        static Object CoerceEmpId(DependencyObject d, Object baseValue)
        {
            Employee emp = d as Employee;

            int value = (int)baseValue;

            emp.Message += "CoerceEmpId Value = " + value;
            emp.Message += "\n———————–\n";

            if (value < 0)
                return value * -1;
            else
                return value;
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            Message += e.Property + " Dependency Property Changed";
            Message += "\nOld Value = " + e.OldValue + "\nNew Value = " + e.NewValue;
            Message += "\n———————–\n";

            base.OnPropertyChanged(e);
        }
    }
}