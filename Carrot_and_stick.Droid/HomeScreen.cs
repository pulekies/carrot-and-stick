using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Android.Content.Res;
using System.Collections;

namespace Carrot_and_stick.Droid
{
    [Activity(Label = "The Carrot and Stick", MainLauncher = true, Icon = "@drawable/CarrotIcon")]
    public class HomeScreen : Activity
    {
        int count = 1;
        ObservableCollection<Goal> allGoalsCollection;
        GoalListAdapter goalsAdapter;
        ListView listView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
          
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.HomeScreen);
    
            allGoalsCollection = GoalManager.getInstance().AllGoals;
            while (count < 6)
            {
                Goal newGoal = new Goal("Task number " + count);
                allGoalsCollection.Add(newGoal);
                newGoal.RewardDescription = "a new chalk bag";
                count++;
            }

            // Bind listview to all tasks
            goalsAdapter = new GoalListAdapter(this, allGoalsCollection);
            listView = FindViewById<ListView>(Resource.Id.allTasksListView);
            if(listView != null) { 
                listView.Adapter = goalsAdapter;
                RegisterForContextMenu(listView);            
            }
        }

        protected override void OnResume()
        {
            base.OnResume();

            allGoalsCollection = GoalManager.getInstance().AllGoals;

            GoalListAdapter adapter = new GoalListAdapter(this, allGoalsCollection);
            listView.Adapter = adapter;
        }

        public override void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
        {
            if (v.Id == Resource.Id.allTasksListView)
            {              
                var info = (AdapterView.AdapterContextMenuInfo)menuInfo;
                IEnumerator<Goal> enumerator = allGoalsCollection.GetEnumerator();
                enumerator.Reset();
                for(int i = 0; i <= info.Position; i++)
                {
                    enumerator.MoveNext();
                }

                Goal currentGoal = enumerator.Current;
                menu.SetHeaderTitle(currentGoal.TaskDescription);

                // TODO: Handle menu items being clicked
                string[] menuItems = new string[3] {"Complete", "Edit", "Delete"};
                for (var i = 0; i < menuItems.Length; i++)
                {
                    menu.Add(Menu.None, i, i, menuItems[i]);
                }
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.MainMenu, menu);
            Button addGoalbutton = FindViewById<Button>(Resource.Id.addGoalButton);
            if (addGoalbutton != null)
            {
                addGoalbutton.Click += (sender, e) => {
                    StartActivity(typeof(AddGoalScreen));
                };
            }


            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.add_goal:
                    StartActivity(typeof(AddGoalScreen));
                    return true;
                case Resource.Id.help:
                    // TODO: create help screen
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}


