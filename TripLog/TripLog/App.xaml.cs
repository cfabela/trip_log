
using Ninject;
using Ninject.Modules;
using TripLog.Modules;

using TripLog.ViewModels;
using TripLog.Views;

using Xamarin.Forms;

namespace TripLog
{
    public partial class App : Application
    {

        public IKernel Kernel { get; set; }

        public App(params INinjectModule[] platformModules)
        {
            var mainPage = new NavigationPage(new MainPage());

            //Register core services
            Kernel = new StandardKernel(
                new TripLogCoreModule(),
                new TripLogNavModule(mainPage.Navigation));
                
            //Register platform specific services
            Kernel.Load(platformModules);



            mainPage.BindingContext = Kernel.Get<MainViewModel>();

            MainPage = mainPage;
        }
    }
}