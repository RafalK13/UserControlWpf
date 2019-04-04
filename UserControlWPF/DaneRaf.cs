using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace UserControlWPF
{
    public class Person
    {
        public string name { get; set; }
        public string city { get; set; }
        public int age { get; set; }
    }

    public class List
    {
        public int id { get; set; }
    }

    public class DaneRaf : INotifyPropertyChanged
    {
        public ObservableCollection<Person> persons { get; set; }
        public DataTable dtSourceRaf { get; set; }
        public DataView dvSourceRaf { get; set; }

        public DataTable dtSourceList { get; set; }

        private string _selectedItem;
        public string selectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                NotifyPropertyChanged();
            }
        }

        private DataRowView _drvSelected;
        public DataRowView drvSelected
        {
            get => _drvSelected;
            set {
                    _drvSelected = value;
                    NotifyPropertyChanged();
            }
        }

        public string DaneRafTest { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _tekst;
        public string tekst
        {
            get => _tekst;
            set {
                _tekst = value;

                NotifyPropertyChanged();
            }
        }

        public string tekstRaf { get; set; }
        public DaneRaf()
        {
            init();
        }

        private void init()
        {
            persons = new ObservableCollection<Person>();
            dtSourceRaf = new DataTable();
            dtSourceList = new DataTable();

            initValues();
            tekst = "Class value";
            dvSourceRaf = new DataView(dtSourceRaf);
            //person = dvSourceRaf[1];          
        }

        private void initValues()
        {
           // initObservableList();
            initDataTable();
        }

        private void initObservableList()
        {
            persons.Add(new Person() { name = "Rafałek", city = "Gdańsk", age = 47 });
            persons.Add(new Person() { name = "Hanka", city = "Gdańsk", age = 11 });
            persons.Add(new Person() { name = "Beti", city = "Sybir", age = 48 });
        }

        private void initDataTable()
        {
            dtSourceRaf.Columns.AddRange( new DataColumn[] 
                                        {
                                          new DataColumn( "id", typeof(int)),
                                          new DataColumn( "name", typeof(string)),
                                          new DataColumn( "city", typeof(string)),
                                          new DataColumn("age", typeof(int)) });

           
            dtSourceRaf.Rows.Add(1,"Rafał", "Gdańsk", 47);
            dtSourceRaf.Rows.Add(3,"Rafał1", "Gdańsk", 47);
            dtSourceRaf.Rows.Add(5,"Rafał2", "Gdańsk", 47);
            dtSourceRaf.Rows.Add(7,"Rafał3", "Gdańsk", 47);
            dtSourceRaf.Rows.Add(9, "Rafał4", "Gdańsk", 47);
            dtSourceRaf.Rows.Add(10,"Rafał5", "Gdańsk", 47);
            dtSourceRaf.Rows.Add(11,"Rafał6", "Gdańsk", 47);
            dtSourceRaf.Rows.Add(12,"Hanula", "Gdańsk", 11);
            dtSourceRaf.Rows.Add(13,"Hanula1", "Gdańsk", 11);
            dtSourceRaf.Rows.Add(14,"Hanula2", "Gdańsk", 11);
            dtSourceRaf.Rows.Add(15,"Hanula3", "Gdańsk", 11);
            dtSourceRaf.Rows.Add(17,"Beti", "Sybir", 48);
            dtSourceRaf.Rows.Add(19,"Beti1", "Sybir", 48);
           

            dtSourceList.Columns.AddRange(new DataColumn[]
                                        { new DataColumn( "id", typeof(int)) });

            
            //dtSourceList.Rows.Add(1);
            //dtSourceList.Rows.Add(3);
         
            //dtSourceList.Rows.Add(2);
            //dtSourceList.Rows.Add(4);
            //dtSourceList.Rows.Add(6);

            //dtSourceList.Rows.Add(5);
            //dtSourceList.Rows.Add(7);
            //dtSourceList.Rows.Add(9);
            //dtSourceList.Rows.Add(11);
            //dtSourceList.Rows.Add(13);
            //dtSourceList.Rows.Add(15);
            //dtSourceList.Rows.Add(17);
            //dtSourceList.Rows.Add(19);
            //dtSourceList.Rows.Add(21);
            //dtSourceList.Rows.Add(23);



        }
    }

    class StringToInt : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int result;

            if (value == null)
                return 0;

            if (int.TryParse(value.ToString(), out result) == true)
                return result;
            else
                return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
            //int result;

            //if (value == null)
            //    return 0;

            //if (int.TryParse(value.ToString(), out result) == true)
            //    return result;
            //else
            //    return 0;
        }
    }
}
