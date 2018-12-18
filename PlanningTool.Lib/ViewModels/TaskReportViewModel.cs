using PlanningTool.Models.Helpers;
using PlanningTool.Models.Model;
using PlanningTool.ViewModel.Common;
using PlanningTool.ViewModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningTool.ViewModel.ViewModels
{
    public class TaskReportViewModel : ObservableObject, IPageViewModel
    {
        IRepository repo;

        public TaskReportViewModel()
        {
            repo = IocContainer.ResolveType<IRepository>();
            InitialLoad();
        }

        void InitialLoad()
        {
            var getEmployeeList = repo.GetEmployee(null);
            Tasks = repo.GetTasks(null);

            foreach (var task in Tasks)
            {
                task.EmployeeNameVal = getEmployeeList.FirstOrDefault(e => e.EmployeeId == task.EmployeeId).EmployeeName;
            }                   
        }

        public string Name
        {
            get
            {
                return "Task Report";
            }
        }

        private List<TaskModel> taskList;

        public List<TaskModel> Tasks
        {
            get { return taskList; }
            set
            {
                taskList = value;
                OnPropertyChanged("Tasks");
            }
        }
    }
}
