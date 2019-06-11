﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;
using Xamarin.Forms;

namespace TripLog.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(INavService navService) : base(navService)
        {
            LogEntries = new ObservableCollection<TripLogEntry>();
        }

        private ObservableCollection<TripLogEntry> _logEntries;
        public ObservableCollection<TripLogEntry> LogEntries
        {
            get { return _logEntries; }
            set
            {
                _logEntries = value;
                OnPropertyChanged();
            }
        }

        private Command<TripLogEntry> _viewCommand;
        public Command<TripLogEntry> ViewCommand
        {
            get
            {
                return _viewCommand ?? (_viewCommand = new Command<TripLogEntry>
                    (async (entry) => await ExecuteViewCommand(entry)));
            }
        }

        private Command _newCommand;
        public Command NewCommand
        {
            get
            {
                return _newCommand
                    ?? (_newCommand = new Command(async () => await ExecuteNewCommand()));
            }
        }

        private Command _refreshCommand;
        public Command Refreshcommand
        {
            get
            {
                return _refreshCommand
                    ?? (_refreshCommand = new Command(async () => await LoadEntries()));
            }
        }

        public override async Task Init()
        {
           await LoadEntries();
        }

        private async Task LoadEntries()
        {
            if (IsBusy) return;
            IsBusy = true;

            LogEntries.Clear();
            await Task.Delay(3000);

          //  await Task.Factory.StartNew(() =>
           //{
               LogEntries.Add(new TripLogEntry
               {
                   Title = "Washington Monument",
                   Notes = "Amazing!",
                   Rating = 3,
                   Date = new DateTime(2017, 2, 5),
                   Latitude = 38.8895,
                   Longitude = -77.0352
               });
               LogEntries.Add(new TripLogEntry
               {
                   Title = "Statue of Liberty",
                   Notes = "Inspiring!",
                   Rating = 4,
                   Date = new DateTime(2017, 4, 13),
                   Latitude = 40.6892,
                   Longitude = -74.0444
               });
               LogEntries.Add(new TripLogEntry
               {
                   Title = "Golden Gate Bridge",
                   Notes = "Foggy but beautiful.",
                   Rating = 5,
                   Date = new DateTime(2017, 4, 26),
                   Latitude = 37.8268,
                   Longitude = -122.4798
               });
            // });
            IsBusy = false;
        }
    

        private async Task ExecuteViewCommand(TripLogEntry entry)
        {
            await NavService.NavigateTo<DetailViewModel, TripLogEntry>(entry);
        }

        private async Task ExecuteNewCommand()
        {
            await NavService.NavigateTo<NewEntryViewModel>();
        }
    }
}