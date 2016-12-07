using System;

namespace Carrot_and_stick
{
    public class Goal
    {
        public String Name { get; set; }

        public String TaskDescription { get; set; } // The description of the task
        public String RewardDescription { get; set; } // The description of the task

        public int NumTaskDaysPerPeriod { get; set; } // Number of days per period that the task must be completed
        public int NumDaysInPeriod { get; set; } // Number of total days in a period
        public int NumPeriodsPerGoal { get; set; } // Number of periods that the tasks must be completed to achieve the goal

        public DateTime PeriodStartDate { get; set; } // The date the current period started
        public int NumTaskDaysRemaining { get; set; } // Number of days remaining this period that the task must be completed
        public int NumPeriodsRemaining { get; set; } // Number of periods remaining that must be completed to achieve the goal

        public Goal(String taskDescription, int taskDaysPerPeriod = 1, int daysInPeriod = 1, int periodsPerGoal = 1)
        {
            TaskDescription = taskDescription;
            NumTaskDaysPerPeriod = taskDaysPerPeriod;
            NumDaysInPeriod = daysInPeriod;
            NumPeriodsPerGoal = periodsPerGoal;

            PeriodStartDate = DateTime.Today;
            NumTaskDaysRemaining = taskDaysPerPeriod;
            NumPeriodsRemaining = NumPeriodsPerGoal;
        }
    }
}

