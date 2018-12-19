using PlanningTool.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningTool.Models.Model
{
    public class TaskModel : ObservableObject
    {
        #region "Public Properties"

        public int TaskID { get; set; }

        public int? ParentTaskID { get; set; }

        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(this.Title));
            }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged(nameof(this.Description));
            }
        }

        private int duration;

        public int Duration
        {
            get { return duration; }
            set
            {
                duration = value;
                OnPropertyChanged(nameof(this.Duration));
                TaksDurationInDays = (value / 8);
            }
        }

        private int taksDurationInDays;

        public int TaksDurationInDays
        {
            get { return taksDurationInDays; }
            set
            {
                taksDurationInDays = value;
                OnPropertyChanged(nameof(this.TaksDurationInDays));
            }
        }

        private DateTime? startDate;

        public DateTime? StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                OnPropertyChanged(nameof(this.StartDate));
            }
        }

        private DateTime? endDate;

        public DateTime? EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                OnPropertyChanged(nameof(this.EndDate));
            }
        }

        public int? PercentComplete { get; set; }

        public DateTime? DueDate { get; set; }


        public string Status { get; set; }

        public int? EmployeeId { get; set; }


        private string employeeName;
        public string EmployeeNameVal
        {
            get { return employeeName; }
            set
            {
                if (value != employeeName)
                {
                    employeeName = value;
                    OnPropertyChanged("EmployeeNameVal");
                }

            }
        }

        private List<EmployeeModel> employeeList;

        public List<EmployeeModel> EmployeeList
        {
            get { return employeeList; }
            set
            {
                employeeList = value;
                OnPropertyChanged("EmployeeList");
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
