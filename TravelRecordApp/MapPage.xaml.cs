using System;
using System.Collections.Generic;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TravelRecordApp
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var location = CrossGeolocator.Current;
            location.PositionChanged += Location_PositionChanged;
            await location.StartListeningAsync(TimeSpan.FromSeconds(0), 100);
            var position = await location.GetPositionAsync();

            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var span = new MapSpan(center, 2, 2);

            locationsMap.MoveToRegion(span);
        }

        private void Location_PositionChanged(object sender, PositionEventArgs e)
        {
            var center = new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude);
            var span = new MapSpan(center, 2, 2);

            locationsMap.MoveToRegion(span);
        }
    }
}
