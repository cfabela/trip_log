using TripLog.Services;
using TripLog.ViewModels;
using Xamarin.Forms;

namespace TripLog.Views
{
    public partial class NewEntryPage : ContentPage
    {
        public NewEntryPage()
        {
            InitializeComponent();
            BindingContext = new NewEntryViewModel(DependencyService.Get<INavService>());
        }
    }
}
