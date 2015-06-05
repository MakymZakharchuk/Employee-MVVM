using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using WpfApplication3.Model;

namespace WpfApplication3.ViewModel
{
    public class GrupaViewModel : ObservableCollection<Grupa>, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        public GrupaViewModel()
        {
            newBaseEntities datda = new newBaseEntities();

            var grupabase = datda.Grupa;

            var queryGrupa = from g in grupabase select g;

            foreach (Grupa gr in queryGrupa)
            {
                this.Add(gr);
            }
            

            grupa= new Grupa();
        }



        private Grupa grupa;

        public string Grupa1
        {
            get
            { return grupa.Grupa1; }
            set
            {
                grupa.Grupa1 = value;
                OnPropertyChange("Grupa1");
            }
        }

        public int Id
        {
            get{return grupa.Id ;}
            set
            {
                grupa.Id = value;
                OnPropertyChange("Id");
            }
        }


    }
}