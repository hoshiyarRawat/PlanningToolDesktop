using PlanningTool.ViewModel.App_Start;
using PlanningTool.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PlanningTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //Register the IOC container
            IocConfiguration.RegisterIoc();

            MainWindow main = new MainWindow();

            ApplicationViewModel context = new ApplicationViewModel();
            main.DataContext = context;
            main.Show();
        }
    }
}
