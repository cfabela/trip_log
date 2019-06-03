using System.ComponentModel;
using TripLog.Services;
using TripLog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TripLog.Views
{
    public partial class DetailPage : ContentPage
    {
        DetailViewModel _vm
        {
            get { return BindingContext as DetailViewModel; }
        }

        public DetailPage()
        {
            InitializeComponent();
            BindingContext = new DetailViewModel(DependencyService.Get<INavService>());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(_vm != null)
            {
                _vm.PropertyChanged += OnVieModelPropertyChanged;
            }
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if(_vm != null)
            {
                _vm.PropertyChanged -= OnVieModelPropertyChanged;
            }
        }

        private void OnVieModelPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(DetailViewModel.Entry))
                UpdateMap();
        }

        private void UpdateMap()
        {
            map.MoveToRegion(MapSpan.FromCenterAndRadius(
              new Position(_vm.Entry.Latitude, _vm.Entry.Longitude),
              Distance.FromMiles(.5)));

            map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = _vm.Entry.Title,
                Position = new Position(_vm.Entry.Latitude, _vm.Entry.Longitude)
            });
        }
    }
}
