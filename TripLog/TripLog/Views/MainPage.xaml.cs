using System;
using System.ComponentModel;

using TripLog.Models;
using TripLog.Services;
using TripLog.ViewModels;
using Xamarin.Forms;

namespace TripLog.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        private MainViewModel _vm => BindingContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel(DependencyService.Get<INavService>());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();


            //We need to enforce the call to init because MainPage is launch by default
            if (_vm != null)
               await _vm.Init();
        }

        private async void Trips_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var trip = (TripLogEntry)e.Item;
            _vm.ViewCommand.Execute(trip);
            trips.SelectedItem = null;
        }
    }
}
