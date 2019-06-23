using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Firebase.Database;

using Newtonsoft.Json;
using TripLog.Models;

namespace TripLog.Services
{
    public class TripLogFirebaseDataService : ITripLogDataService
    {
        FirebaseClient firebase;


        public TripLogFirebaseDataService(string firebaseUrl)
        {
            firebase = new FirebaseClient(firebaseUrl);
        }

        public async Task<TripLogEntry> AddEntryAsync(TripLogEntry entry)
        {
            var entryJson = JsonConvert.SerializeObject(entry);
            var result = await firebase
                .Child("TripLogs")
                .PostAsync(entryJson);
            return entry;  
        }

        public async Task<IList<TripLogEntry>> GetEntriesAsync()
        {
            return (await firebase
                .Child("TripLogs")
                .OnceAsync<TripLogEntry>()).Select(item => new TripLogEntry
                {
                    Id = item.Object.Id,
                    Title = item.Object.Title,
                    Latitude = item.Object.Latitude,
                    Longitude = item.Object.Longitude,
                    Date = item.Object.Date,
                    Rating = item.Object.Rating,
                    Notes = item.Object.Notes
                }).ToList();
        }

        public async Task<TripLogEntry> GetEntryAsync(string id)
        {
            var allTripLogs = await GetEntriesAsync();
            await firebase
                .Child("TripLogs")
                .OnceAsync<TripLogEntry>();
            return allTripLogs.FirstOrDefault(item => item.Id == id);
        }

        public Task RemoveEntryAsync(TripLogEntry entry)
        {
            throw new NotImplementedException();
        }

        public async Task<TripLogEntry> UpdateEntryAsync(TripLogEntry entry)
        {
            var entryJson = JsonConvert.SerializeObject(entry);
            var toUpdateTripLog = (await firebase
                .Child("TripLogs")
                .OnceAsync<TripLogEntry>()).Where(item => item.Object.Id == entry.Id).FirstOrDefault();

            await firebase
                .Child("TripLogs/" + entry.Id)
                .PutAsync(entryJson);

            return entry;
                
        }
    }
}
