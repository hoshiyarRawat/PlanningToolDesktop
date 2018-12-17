using PlanningTool.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningTool.ViewModel.Repository
{ 
    public interface IRepository
    {
        List<EmployeeModel> GetEmployee(int? employeeId);

        List<TaskModel> GetTasks(int? taskId);

        void CreateEmployee(EmployeeModel employee);

        void CreateTask(TaskModel taskModel);

        void UpdateTask(TaskModel taskModel);

    }
}
