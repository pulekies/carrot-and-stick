using System;

namespace Carrot_and_stick
{
    public class Goal
    {
        public String Name { get; set; }

        public String TaskDescription { get; set; } // The description of the task

        public int NumTaskDaysPerPeriod { get; set; } // Number of days per period that the task must be completed
        public int NumDaysInPeriod { get; set; } // Number of total days in a period
        public int NumPeriodsPerGoal { get; set; } // Number of periods that the tasks must be completed to achieve the goal

        public int NumTaskDaysRemaining { get; set; } // Number of days remaining this period that the task must be completed
        public int NumPeriodsRemaining { get; set; } // Number of periods remaining that must be completed to achieve the goal

        public Goal(String taskDescription, int taskDaysPerPeriod, int daysInPeriod, int periodsPerGoal)
        {
            TaskDescription = taskDescription;
            NumTaskDaysPerPeriod = taskDaysPerPeriod;
            NumDaysInPeriod = daysInPeriod;
            NumPeriodsPerGoal = periodsPerGoal;
        }
    }
}

