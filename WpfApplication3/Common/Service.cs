using System;
using System.Collections.ObjectModel;
using System.Windows;
using WpfApplication3.Model;

namespace WpfApplication3.Common
{
    public class Service : IDataService
    {
        private newBaseEntities bdEntities;
        public Service()
        {
            bdEntities = new newBaseEntities();
        }

        public ObservableCollection<Employee> GetAllEmployees()
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

            foreach (var item in bdEntities.Employee)
            {
                employees.Add(item);
            }
            return employees;
        }

        //public int CreateEmployee(Employee Emp)
        //{
        //    bdEntities.Employee.Add(Emp);
        //    bdEntities.SaveChanges();
        //    return Emp.Id;
        //}


        public void AddEmployee(Employee empl)
        {
            if (empl==null)
            throw  new ArgumentNullException("empl");

        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}
