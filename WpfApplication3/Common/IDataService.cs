using System.Collections.ObjectModel;
using WpfApplication3.Model;

namespace WpfApplication3.Common
{
    public interface IDataService
    {
        ObservableCollection<Employee> GetAllEmployees();
      //  int CreateEmployee(Employee Emp);
        void AddEmployee(Employee empl);
        void Save();


    }
}
