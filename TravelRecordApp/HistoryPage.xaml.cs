using System;
using System.Collections.Generic;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SQLiteConnection Connection = new SQLiteConnection(App.DatabaseLocation);
            Connection.CreateTable<UserPost>();
            var UserPosts = Connection.Table<UserPost>().ToList();
            UserPostListView.ItemsSource = UserPosts;
            Connection.Close();
        }
    }
}
