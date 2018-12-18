using PlanningTool.Models.Helpers;
using PlanningTool.ViewModel.Common;
using PlanningTool.ViewModel.Helper_Classes;
using PlanningTool.ViewModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlanningTool.ViewModel.ViewModels
{
    public class ApplicationViewModel : ObservableObject
    {
        #region Fields

        private ICommand _changePageCommand;

        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        #endregion

        public ApplicationViewModel()
        {

            InitialSetup();
            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
        }

        void InitialSetup()
        {
            PageViewModels.RemoveRange(0, PageViewModels.Count());
            // Add available pages
            PageViewModels.Add(new TaskReportViewModel());
            PageViewModels.Add(new EmployeeViewModel());
            PageViewModels.Add(new TaskViewModel());
            PageViewModels.Add(new AssignTasksViewModel());

        }

        #region Properties / Commands

        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand(
                        p => ChangeViewModel((IPageViewModel)p),
                        p => p is IPageViewModel);
                }

                return _changePageCommand;
            }
        }

        private ICommand _mockData;
        public ICommand MockData
        {
            get
            {
                if (_mockData == null)
                {
                    _mockData = new RelayCommand(p => EnableMockData());
                }

                return _mockData;
            }
        }    

        private void EnableMockData()
        {
            IocContainer.RemoveType<IRepository>();
            IocContainer.RegisterType<IRepository, MockPlanningRepository>();
        }

        private ICommand _actualData;
        public ICommand ActualData
        {
            get
            {
                if (_actualData == null)
                {
                    _actualData = new RelayCommand(p => EnableActualData());
                }

                return _actualData;
            }
        }

        private void EnableActualData()
        {
            IocContainer.RemoveType<IRepository>();
            IocContainer.RegisterType<IRepository, PlanningRepository>();
        }

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
           
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }

        #endregion

        #region Methods

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            InitialSetup();
            if (PageViewModels.Where(v => v.Name == viewModel.Name).Count() == 0)
                PageViewModels.Add(viewModel);   

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm.Name == viewModel.Name);

            
        }

        #endregion
    }
}
