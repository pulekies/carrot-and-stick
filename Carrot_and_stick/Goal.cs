using System;

namespace Carrot_and_stick
{
    public class Goal
    {
        private static int defaultNumTaskDaysPerPeriod = 5;
        private static int defaultNumDaysInPeriod = 7;
       // private static int NumPeriodsPerGoal { get; set; } // Number of periods that the tasks must be completed to achieve the goal


        public String Name { get; set; }
        public String TaskDescription { get; set; } // The description of the task
        public String RewardDescription { get; set; } // The description of the task

        public int NumTaskDaysPerPeriod { get; set; } // Number of days per period that the task must be completed
        public int NumDaysInPeriod { get; set; } // Number of total days in a period
        public int NumPeriodsPerGoal { get; set; } // Number of periods that the tasks must be completed to achieve the goal

        public DateTime PeriodStartDate { get; set; } // The date the current period started
        public int NumTaskDaysRemaining { get; set; } // Number of days remaining this period that the task must be completed
        public int NumPeriodsRemaining { get; set; } // Number of periods remaining that must be completed to achieve the goal

        public Goal(String taskDescription, int taskDaysPerPeriod, int daysInPeriod, int periodsPerGoal, string RewardDescription)
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

