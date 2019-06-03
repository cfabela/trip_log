using System;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;

namespace TripLog.ViewModels
{
    public class DetailViewModel : BaseViewModel<TripLogEntry>
    {
        TripLogEntry _entry;
        public TripLogEntry Entry
        {
            get { return _entry; }
            set
            {
                _entry = value;
                OnPropertyChanged();
            }
        }

        public DetailViewModel(INavService nav) : base(nav)
        {
        }

        public override async Task Init(TripLogEntry parameter)
        {
            Entry = parameter;
        }
    }
}
