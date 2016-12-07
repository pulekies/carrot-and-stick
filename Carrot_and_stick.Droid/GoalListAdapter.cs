using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Globalization;

namespace Carrot_and_stick.Droid
{
    public class GoalListAdapter : BaseAdapter<Goal>
    {
        Activity context;
        ObservableCollection<Goal> list;

        public GoalListAdapter(Activity _context, ObservableCollection<Goal> _list)
        : base()
        {
            this.context = _context;
            this.list = _list;

            // TODO: If the list can be modified in a way other than the current add/delete will need to to add the following back in. 
            // this.list.CollectionChanged += (sender, args) => { NotifyDataSetChanged(); };
        }

        public override int Count
        {
            get { return list.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Goal this[int index]
        {
            get { return list[index]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view;
            Goal item;
            if (convertView != null)
            {
                view = convertView;
            }
            else
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.GoalRowItem, parent, false);                
                ImageButton doneButton = view.FindViewById<ImageButton>(Resource.Id.doneButton);                
                doneButton.Click += (object sender, EventArgs e) =>
                {
                    // Toast.MakeText(context, "Deleted item[" + position + "]", ToastLength.Short).Show();
                    item = this[position];
                    GoalManager.getInstance().TaskCompleted(item);                   
                    context.RunOnUiThread(() => this.NotifyDataSetChanged());
                };        
            }

            item = this[position];
            string taskDescription = item.TaskDescription;
            if (string.IsNullOrWhiteSpace(taskDescription))
            {
                taskDescription = context.Resources.GetString(Resource.String.default_taskname);
            }

            view.FindViewById<TextView>(Resource.Id.Title).Text = StringResourceHelper.CapitalizeFirstLetter(taskDescription);

            // TODO Handle invalid dates. 
            DateTime periodEndDate = item.PeriodStartDate.AddDays(item.NumDaysInPeriod);        
            String currentPeriodText = "I'll do this " + item.NumTaskDaysRemaining + " more times before " + periodEndDate.ToShortDateString() + ".";
            TextView currentPeriodTextView = view.FindViewById<TextView>(Resource.Id.CurrentPeriodText);
            currentPeriodTextView.Text = currentPeriodText;

            DateTime rewardDate = item.PeriodStartDate.AddDays(item.NumPeriodsRemaining * item.NumDaysInPeriod);
            String rewardDetailsText = "If I stay on track I'll get " + item.RewardDescription + " on " + periodEndDate.ToShortDateString() + ".";
            TextView rewardDetailsTextView = view.FindViewById<TextView>(Resource.Id.RewardInformationText);
            rewardDetailsTextView.Text = rewardDetailsText;

            return view;
        }


    }
}