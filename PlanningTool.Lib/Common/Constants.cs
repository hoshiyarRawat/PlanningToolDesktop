using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningTool.ViewModel.Common
{
    public class Constants
    {
        public const string Create_EMPLOYEE = "[dbo].[CreateEmployee]";
        public const string PARM_EMPLOYEE_NAME = "@Employee_Name";
        public const string PARM_EMP_ADDRESS = "@Email_Adress";
        public const string PARM_EMP_CODE = "@Employee_Code";
        public const string Employee_Id = "@Employee_Id";

        public const string CreateTask = "[dbo].[CreateTask]";
        public const string Task_Id = "@Task_Id";
        public const string Task_ParentId = "@Task_ParentId";
        public const string Title = "@Title";
        public const string Task_Duration = "@Task_Duration";
        public const string Task_EndDate = "@Task_EndDate";
        public const string Task_Percentage = "@Task_Percentage";
        public const string Task_DueDate = "@Task_DueDate";
        public const string Task_Status = "@Task_Status";
        public const string Task_Assignee = "@Task_Assignee";

        public const string Get_Employees = "[dbo].[GetEmployees]";

        public const string GetTasks = "[dbo].[GetTasks]"; 

    }
}
