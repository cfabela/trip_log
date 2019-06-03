using System;
using Ninject.Modules;
using TripLog.Services;
using TripLog.ViewModels;
using TripLog.Views;
using Xamarin.Forms;

namespace TripLog.Modules
{
    public class TripLogNavModule : NinjectModule
    {
        private readonly INavigation _xfNaV;

        public TripLogNavModule(INavigation xamarinFormsNavigation)
        {
            _xfNaV = xamarinFormsNavigation;
        }

        public override void Load()
        {
            var navService = new XamarinFormsNavService();
            navService.XamarinFormsNav = _xfNaV;

            //Register view mappings
            navService.RegisterViewMapping(typeof(MainViewModel), typeof(MainPage));
            navService.RegisterViewMapping(typeof(DetailViewModel), typeof(DetailPage));
            navService.RegisterViewMapping(typeof(NewEntryViewModel), typeof(NewEntryPage));

            Bind<INavService>()
                .ToMethod(x => navService)
                .InSingletonScope();

        }
    }
}
