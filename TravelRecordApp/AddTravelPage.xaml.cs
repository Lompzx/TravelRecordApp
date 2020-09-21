using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Plugin.Geolocator;
using SQLite;
using TravelRecordApp.Logic;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class AddTravelPage : ContentPage
    {
        public AddTravelPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
            var venues = await VenueLogic.GetVenues(position.Latitude, position.Longitude);
            venueListView.ItemsSource = venues;
        }

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {            
            try
            {
                var SelectedValue = venueListView.SelectedItem as Venue;
                var FirstCategory = SelectedValue.categories.FirstOrDefault();
                UserPost userPost = new UserPost()
                {
                    Experience = experienceEntity.Text,
                    VenueName = SelectedValue.name,
                    Address = SelectedValue.location.address,
                    Latitude = SelectedValue.location.lat,
                    Longitude = SelectedValue.location.lng,
                    Distance = SelectedValue.location.distance,
                    CategoryId = FirstCategory.id,
                    CategoryName = FirstCategory.name
                };

                SQLiteConnection Connection = new SQLiteConnection(App.DatabaseLocation);

                //Create IF NOT exists
                Connection.CreateTable<UserPost>();

                if (!String.IsNullOrEmpty(userPost.Experience.Trim().ToString()))
                {
                    int rowsQuantity = Connection.Insert(userPost);
                    Connection.Close();

                    if (rowsQuantity > 0)
                    {
                        DisplayAlert("Sucesso!", "Experiência inserida no DB", "OK");
                        Navigation.PushAsync(new HistoryPage());
                    }
                    else
                    {
                        DisplayAlert("Falha", "Dados não inseridos no DB", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Alerta", "Experiencia obrigatória", "Ok");
                }
            }
            catch (NullReferenceException nre)
            {
                Debug.WriteLine(nre.ToString());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());   
            }
        }
    }
}
