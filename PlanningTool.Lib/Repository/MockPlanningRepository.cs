using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanningTool.Models.Model;

namespace PlanningTool.ViewModel.Repository
{
    public class MockPlanningRepository : IRepository
    {
        public void CreateEmployee(EmployeeModel employee)
        {
            //throw new NotImplementedException();
        }

        public void CreateTask(TaskModel taskModel)
        {
            //throw new NotImplementedException();
        }

        public List<EmployeeModel> GetEmployee(int? employeeId)
        {
            List<EmployeeModel> employee = new List<EmployeeModel>();
            EmployeeModel model;
            model = new EmployeeModel
            {
                EmailAdress = "John@gamil.com",
                EmployeeCode = "123434",
                EmployeeId = 1,
                EmployeeName = "John"
            };
            employee.Add(model);
            model = new EmployeeModel
            {
                EmailAdress = "Ram@gamil.com",
                EmployeeCode = "123434",
                EmployeeId = 2,
                EmployeeName = "Ram"
            };
            employee.Add(model);
            model = new EmployeeModel
            {
                EmailAdress = "Hoshi@gamil.com",
                EmployeeCode = "123434",
                EmployeeId = 3,
                EmployeeName = "Hoshi"
            };
            employee.Add(model);
            model = new EmployeeModel
            {
                EmailAdress = "Todd@gamil.com",
                EmployeeCode = "123434",
                EmployeeId = 4,
                EmployeeName = "Todd"
            };
            employee.Add(model);
            model = new EmployeeModel
            {
                EmailAdress = "Tom@gamil.com",
                EmployeeCode = "123434",
                EmployeeId = 5,
                EmployeeName = "Tom"
            };
            employee.Add(model);
            return employee;
        }

        public List<TaskModel> GetTasks(int? taskId)
        {
            List<TaskModel> listOfModel = new List<TaskModel>();
            TaskModel model;
            model = new TaskModel
            {
                EmployeeId = 1,
                TaskID = 1,
                Description = "Create User List",
                Title = "User List",
                Status = "1",
                Duration = 24
            };
            listOfModel.Add(model);
            model = new TaskModel
            {
                EmployeeId = 2,
                TaskID = 2,
                Description = "Dev- Create Employee Repository",
                Title = "User List",
                Status = "1",                
                Duration = 80

            };
            listOfModel.Add(model);
            model = new TaskModel
            {
                EmployeeId = 3,
                TaskID = 3,
                Description = "Create ACtive DireCtory Users",
                Title = "User List",
                Status = "1",
                Duration = 64
            };
            listOfModel.Add(model);
            model = new TaskModel
            {
                EmployeeId = 4,
                TaskID = 4,
                Description = "Ceate Dev Server",
                Title = "User List",
                Status = "1",
                Duration = 56
            };
            listOfModel.Add(model);
            return listOfModel;
        }

        public void UpdateTask(TaskModel taskModel)
        {
            //throw new NotImplementedException();
        }
    }
}
