using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UserControlWPF
{
    public class Car
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class CarsRaf : INotifyPropertyChanged
    {
        public ObservableCollection<Car> cars { get; set; }

        private int _idRaf;
        public int idRaf
        {
            get => _idRaf;

            set
            {
                _idRaf = value;
                NotifyPropertyChanged( "idRaf");
            }
        }

        public CarsRaf()
        {

            idRaf = 2;
            cars = new ObservableCollection<Car>()
            {
                new Car(){ id=1, name="Audi"},
                new Car(){ id=2, name="BMW"},
                new Car(){ id=3, name="VW"},
                new Car(){ id=4, name="Fiat"},
                new Car(){ id=5, name="Peugeot"},
                new Car(){ id=6, name="Renault"},
                new Car(){ id=7, name="Awatar"},
                new Car(){ id=11, name=" AudiQ1"},
                new Car(){ id=8, name=" AudiQ3"},
                new Car(){ id=9, name=" AudiQ5"},
                new Car(){ id=10, name="Wardburg"}
            };

           
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
