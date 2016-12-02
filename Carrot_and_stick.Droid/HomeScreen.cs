using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Carrot_and_stick.Droid
{
    [Activity(Label = "The Carrot and Stick", MainLauncher = true, Icon = "@drawable/icon")]
    public class HomeScreen : Activity
    {
        int count = 1;
        ObservableCollection<UserTask> allTasksCollection;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
          
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.HomeScreen);

            // Bind listview to all tasks
            ListView listView = FindViewById<ListView>(Resource.Id.allTasksListView);
            GoalManager goalManager = GoalManager.getInstance();
            allTasksCollection = goalManager.AllTasks;

            while (count < 6)
            {
                allTasksCollection.Add(new UserTask("Task number " + count));
                count++;
            }

            UserTaskListAdapter adapter = new UserTaskListAdapter(this, allTasksCollection);
            listView.Adapter = adapter;
            
            allTasksCollection.Add(new UserTask("Task number X"));     

            // Button click should add a new task and remove the first task. 
            Button button = FindViewById<Button>(Resource.Id.myButton);
            /* button.Click += delegate {
                UserTask newTask = new UserTask("Task number " + count);
                newTask.Complete = true;
                allTasksCollection.Add(newTask);

                IEnumerator<UserTask> enumerator = allTasksCollection.GetEnumerator();
                enumerator.Reset();
                enumerator.MoveNext();
                UserTask firstTask = enumerator.Current;

                button.Text = "FirstTaskChecked? : " + firstTask.Complete;
               
            }; */

            if (button != null)
            {
                button.Click += (sender, e) => {
                    StartActivity(typeof(AddGoalScreen));
                };
            }
        }
    }
}


