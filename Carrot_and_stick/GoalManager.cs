using System;
using System.Collections.ObjectModel;

namespace Carrot_and_stick
{
    public class GoalManager
    {
        private static GoalManager goalManager;

        ObservableCollection<Goal> allGoalsCollection = new ObservableCollection<Goal>();
        ObservableCollection<Goal> taskCompletedGoalsCollection = new ObservableCollection<Goal>();

        public static GoalManager getInstance()
        {
            if(goalManager == null)
            {
                goalManager = new GoalManager();
            }

            return goalManager;
        }

        private GoalManager()
        {
        }

        public void AddGoal(Goal goal)
        {
            allGoalsCollection.Add(goal);
        }

        public void TaskCompleted(Goal goal)
        {       
            allGoalsCollection.Remove(goal);
            taskCompletedGoalsCollection.Add(goal);
        }

        public ObservableCollection<Goal> AllGoals { get { return allGoalsCollection; }  }
    }
}

