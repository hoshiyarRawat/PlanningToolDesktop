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
    public class TaskViewModel : ObservableObject, IPageViewModel
    {
        IRepository repo;

        public TaskViewModel()
        {
            repo = IocContainer.ResolveType<IRepository>();
            Initial();         
        }

        void Initial()
        {
            TaskModel task = new TaskModel();
            task.Title = "";
            task.Description = "";
            task.Duration = 0;
            task.EmployeeList = repo.GetEmployee(null);
            task.SelectdEmployee = task.EmployeeList.FirstOrDefault();
            CurrentTask = task;
            TaskModelList = repo.GetTasks(null);
        }

        public string Name
        {
            get
            {
                return "Create Task";
            }
        }

        TaskModel currentTask;       

        public TaskModel CurrentTask
        {
            get { return currentTask; }
            set
            {
                if (value != currentTask)
                {
                    currentTask = value;
                    OnPropertyChanged("CurrentTask");
                }
            }
        }

        ICommand createTasks;

        public ICommand CreateTasksCommand
        {
            get
            {
                if (createTasks == null)
                {
                    createTasks = new RelayCommand(p => CreateTasksData(), p => IsTaskAvailabel());
                }

                return createTasks;
            }
        }

        private bool IsTaskAvailabel()
        {
            var employeeHasTask = TaskModelList.Where(t => t.EmployeeId == CurrentTask.SelectdEmployee.EmployeeId);
            return employeeHasTask.Count() == 0;
        }

        private void CreateTasksData()
        {
            var taskId = (TaskModelList.Count() == 0) ? 1 : TaskModelList.Max(t => t.TaskID);
            CurrentTask.TaskID = ++taskId;                   
            repo.CreateTask(CurrentTask);
            Initial();
        }

        private List<TaskModel> taskModelList;

        public List<TaskModel> TaskModelList
        {
            get { return taskModelList; }
            set
            {
                taskModelList = value;
                OnPropertyChanged("TaskModelList");
            }
        }

       
    }
}
