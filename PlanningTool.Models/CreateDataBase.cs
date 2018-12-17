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
            string sqlConnectionString = "Data Source=(local);Initial Catalog=AdventureWorks;Integrated Security=True";

            FileInfo file = new FileInfo("C:\\myscript.sql");

            string script = file.OpenText().ReadToEnd();

            SqlConnection conn = new SqlConnection(sqlConnectionString);          

            //server.ConnectionContext.ExecuteNonQuery(script);
        }


    }
}
