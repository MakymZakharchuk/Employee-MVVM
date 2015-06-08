using System.Collections.ObjectModel;
using System.Linq;
using WpfApplication3.Model;

namespace WpfApplication3.ViewModel
{
    public class GrupaViewModel : ObservableCollection<Grupa>
    {
        public GrupaViewModel()
        {
            newBaseEntities datda = new newBaseEntities();

            var grupabase = datda.Grupa;

            var queryGrupa = from g in grupabase select g;

            foreach (Grupa gr in queryGrupa)
            {
                this.Add(gr);
            }
        }
    }
}