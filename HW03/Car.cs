using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HW3
{
    public class Car : INotifyPropertyChanged
    {
        private string model;
        private string factory;
        private int price;

        public string Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged("Model");
            }
        }
        public string Factory
        {
            get { return factory; }
            set
            {
                factory = value;
                OnPropertyChanged("Factory");
            }
        }
        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
