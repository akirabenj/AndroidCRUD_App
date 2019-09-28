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
using SimpleCRUD.Resources;

namespace SimpleCRUD
{
    [Activity(Label = "ViewActivity")]
    public class ViewActivity : Activity
    {
        
        ListView listData;
        List<Item> listSource = new List<Item>();
        
        DataHelper.DataHelper db;

        private void LoadData()
        {
            listSource = db.GetAll();
            ListViewAdapter _adapter = new ListViewAdapter(this, listSource);
            listData.Adapter = _adapter;
        }
        void _searchview_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.View);

            var btnMainView = FindViewById<Button>(Resource.Id.mainviewbtn);
            db = new DataHelper.DataHelper();
            listData = FindViewById<ListView>(Resource.Id.MainlistView);
            LoadData();

            btnMainView.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };
        }
    }
}