using System.Collections.ObjectModel;
using System.Linq;
using WpfApplication3.Model;

namespace WpfApplication3.ViewModel
{
    public class StanowiskoViewModel : ObservableCollection<Stanowisko>
    {
        public StanowiskoViewModel()
        {
            newBaseEntities dataEntities = new newBaseEntities();


            var stanowisko = dataEntities.Stanowisko;

            var queryStanowisko = from stan in stanowisko select stan;

            foreach (Stanowisko s in queryStanowisko)
            {
                this.Add(s);
            }
        }
    }
}
