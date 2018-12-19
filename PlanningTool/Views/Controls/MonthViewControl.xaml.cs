using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlanningTool.View.Views.Controls
{
    /// <summary>
    /// Interaction logic for MonthViewControl.xaml
    /// </summary>
    public partial class MonthViewControl : UserControl
    {
        DateTime _displayStartDate;
        private int _displayMonth;
        private int _displayYear;
        public MonthViewControl()
        {
            InitializeComponent();
            _displayStartDate = DateTime.Now.AddDays(-1 * (DateTime.Now.Day - 1));
            _displayMonth = _displayStartDate.Month;
            _displayYear = _displayStartDate.Year;
            CultureInfo _cultureInfo = new CultureInfo(CultureInfo.CurrentUICulture.LCID);
            System.Globalization.Calendar sysCal = _cultureInfo.Calendar;
            BuildCalendarUI();
        }

        private void BuildCalendarUI()
        {
            int iDaysInMonth = DateTime.DaysInMonth(_displayStartDate.Year, _displayStartDate.Month);
            int iOffsetDays = System.Convert.ToInt32(System.Enum.ToObject(typeof(System.DayOfWeek), _displayStartDate.DayOfWeek));
            
            WeekOfDaysControls weekRowCtrl = new WeekOfDaysControls();

            MonthViewGrid.Children.Clear();
            //AddRowsToMonthGrid(iDaysInMonth, iOffsetDays);
            DateTimeFormatInfo datetimeFormateInfo = new DateTimeFormatInfo();
            string strMonthName = datetimeFormateInfo.GetMonthName(_displayMonth).ToString();
            MonthYearLabel.Content = strMonthName + " " + _displayYear;
            int j = 0;
            for (int i = 1; i <= iDaysInMonth; i++)
            {                
                DateTime datevalue = (Convert.ToDateTime(("" + i + "-" + strMonthName + "-" + _displayYear + "")));
                if (datevalue.DayOfWeek == DayOfWeek.Saturday || datevalue.DayOfWeek == DayOfWeek.Sunday)
                    continue;
             
                // -- load each weekrow with a DayBoxControl whose label is set to day number
                DayBoxControl dayBox = new DayBoxControl();
                dayBox.DayNumberLabel.Content = (i.ToString() + " " + datevalue.DayOfWeek.ToString().Substring(0,3));
               
              

                Grid.SetColumn(dayBox, j);
                j++;
                weekRowCtrl.WeekRowGrid.Children.Add(dayBox);
            }
          
            MonthViewGrid.Children.Add(weekRowCtrl);
        }

        private void AddRowsToMonthGrid(int DaysInMonth, int OffSetDays)
        {
            MonthViewGrid.RowDefinitions.Clear();
            System.Windows.GridLength rowHeight = new System.Windows.GridLength(60, System.Windows.GridUnitType.Star);

            int EndOffSetDays = 7 - (System.Convert.ToInt32(System.Enum.ToObject(typeof(System.DayOfWeek), _displayStartDate.AddDays(DaysInMonth - 1).DayOfWeek)) + 1);

            for (int i = 1; i <= System.Convert.ToInt32((DaysInMonth + OffSetDays + EndOffSetDays) / (double)7); i++)
            {
                var rowDef = new RowDefinition();
                rowDef.Height = rowHeight;
                MonthViewGrid.RowDefinitions.Add(rowDef);
            }
        }

        private void UpdateMonth(int MonthsToAdd)
        {
            MonthChangedEventArgs ev = new MonthChangedEventArgs();
            ev.OldDisplayStartDate = _displayStartDate;
            _displayStartDate = _displayStartDate.AddMonths(MonthsToAdd);
            ev.NewDisplayStartDate = _displayStartDate;
            _displayMonth = _displayStartDate.Month;
            _displayYear = _displayStartDate.Year;
            BuildCalendarUI();
            //DisplayMonthChanged?.Invoke(ev);
        }


        private void MonthGoPrev_MouseLeftButtonUp(System.Object sender, MouseButtonEventArgs e)
        {
            UpdateMonth(-1);
        }

        private void MonthGoNext_MouseLeftButtonUp(System.Object sender, MouseButtonEventArgs e)
        {
            UpdateMonth(1);
        }

        private void Appointment_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void DayBox_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            // -- call to FindVisualAncestor to make sure they didn't click on existing appointment (in which case,
            //// that appointment window is already opened by handler Appointment_DoubleClick)
            //if (e.Source.GetType == typeof(DayBoxControl) && Utilities.FindVisualAncestor(typeof(DayBoxAppointmentControl), e.OriginalSource) == null)
            //{
            //    NewAppointmentEventArgs ev = new NewAppointmentEventArgs();
            //    if ((DayBoxControl)e.Source.Tag != null)
            //    {
            //        ev.StartDate = new DateTime(_DisplayYear, _DisplayMonth, System.Convert.ToInt32((DayBoxControl)e.Source.Tag), 10, 0, 0);
            //        ev.EndDate = (DateTime)ev.StartDate.AddHours(2);
            //    }
            //    DayBoxDoubleClicked?.Invoke(ev);
            //    e.Handled = true;
            //}
        }

        public DateTime DisplayStartDate
        {
            get
            {
                return _displayStartDate;
            }
            set
            {
                _displayStartDate = value;
                _displayMonth = _displayStartDate.Month;
                _displayYear = _displayStartDate.Year;
            }
        }

    }

    public struct MonthChangedEventArgs
    {
        public DateTime OldDisplayStartDate;
        public DateTime NewDisplayStartDate;
    }
}
