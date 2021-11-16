using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HW3
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        private Car _selectedCar;
        private ICommand _addCommand;
        private ICommand _removeCommand;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Car> Cars { get; set; }


        public ApplicationViewModel()
        {
            Cars = new ObservableCollection<Car>
            {
                new Car { Model="Mustang", Factory="Ford", Price=4000000 },
                new Car { Model="Elise", Factory="Lotus", Price=5000000 },
                new Car { Model="Huracan", Factory="Lamborghini", Price=10000000 },
            };
        }

        public ICommand AddElementCommand
        {
            get
            {
                return _addCommand ??= new RelayCommand(obj =>
                {
                    Car car = new Car();
                    Cars.Insert(0, car);
                    SelectedCar = car;
                });
            }
        }

        public ICommand RemoveElementCommand
        {
            get
            {
                return _removeCommand ??= new RelayCommand(obj =>
                {
                    Cars.Remove(_selectedCar);
                });
            }
        }

        public Car SelectedCar
        {
            get => _selectedCar;
            set
            {
                _selectedCar = value;
                OnPropertyChanged("SelectedCar");
            }
        }

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
