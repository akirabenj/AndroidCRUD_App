using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SimpleCRUD.DataHelper;
using SimpleCRUD.Models;
using SimpleCRUD.Resources;

namespace SimpleCRUD
{
    [Activity(Label = "EditActivity")]
    public class EditActivity : Activity
    {
        ListView listData;
        List<Item> listSource = new List<Item>();
        private ArrayAdapter _adapter = null;

        DataHelper.DataHelper db;

        void _searchview_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
           _adapter.Filter.InvokeFilter(e.NewText);
        }

        private void LoadData()
        {
            listSource = db.GetAll();
            var adapter = new ListViewAdapter(this, listSource);
            listData.Adapter = adapter;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Edit);
            

            db = new DataHelper.DataHelper();
            db.CreateDataBase();

            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            Log.Info("DB_Path", folder);

            listData = FindViewById<ListView>(Resource.Id.listView);


            var edtName = FindViewById<EditText>(Resource.Id.editText1);
            var edtDescription = FindViewById<EditText>(Resource.Id.editText2);

            //init btns
            var btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            var btnEdit = FindViewById<Button>(Resource.Id.btnEdit);
            var btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
            var btnMainView = FindViewById<Button>(Resource.Id.mainviewbtn);

            //loaddata
            LoadData();
            //event

            btnMainView.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };
            btnAdd.Click += delegate
            {
                Item field = new Item()
                {
                    Name = edtName.Text,
                    Description = edtDescription.Text,

                };
                if (edtName.Text != "")
                {
                    db.Insert(field);
                    LoadData();
                    edtName.Text = "";
                    edtDescription.Text = "";
                    Toast.MakeText(this, "Added", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, "Please add value", ToastLength.Long).Show();
                }
            };
            btnEdit.Click += delegate
            {
                Item word = new Item()
                {
                    Id = int.Parse(edtName.Tag.ToString()),
                    Name = edtName.Text,
                    Description = edtDescription.Text,

                };
                db.Update(word);
                LoadData();
                edtName.Text = "";
                edtDescription.Text = "";

                Toast.MakeText(this, "Changed", ToastLength.Long).Show();
            };
            btnDelete.Click += delegate
            {
                Item word = new Item()
                {
                    Id = int.Parse(edtName.Tag.ToString()),
                    Name = edtName.Text,
                    Description = edtDescription.Text,

                };
                db.Delete(word);
                LoadData();
                edtName.Text = "";
                edtDescription.Text = "";

                Toast.MakeText(this, "Deleted", ToastLength.Long).Show();
            };
            listData.ItemClick += (s, e) =>
            {
                //binding data
                var txtName = e.View.FindViewById<TextView>(Resource.Id.textView1);
                var txtDescription = e.View.FindViewById<TextView>(Resource.Id.textView2);


                edtName.Text = txtName.Text;
                edtName.Tag = e.Id;
                edtDescription.Text = txtDescription.Text;

            };
        }

    }
}