using PlanningTool.Models.Helpers;
using PlanningTool.ViewModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningTool.ViewModel.App_Start
{
    public class IocConfiguration
    {
        public static void RegisterIoc()
        {
            IocContainer.RegisterType<IRepository, MockPlanningRepository>();

            // for actual Data We need to uncommnet Following Repo
            //IocContainer.RegisterType<IRepository, PlanningRepository>();
        }
    }
}
