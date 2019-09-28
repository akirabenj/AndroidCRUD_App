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
using SQLite;
using Android.Database;
using SimpleCRUD.Models;
using Android.Util;

namespace SimpleCRUD.DataHelper
{
    public class DataHelper
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public bool CreateDataBase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "mydb.db")))
                {
                    connection.CreateTable<Item>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLite Error", ex.ToString());
                return false;
            }
        }

        public bool Insert(Item word)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "mydb.db")))
                {
                    connection.Insert(word);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLite Error", ex.ToString());
                return false;
            }
        }

        public List<Item> GetAll()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "mydb.db")))
                {
                    return connection.Query<Item>("select * from Item order by Name").ToList();
                    //return connection.Table<Words>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLite Error", ex.ToString());
                return null;
            }
        }
        public bool SelectTable()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "mydb.db")))
                {
                    List<Item> list = connection.Table<Item>().ToList();
                    if (list.Count > 0)
                    {
                        Log.Info(list.ToString(), list.Count.ToString());
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLite Error", ex.ToString());
                return false;
            }
        }
        public bool Delete(Item field)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "mydb.db")))
                {
                    connection.Delete(field);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLite Error", ex.ToString());
                return false;
            }
        }
        public bool Update(Item field)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "mydb.db")))
                {
                    connection.Query<Item>("UPDATE Item set Name=?, Description=? where Id=?", field.Name, field.Description, field.Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public bool GetById(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "mydb.db")))
                {
                    connection.Query<Item>("SELECT *FROM Item where id=?", id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

    }
}