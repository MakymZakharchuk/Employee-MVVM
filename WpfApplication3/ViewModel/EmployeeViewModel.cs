using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using WpfApplication3.Common;
using WpfApplication3.Model;

namespace WpfApplication3.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        #region INotify Property

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        private IDataService servicePr;

        public static newBaseEntities DataBaseEntities { get; set; }

        public ObservableCollection<Employee> ListEmployees;

        Employee currentEmployee { get; set; }

        public EmployeeViewModel()
        {
            servicePr = new Service();

            DataBaseEntities = new newBaseEntities();

            ListEmployees = new ObservableCollection<Employee>(servicePr.GetAllEmployees());

            //var emplo = DataBaseEntities.Employee;

            //var query = from employee in emplo
            //            orderby employee.Name
            //            select employee;

            //foreach (Employee em in query)
            //{
            //    ListEmployees.Add(em);
            //}
            currentEmployee = new Employee();
        }

       

        void SaveEmployee()
        {
            currentEmployee.Id = this.SelectedEmployee.Id;
            currentEmployee.Name = this.SelectedEmployee.Name;
            currentEmployee.Nazwisko = this.SelectedEmployee.Nazwisko;
            currentEmployee.Numer = this.SelectedEmployee.Numer;
            currentEmployee.GrupaId = this.SelectedEmployee.GrupaId;
            currentEmployee.StanowiskoId = this.SelectedEmployee.StanowiskoId;
            currentEmployee.BirthData = this.SelectedEmployee.BirthData;
            currentEmployee.Pesel = this.SelectedEmployee.Pesel;
            currentEmployee.Plec = this.SelectedEmployee.Plec;

            DataBaseEntities.SaveChanges();
        }


        #region Properties

        public ObservableCollection<Employee> Employee
        {
            get { return ListEmployees; }
            set
            {
                ListEmployees = value;
                OnPropertyChange("Employee");
            }
        }

        private Employee empl;

        public Employee SelectedEmployee
        {
            get { return empl; }
            set
            {
                empl = value;
                OnPropertyChange("SelectedEmployee");
            }
        }

        #endregion
        
        #region Command Object Declarations


        private RelayCommand _addCommand;
        private RelayCommand _saveCommand;

        public ICommand AddCommand
        {
            get { return _addCommand ?? (_addCommand = new RelayCommand(Add)); }
        }

       
        private void Add(object o)
        {
            var e = new Employee()
            {
                Id = 6,
               Name= "qwrqwr",
               GrupaId = 2,

            };
            

            ListEmployees.Add(e);
            //servicePr.AddEmployee(e);

            //ListEmployees = new ObservableCollection<Employee>(servicePr.GetAllEmployees());
        }


        public ICommand SaveCommand
        {
            get {
                if (_saveCommand==null)
                {
                    _saveCommand = new RelayCommand(Save,CanSave);
                }
                return _saveCommand;
            }
        }

        bool CanSave(object arg)
        {
            return true;
        }

        private void Save(object o)
        {
           // servicePr.Save();

            SaveEmployee();
            
        }

        #endregion
    }
}
