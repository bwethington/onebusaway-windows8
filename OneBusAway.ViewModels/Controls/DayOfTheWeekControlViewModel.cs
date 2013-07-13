<<<<<<< HEAD:OneBusAway.ViewModels/DayOfTheWeekControlViewModel.cs
﻿using OneBusAway.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBusAway.ViewModels
{
    /// <summary>
    /// View model for the day of the week control.
    /// </summary>
    public class DayOfTheWeekControlViewModel : ViewModelBase
    {
        private DayOfTheWeek[] daysOfTheWeek;
        private ObservableCommand changeDayOfWeekCommand;
        public event EventHandler<DayChangedEventArgs> DayOfWeekChanged;

        /// <summary>
        /// Creates the view model.
        /// </summary>
        public DayOfTheWeekControlViewModel()
        {
            this.ChangeDayOfWeekCommand = new ObservableCommand();
            this.ChangeDayOfWeekCommand.Executed += OnChangeDayOfWeekCommandExecuted;

            this.daysOfTheWeek = (from i in Enumerable.Range(0, 7)
                                  select new DayOfTheWeek()
                                  {
                                      Day = i,
                                      Command = changeDayOfWeekCommand,
                                      IsSelectedDay = ((int)DateTime.Now.DayOfWeek == i),
                                  }).ToArray();
        }

        /// <summary>
        /// Private, static array of days of the week.
        /// </summary>
        public DayOfTheWeek[] DaysOfTheWeek
        {
            get
            {
                return this.daysOfTheWeek;
            }
            set
            {
                SetProperty(ref this.daysOfTheWeek, value);
            }
        }

        public ObservableCommand ChangeDayOfWeekCommand
        {
            get
            {
                return this.changeDayOfWeekCommand;
            }
            set
            {
                SetProperty(ref this.changeDayOfWeekCommand, value);
            }
        }

        /// <summary>
        /// Called when the change day of week command is executed.
        /// </summary>
        private Task OnChangeDayOfWeekCommandExecuted(object arg1, object arg2)
        {
            // Unselect the currently selected day:
            int newSelectedDay = (int)arg2;
            foreach (var dayOfTheWeek in this.daysOfTheWeek)
            {
                dayOfTheWeek.IsSelectedDay = (newSelectedDay == dayOfTheWeek.Day);
            }            

            var dayOfWeekChanged = this.DayOfWeekChanged;
            if (dayOfWeekChanged != null)
            {
                dayOfWeekChanged(this, new DayChangedEventArgs(newSelectedDay));
            }

            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Private class that the day of the week is bound  to.
        /// </summary>
        public class DayOfTheWeek : BindableBase
        {
            private bool isSelectedDay;

            public int Day { get; set; }            
            public ObservableCommand Command { get; set; }

            public bool IsSelectedDay 
            {
                get
                {
                    return this.isSelectedDay;
                }
                set
                {
                    SetProperty(ref this.isSelectedDay, value);
                }
            }
        }
    }
}
=======
﻿using OneBusAway.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBusAway.ViewModels.Controls
{
    /// <summary>
    /// View model for the day of the week control.
    /// </summary>
    public class DayOfTheWeekControlViewModel : ViewModelBase
    {
        private DayOfTheWeek[] daysOfTheWeek;
        private ObservableCommand changeDayOfWeekCommand;
        public event EventHandler<DayChangedEventArgs> DayOfWeekChanged;

        /// <summary>
        /// Creates the view model.
        /// </summary>
        public DayOfTheWeekControlViewModel()
        {
            this.ChangeDayOfWeekCommand = new ObservableCommand();
            this.ChangeDayOfWeekCommand.Executed += OnChangeDayOfWeekCommandExecuted;

            this.daysOfTheWeek = (from i in Enumerable.Range(0, 7)
                                  select new DayOfTheWeek()
                                  {
                                      Day = i,
                                      Command = changeDayOfWeekCommand,
                                      IsSelectedDay = ((int)DateTime.Now.DayOfWeek == i),
                                  }).ToArray();
        }

        /// <summary>
        /// Private, static array of days of the week.
        /// </summary>
        public DayOfTheWeek[] DaysOfTheWeek
        {
            get
            {
                return this.daysOfTheWeek;
            }
            set
            {
                SetProperty(ref this.daysOfTheWeek, value);
            }
        }

        public ObservableCommand ChangeDayOfWeekCommand
        {
            get
            {
                return this.changeDayOfWeekCommand;
            }
            set
            {
                SetProperty(ref this.changeDayOfWeekCommand, value);
            }
        }

        /// <summary>
        /// Called when the change day of week command is executed.
        /// </summary>
        private Task OnChangeDayOfWeekCommandExecuted(object arg1, object arg2)
        {
            // Unselect the currently selected day:
            int newSelectedDay = (int)arg2;
            foreach (var dayOfTheWeek in this.daysOfTheWeek)
            {
                dayOfTheWeek.IsSelectedDay = (newSelectedDay == dayOfTheWeek.Day);
            }            

            var dayOfWeekChanged = this.DayOfWeekChanged;
            if (dayOfWeekChanged != null)
            {
                dayOfWeekChanged(this, new DayChangedEventArgs(newSelectedDay));
            }

            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Private class that the day of the week is bound  to.
        /// </summary>
        public class DayOfTheWeek : BindableBase
        {
            private bool isSelectedDay;

            public int Day { get; set; }            
            public ObservableCommand Command { get; set; }

            public bool IsSelectedDay 
            {
                get
                {
                    return this.isSelectedDay;
                }
                set
                {
                    SetProperty(ref this.isSelectedDay, value);
                }
            }
        }
    }
}
>>>>>>> 5fa5eaa... Re-arranging the view models by moving page controls & user control view models into sudifferent namepsaces / folders.:OneBusAway.ViewModels/Controls/DayOfTheWeekControlViewModel.cs