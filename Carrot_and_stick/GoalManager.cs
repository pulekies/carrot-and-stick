using System;
using System.Collections.ObjectModel;

namespace Carrot_and_stick
{
    public class GoalManager
    {
        private static GoalManager goalManager;

        ObservableCollection<Goal> allGoalsCollection = new ObservableCollection<Goal>();
        ObservableCollection<UserTask> allTasksCollection = new ObservableCollection<UserTask>();

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
            allTasksCollection.Add(new UserTask(goal.TaskDescription));
        }

        public ObservableCollection<UserTask> AllTasks { get { return allTasksCollection; }  }
        // public ObservableCollection<UserTask> AllGoals { get { return allGoalsCollection; } }
    }
}

