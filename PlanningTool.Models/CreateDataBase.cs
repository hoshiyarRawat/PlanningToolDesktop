using PlanningTool.DataBase.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningTool.Models
{
    public class CreateDataBase
    {

        public static void CreateDataBaseWithdata(string connectionstring)
        {
            String str;
            SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

            

            SqlCommand myCommand = new SqlCommand(connectionstring, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
               
            }
            catch (System.Exception ex)
            {
               
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }

        }

        public static void CreateTablesAndStoreProcedures()
        {
                      
            var fileContent = File.ReadAllText("CreateDataTablesAndSp.sql");
            var sqlqueries = fileContent.Split(new[] { " GO " }, StringSplitOptions.RemoveEmptyEntries);

            var con = new SqlConnection("connstring");
            var cmd = new SqlCommand("query", con);
            con.Open();
            foreach (var query in sqlqueries)
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            con.Close();

            //server.ConnectionContext.ExecuteNonQuery(script);
        }

        public static void CreateStatusData()
        {

            var path = AppDomain.CurrentDomain.BaseDirectory;
           var  fullPath = Path.GetFullPath("DataBaseScript");
            var fullPathq = Path.GetFullPath("CreateDataTablesAndSp.sql");

            using (var ctx = new PlanningToolData())
            {
                var stud = new Status() {  Id = 1 , Status1 = "Not Started" };
                ctx.Status.Add(stud);
                stud = new Status() { Id = 2, Status1 = "In Progress" };
                ctx.Status.Add(stud);
                stud = new Status() { Id = 3, Status1 = "Done" };
                ctx.Status.Add(stud);

                ctx.SaveChanges();
            }

        }


    }
}
