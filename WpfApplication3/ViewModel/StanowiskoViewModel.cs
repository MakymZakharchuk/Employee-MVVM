using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using WpfApplication3.Model;

namespace WpfApplication3.ViewModel
{
    public class StanowiskoViewModel : ObservableCollection<Stanowisko>,INotifyPropertyChanged
    {
      public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public StanowiskoViewModel()
        {
            newBaseEntities dataEntities = new newBaseEntities();


            var stanowisko = dataEntities.Stanowisko;

            var queryStanowisko = from stan in stanowisko select stan;

            foreach (Stanowisko s in queryStanowisko)
            {
                this.Add(s);
            }
            san= new Stanowisko();
        }

        private Stanowisko san;
        public int Id
        {
            get
            {
                return san.Id;
            }
            set
            {
                san.Id = value;
                OnPropertyChange("Id");
            }
        }

        public string Stanowisko1
        {
            get
            {
                return san.Stanowisko1;
            }
            set
            {
                san.Stanowisko1= value;
                OnPropertyChange("Stanowisko1");
            }
        }
    }
}
