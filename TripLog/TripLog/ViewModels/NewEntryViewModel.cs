﻿using System;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;
using Xamarin.Forms;

namespace TripLog.ViewModels
{
    public class NewEntryViewModel : BaseViewModel
    {
        private readonly ILocationService _locService;
        private readonly ITripLogDataService _tripLogService;

        public NewEntryViewModel(INavService navService, ILocationService locService,
            ITripLogDataService tripLogService) : base(navService)
        {
            _locService = locService;
            _tripLogService = tripLogService;
            Date = DateTime.Today;
            Rating = 1;
        }

        private string _title;
        public string Title 
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
                SaveCommand.ChangeCanExecute();
            }
        }

        private double _latitude;
        public double Latitude
        {
            get { return _latitude; }
            set
            {
                _latitude = value;
                OnPropertyChanged();
            }
        }

        private double _longitude;
        public double Longitude
        {
            get { return _longitude; }
            set
            {
                _longitude = value;
                OnPropertyChanged();
            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        private int _rating;
        public int Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
                OnPropertyChanged();
            }
        }

        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }

        private Command _saveCommand;
        public Command SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new Command(async () => await ExecuteSaveCommand(), CanSave));
            }
        }

        private async Task ExecuteSaveCommand()
        {

            if (IsBusy) return;

            IsBusy = true;

            try
            {
                var newItem = new TripLogEntry
                {
                    Title = Title,
                    Latitude = Latitude,
                    Longitude = Longitude,
                    Date = Date,
                    Rating = Rating,
                    Notes = Notes
                };

                await _tripLogService.AddEntryAsync(newItem);
                await NavService.GoBack();
            }
            finally
            {
                IsBusy = false;
            }
        }

        public override async Task Init()
        {
            var coords = await _locService.GetGeoCoordinatesAsync();
            Latitude = coords.Latitude;
            Longitude = coords.Longitude;
        }

        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(Title);
        }
    }
}
