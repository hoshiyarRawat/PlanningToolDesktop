using PlanningTool.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningTool.Models.Model
{
    /// <summary>
    /// This call is 
    /// </summary>
    public class EmployeeModel : ObservableObject
    {
        #region "Public Properties"
        
        public int EmployeeId { get; set; }

        private string employeeName;

        public string EmployeeName
        {
            get { return employeeName; }
            set
            {
                employeeName = value;
                OnPropertyChanged(nameof(this.EmployeeName));
            }
        }

        private string emailAdress;

        public string EmailAdress
        {
            get { return emailAdress; }
            set
            {
                emailAdress = value;
                OnPropertyChanged(nameof(this.EmailAdress));
            }
        }

        private string employeeCode;

        public string EmployeeCode
        {
            get { return employeeCode; }
            set
            {
                employeeCode = value;
                OnPropertyChanged(nameof(this.EmployeeCode));
            }
        }

        private ICollection<Task> tasks;

        public ICollection<Task> Tasks
        {
            get { return tasks; }
            set
            {
                tasks = value;
                OnPropertyChanged(nameof(this.Tasks));
            }
        }

        private List<EmployeeModel> employeeList;

        public List<EmployeeModel> EmployeeList
        {
            get { return employeeList; }
            set
            {
                if (value != employeeList)
                {
                    employeeList = value;
                    OnPropertyChanged("EmployeeList");
                }

            }
        }

        private EmployeeModel selectEmployee;

        public EmployeeModel SelectdEmployee
        {
            get { return selectEmployee; }
            set
            {
                if (value != selectEmployee)
                {
                    selectEmployee = value;
                    OnPropertyChanged("SelectdEmployee");
                }

            }
        }
        #endregion
    }
}
