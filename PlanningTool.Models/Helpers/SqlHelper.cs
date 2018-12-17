using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntLib = Microsoft.Practices.EnterpriseLibrary.Data;

namespace PlanningTool.Models.Helpers
{
    public class SqlHelper
    {
        #region Public Static Methods

        public static DataSet ExecuteDataSet(EntLib.Database db, DbCommand cmd)
        {
            var f = new Func<DataSet>(() =>
            {
                return db.ExecuteDataSet(cmd);
            });

            return RetryIt(f, cmd);
        }

        public static int ExecuteNonQuery(EntLib.Database db, DbCommand cmd)
        {
            var f = new Func<int>(() =>
            {
                return db.ExecuteNonQuery(cmd);
            });

            return RetryIt(f, cmd);
        }

        public static IDataReader ExecuteReader(EntLib.Database db, DbCommand cmd)
        {
            var f = new Func<IDataReader>(() =>
            {
                return db.ExecuteReader(cmd);
            });

            return RetryIt(f, cmd);
        }

        public static object ExecuteScalar(EntLib.Database db, DbCommand cmd)
        {
            var f = new Func<object>(() =>
            {
                return db.ExecuteScalar(cmd);
            });

            return RetryIt(f, cmd);
        }

        private static T RetryIt<T>(Func<T> func, DbCommand cmd)
        {
          
            bool isCompleted = false;

            T result = default(T);

            while (!isCompleted)
            {
                var timer = Stopwatch.StartNew();

                try
                {
                    result = func();

                    timer.Stop();                   

                    isCompleted = true;
                }
                catch (Exception ex)
                {
                    
                }
            }

            return result;
        }

        #endregion
    }
}
