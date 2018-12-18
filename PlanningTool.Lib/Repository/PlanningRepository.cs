using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanningTool.Models.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data.SqlClient;
using PlanningTool.ViewModel.Common;
using System.Data;

namespace PlanningTool.ViewModel.Repository
{

    public class PlanningRepository : IRepository
    {
        private Database database;

        public PlanningRepository()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            database = factory.Create("PanningToolData");
        }
        public void CreateEmployee(EmployeeModel employee)
        {
            using (DbCommand cmd = database.GetStoredProcCommand(Constants.Create_EMPLOYEE))
            {
                cmd.Parameters.Add(new SqlParameter(Constants.PARM_EMPLOYEE_NAME, employee.EmployeeName) { SqlDbType = SqlDbType.NVarChar, Size = 30 });
                cmd.Parameters.Add(new SqlParameter(Constants.Employee_Id, employee.EmployeeId) { SqlDbType = SqlDbType.Int });
                cmd.Parameters.Add(new SqlParameter(Constants.PARM_EMP_ADDRESS, employee.EmailAdress) { SqlDbType = SqlDbType.NVarChar, Size = 30 });
                cmd.Parameters.Add(new SqlParameter(Constants.PARM_EMP_CODE, employee.EmployeeCode) { SqlDbType = SqlDbType.VarChar, Size = 30 });

                using (IDataReader reader = database.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        break;
                    }
                }
            }

        }

        public void CreateTask(TaskModel taskModel)
        {
            using (DbCommand cmd = database.GetStoredProcCommand(Constants.CreateTask))
            {
                cmd.Parameters.Add(new SqlParameter(Constants.Task_Id, taskModel.TaskID) { SqlDbType = SqlDbType.Int });            
                cmd.Parameters.Add(new SqlParameter(Constants.Title, taskModel.Title));
                cmd.Parameters.Add(new SqlParameter("@Task_Description", taskModel.Description));
                cmd.Parameters.Add(new SqlParameter(Constants.Task_Duration, taskModel.Duration) { SqlDbType = SqlDbType.Int });
                cmd.Parameters.Add(new SqlParameter("@Task_startDate", DateTime.Now) { SqlDbType = SqlDbType.DateTime });
                cmd.Parameters.Add(new SqlParameter(Constants.Task_Percentage, 10) { SqlDbType = SqlDbType.Int });
                cmd.Parameters.Add(new SqlParameter(Constants.Task_Status, 1) { SqlDbType = SqlDbType.Int });
                cmd.Parameters.Add(new SqlParameter(Constants.Task_Assignee, taskModel.SelectdEmployee.EmployeeId) { SqlDbType = SqlDbType.Int });


                using (IDataReader reader = database.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        break;
                    }
                }
            }
        }
        public List<EmployeeModel> GetEmployee(int? employeeId)
        {
            List<EmployeeModel> employeeList = new List<EmployeeModel>();

            using (DbCommand cmd = database.GetStoredProcCommand(Constants.Get_Employees))
            {

                using (IDataReader reader = database.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        EmployeeModel employee = new EmployeeModel();
                        employee.EmployeeId = int.Parse(reader["EmployeeId"].ToString());
                        employee.EmployeeName = reader["EmployeeName"].ToString();
                        employee.EmployeeCode = reader["EmployeeCode"].ToString();
                        employee.EmailAdress = reader["EmailAdress"].ToString();
                        employeeList.Add(employee);
                    }
                }
            }

            return employeeList;
        }

        public List<TaskModel> GetTasks(int? taskId)
        {
            List<TaskModel> taskList = new List<TaskModel>();

            using (DbCommand cmd = database.GetStoredProcCommand(Constants.GetTasks))
            {

                using (IDataReader reader = database.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        TaskModel task = new TaskModel();
                        task.EmployeeId = int.Parse(reader["EmployeeId"].ToString());
                        task.Description = reader["Description"].ToString();
                        task.Title = reader["Title"].ToString();
                        task.Status = reader["Status"].ToString();
                        task.TaskID = int.Parse(reader["TaskID"].ToString());
                        task.Duration = int.Parse(reader["Duration"].ToString());
                        taskList.Add(task);
                    }
                }
            }

            return taskList;
        }

        public void UpdateTask(TaskModel taskModel)
        {
            throw new NotImplementedException();
        }
    }
}
