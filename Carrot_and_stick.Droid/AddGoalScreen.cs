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
    /// <summary>
    /// Add a new goal
    /// </summary>
    [Activity(Label = "Add a new goal!", Icon = "@drawable/CarrotIcon")]
    public class AddGoalScreen : Activity
    {
        EditText taskDescriptionInput;
        EditText taskDaysPerPeriodInput;
        EditText daysInPeriodInput;
        EditText periodsPerGoalInput;
        EditText rewardDescriptionInput;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.AddGoalScreen);

            // Find all the controls
            taskDescriptionInput = FindViewById<EditText>(Resource.Id.taskDescriptionInput);
            taskDaysPerPeriodInput = FindViewById<EditText>(Resource.Id.taskDaysPerPeriodInput);
            daysInPeriodInput = FindViewById<EditText>(Resource.Id.daysInPeriodInput);
            periodsPerGoalInput = FindViewById<EditText>(Resource.Id.periodsPerGoalInput);
            rewardDescriptionInput = FindViewById<EditText>(Resource.Id.rewardDescriptionInput);

            Button addGoalButton = FindViewById<Button>(Resource.Id.addGoalButton);
            Button cancelButton = FindViewById<Button>(Resource.Id.cancelButton);


            addGoalButton.Click += delegate
            {
                // TODO: Handle missing/invalid input. 
                String taskDescription = taskDescriptionInput.Text;
                taskDescription = String.IsNullOrWhiteSpace(taskDescription) ? GetString(Resource.String.default_taskname) : taskDescription;

                int taskDaysPerPeriod; 
                Int32.TryParse(taskDaysPerPeriodInput.Text, out taskDaysPerPeriod);
                int daysInPeriod;
                Int32.TryParse(daysInPeriodInput.Text, out daysInPeriod);
                int periodsPerGoal;
                Int32.TryParse(periodsPerGoalInput.Text, out periodsPerGoal);
                String rewardDescription = rewardDescriptionInput.Text;       

                Goal g = new Goal(taskDescription, taskDaysPerPeriod, daysInPeriod, periodsPerGoal);
                GoalManager goalManager = GoalManager.getInstance();
                goalManager.AddGoal(g);
                Finish();
            };

            cancelButton.Click += delegate
            {
                Finish();
            };
        }

    }
}


