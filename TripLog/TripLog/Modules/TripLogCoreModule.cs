﻿using Ninject.Modules;

using TripLog.Services;
using TripLog.ViewModels;

namespace TripLog.Modules
{
    public class TripLogCoreModule : NinjectModule
    {
        public override void Load()
        {
            //ViewModels
            Bind<MainViewModel>().ToSelf();
            Bind<DetailViewModel>().ToSelf();
            Bind<NewEntryViewModel>().ToSelf();

            //Core Services
            var tripLogService = new TripLogFirebaseDataService("https://triplog-93404.firebaseio.com/");

            Bind<ITripLogDataService>()
                .ToMethod(x => tripLogService)
                .InSingletonScope();

            Bind<Akavache.IBlobCache>().ToConstant(Akavache.BlobCache.LocalMachine);
        }
    }
}
