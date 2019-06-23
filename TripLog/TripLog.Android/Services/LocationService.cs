using System.Threading.Tasks;

using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android;

using TripLog.Droid.Tools;
using TripLog.Models;
using TripLog.Services;

namespace TripLog.Droid.Services
{
    public class LocationService : Java.Lang.Object, ILocationService, ILocationListener
    {
        private TaskCompletionSource<Location> _tcs;
        public const int LocationRequestCode = 101;

        private string[] permissions = { Manifest.Permission.AccessFineLocation };

        public async Task<GeoCoords> GetGeoCoordinatesAsync()
        {
            var context = Android.App.Application.Context;  
            var hasGpsPermission = context.CheckPermission(permissions, LocationRequestCode);
            if (hasGpsPermission)
            {
                var manager = (LocationManager)context.GetSystemService(Context.LocationService);
                _tcs = new TaskCompletionSource<Location>();
                manager.RequestSingleUpdate("gps", this, null);

                var location = await _tcs.Task;

                return new GeoCoords
                {
                    Latitude = location.Latitude,
                    Longitude = location.Longitude
                };
            }

            return new GeoCoords
            {
                Latitude = 0,
                Longitude = 0
            };
        }

        public void OnLocationChanged(Location location)
        {
            _tcs.TrySetResult(location);
        }

        public void OnProviderDisabled(string provider)
        {
        }

        public void OnProviderEnabled(string provider)
        {

        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {

        }
    }
}
