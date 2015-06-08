using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;
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

        public static newBaseEntities DataBaseEntities { get; set; }

        public ObservableCollection<Employee> ListEmployees;

        private Employee currentEmployee;

        public EmployeeViewModel()
        {
            DataBaseEntities = new newBaseEntities();

            ListEmployees = new ObservableCollection<Employee>();

            var emplo = DataBaseEntities.Employee;

            var query = from employee in emplo
                        orderby employee.Name
                        select employee;

            foreach (Employee em in query)
            {
                ListEmployees.Add(em);
            }
            currentEmployee = new Employee();

            SelectedEmployee = new Employee();
            gr = new Grupa();
            stan = new Stanowisko();
        }


        private Grupa gr;
        private Stanowisko stan;


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

        #region Properties for Save /add
        // private int _id;
        public int Id
        {
            get { return currentEmployee.Id; }
            set
            {
                currentEmployee.Id = value;
                OnPropertyChange("Id");
            }
        }

        public string Name
        {
            get { return currentEmployee.Name; }
            set
            {
                currentEmployee.Name = value;
                OnPropertyChange("Name");
            }
        }

        public string Nazwisko
        {
            get { return currentEmployee.Nazwisko; }
            set
            {
                currentEmployee.Nazwisko = value;
                OnPropertyChange("Nazwisko");
            }
        }

        public Nullable<int> Numer
        {
            get
            { return currentEmployee.Numer; }
            set
            {
                currentEmployee.Numer = value;
                OnPropertyChange("Numer");
            }
        }

        public int GrupaId
        {
            get { return gr.Id; }
            set
            {
                gr.Id = value;
                OnPropertyChange("GrupaId");
            }
        }

        public int StanowiskoId
        {
            get { return stan.Id; }
            set
            {
                stan.Id = value;
                OnPropertyChange("StanowiskoId");
            }
        }

        public Nullable<System.DateTime> BirthData
        {
            get { return currentEmployee.BirthData; }
            set
            {
                currentEmployee.BirthData = value;
                OnPropertyChange("BirthData");
            }
        }

        public Nullable<int> Pesel
        {
            get { return currentEmployee.Pesel; }
            set
            {
                currentEmployee.Pesel = value;
                OnPropertyChange("Pesel");
            }
        }

        public string Plec
        {
            get { return currentEmployee.Plec; }
            set
            {
                currentEmployee.Plec = value;
                OnPropertyChange("Plec");
            }
        }

        #endregion

        #region Command Object Declarations

        private RelayCommand _addCommand;
        private RelayCommand _saveCommand;

        public ICommand AddCommand
        {
            get { return _addCommand = new RelayCommand(param => Add(), param => !CanSave); }
        }

        public ICommand SaveCommand
        {
            get { return _saveCommand = new RelayCommand(param => Save(), param => CanSave); }
        }

        private void Add()
        {
            Employee newEmployee = new Employee();

            newEmployee.Id = Id;
            newEmployee.Name = Name;
            newEmployee.Nazwisko = Nazwisko;
            newEmployee.Numer = Numer;

            newEmployee.GrupaId = GrupaId;
            newEmployee.StanowiskoId = StanowiskoId;

            newEmployee.BirthData = BirthData;
            newEmployee.Pesel = Pesel;
            newEmployee.Plec = Plec; 

            DataBaseEntities.Employee.Add(newEmployee);
            ListEmployees.Add(newEmployee);
            SelectedEmployee = newEmployee;
        }

        bool CanSave
        {
            get { return DataBaseEntities.ChangeTracker.HasChanges(); }
        }

        private void Save()
        {
            DataBaseEntities.Entry(SelectedEmployee).State = SelectedEmployee.Id == 0
                ? EntityState.Added
                : EntityState.Modified;
            DataBaseEntities.SaveChanges();
        }

        #endregion
    }
}
