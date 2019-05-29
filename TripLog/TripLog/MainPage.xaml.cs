using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Pages;
using Xamarin.Forms;

namespace TripLog
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            trips.ItemsSource = GetItems();
            
        }

        private void New_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewEntryPage());
        }

        private async void Trips_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var trip = (TripLogEntry)e.Item;
            await Navigation.PushAsync(new DetailPage(trip));

            trips.SelectedItem = null;
        }

        private List<TripLogEntry> GetItems()
        {
            return new List<TripLogEntry>
            {
                new TripLogEntry
                {
                    Title = "Washington Monument",
                    Notes = "Amazing!",
                    Rating = 3,
                    Date = new DateTime(2017,2,5),
                    Latitude = 38.8895,
                    Longitude = -77.0352
                },
                 new TripLogEntry
                {
                    Title = "Statue of Liberty",
                    Notes = "Inspiring!",
                    Rating = 4,
                    Date = new DateTime(2017,4,13),
                    Latitude = 40.6892,
                    Longitude = -74.0444
                },
                  new TripLogEntry
                {
                    Title = "Golden Gate Bridge",
                    Notes = "Foggy but beautiful.",
                    Rating = 5,
                    Date = new DateTime(2017,4,26),
                    Latitude = 37.8268,
                    Longitude = -122.4798
                }
            };
        }
    }
}
