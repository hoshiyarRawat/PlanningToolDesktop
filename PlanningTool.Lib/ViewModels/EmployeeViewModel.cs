using PlanningTool.Models.Helpers;
using PlanningTool.Models.Model;
using PlanningTool.ViewModel.Common;
using PlanningTool.ViewModel.Helper_Classes;
using PlanningTool.ViewModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlanningTool.ViewModel.ViewModels
{
    public class EmployeeViewModel : ObservableObject, IPageViewModel
    {
        #region Fields
        EmployeeModel currentEmployeel;
        IRepository repo;
        EmployeeModel model;
        #endregion

        public EmployeeViewModel()
        {
            repo = IocContainer.ResolveType<IRepository>();

            InitialLoad();
        }

        void InitialLoad()
        {
            model = new EmployeeModel();
            model.EmployeeName = "";
            model.EmailAdress = "";
            model.EmployeeCode = "";
            model.EmployeeList = repo.GetEmployee(null);
            model.SelectdEmployee = model.EmployeeList.FirstOrDefault();
            CurrentEmployee = model;
        }

        public string Name
        {
            get
            {
                return "Create Employee";
            }
        }

        #region Fields

        private ICommand _saveEmployee;      

        #endregion

        public ICommand SaveEmployee
        {
            get
            {
                if (_saveEmployee == null)
                {
                    _saveEmployee = new RelayCommand(p => SaveEmployeeData(),p => IsSaveEmployeeData());
                }

                return _saveEmployee;
            }
        }

        private bool IsSaveEmployeeData()
        {            
            return (CurrentEmployee.EmployeeName != null) ;
        }

        private void SaveEmployeeData()
        {
            var empId = model.EmployeeList.Max(e => e.EmployeeId);
            CurrentEmployee.EmployeeId = ++ empId;
            repo.CreateEmployee(CurrentEmployee);
            InitialLoad();
        }


        public EmployeeModel CurrentEmployee
        {
            get { return currentEmployeel; }
            set
            {
                if (value != currentEmployeel)
                {
                    currentEmployeel = value;
                    OnPropertyChanged("CurrentEmployee");
                }
            }
        }
    }
}
