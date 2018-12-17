using PlanningTool.Models;
using PlanningTool.Models.Helpers;
using PlanningTool.ViewModel.Common;
using PlanningTool.ViewModel.Helper_Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlanningTool.ViewModel.ViewModels
{
    public class AssignTasksViewModel : ObservableObject, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Configuration";
            }
        }
        ICommand crateDataBase;
        public ICommand CreateDataBaseCommand
        {
            get
            {
                if (crateDataBase == null)
                {
                    crateDataBase = new RelayCommand(p => SaveEmployeeData());
                }

                return crateDataBase;
            }
        }

        

        private void SaveEmployeeData()
        {
            //var config = ConfigurationManager.ConnectionStrings[1];
            //CreateDataBase.CreateDataBaseWithdata(config.ConnectionString);
        }

    }
}
