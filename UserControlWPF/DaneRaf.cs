using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UserControlWPF
{
    public class Person
    {
        public string name { get; set; }
        public string city { get; set; }
        public int age { get; set; }
    }

    public class DaneRaf
    {
        public ObservableCollection<Person> persons { get; set; }
        public DataTable dtSourceRaf { get; set; }
        public DataView dvSourceRaf { get; set; }

        public string DaneRafTest { get; set; }
        public string tekst { get; set; }

        public DataRowView person { get; set; }

        public DaneRaf()
        {
            init();
        }

        private void init()
        {
            persons = new ObservableCollection<Person>();
            dtSourceRaf = new DataTable();
            
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
                                        { new DataColumn( "name", typeof(string)),
                                          new DataColumn( "city", typeof(string)),
                                          new DataColumn("age", typeof(int)) });

            dtSourceRaf.Rows.Add("Rafał", "Gdańsk", 47);
            dtSourceRaf.Rows.Add("Rafał1", "Gdańsk", 47);
            dtSourceRaf.Rows.Add("Rafał2", "Gdańsk", 47);
            dtSourceRaf.Rows.Add("Rafał3", "Gdańsk", 47);
            dtSourceRaf.Rows.Add("Hanula", "Gdańsk", 11);
            dtSourceRaf.Rows.Add("Hanula1", "Gdańsk", 11);
            dtSourceRaf.Rows.Add("Hanula2", "Gdańsk", 11);
            dtSourceRaf.Rows.Add("Hanula3", "Gdańsk", 11);
            dtSourceRaf.Rows.Add("Beti", "Sybir", 48);
            dtSourceRaf.Rows.Add("Beti1", "Sybir", 48);
            dtSourceRaf.Rows.Add("Beti2", "Sybir", 48);
            dtSourceRaf.Rows.Add("Beti3", "Sybir", 48);

        }
    }
}
