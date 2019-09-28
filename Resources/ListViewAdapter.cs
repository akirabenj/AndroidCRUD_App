using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SimpleCRUD.Models;
using Java.Lang;

namespace SimpleCRUD.Resources
{
    class ListViewAdapter : BaseAdapter
    {
        private Activity Activity;
        private List<Item> listWord;

        public ListViewAdapter(Activity Activity, List<Item> listWord)
        {
            this.Activity = Activity;
            this.listWord = listWord;
        }

        public override int Count
        {
            get
            {
                return listWord.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return listWord[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? Activity.LayoutInflater.Inflate(Resource.Layout.listview_data_template, parent, false);
            var txtName = view.FindViewById<TextView>(Resource.Id.textView1);
            var txtDescription = view.FindViewById<TextView>(Resource.Id.textView2);
            

            txtName.Text = listWord[position].Name;
            txtDescription.Text = listWord[position].Description;
            
            return view;
        }
    }
}