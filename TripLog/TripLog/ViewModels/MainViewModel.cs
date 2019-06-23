using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Akavache;
using Xamarin.Forms;

using TripLog.Models;
using TripLog.Services;


namespace TripLog.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ITripLogDataService _tripLogService;
        private readonly IBlobCache _cache;

        public MainViewModel(INavService navService,
            ITripLogDataService tripLogService, IBlobCache cache) : base(navService)
        {
            _tripLogService = tripLogService;
            _cache = cache;
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
        public Command RefreshCommand
        {
            get
            {
                return _refreshCommand
                    ?? (_refreshCommand = new Command(() => LoadEntries()));
            }
        }

        public override async Task Init()
        {
           LoadEntries();
        }

        private void LoadEntries()
        {
            if (IsBusy) return;
            IsBusy = true;
            LogEntries.Clear();
            try
            {
                _cache.GetAndFetchLatest("entries", async () => await _tripLogService.GetEntriesAsync())
                    .Subscribe(x => LogEntries = new ObservableCollection<TripLogEntry>(x),
                    ex => System.Diagnostics.Debug.WriteLine("No Key"));
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void P()
        {

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