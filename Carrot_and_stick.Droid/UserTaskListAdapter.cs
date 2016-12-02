using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Carrot_and_stick.Droid
{
    public class UserTaskListAdapter : BaseAdapter<UserTask>
    {
        Activity context;
        ObservableCollection<UserTask> list;

        public UserTaskListAdapter(Activity _context, ObservableCollection<UserTask> _list)
        : base()
        {
            this.context = _context;
            this.list = _list;
            this.list.CollectionChanged += (sender, args) => { NotifyDataSetChanged(); };
        }

        public override int Count
        {
            get { return list.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override UserTask this[int index]
        {
            get { return list[index]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.UserTaskRowItem, parent, false);

            UserTask item = this[position];
            view.FindViewById<TextView>(Resource.Id.Title).Text = item.Name;

            view.FindViewById<CheckBox>(Resource.Id.taskCompleteCheckbox).Checked = item.Complete;

            TextView dueDateText = view.FindViewById<TextView>(Resource.Id.DueDate);
            if (item.HasDueDate)
            {
                DateTime dueDate = item.DueDate;
                String text = dueDate.CompareTo(DateTime.Today) == 0 ? "Due today!" : "Due " + dueDate.Date.ToString() + ".";
                dueDateText.Text = text;
            }
            else
            {
                dueDateText.Text = "One time task.";
            }

            return view;
        }


    }
}