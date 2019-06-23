using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TripLog.Models;
using TripLog.Services;

namespace TripLog.iOS.Services
{
    public class FirebaseDBService : IFirebaseDBService
    {
        //private DatabaseReference databaseReference;

        public void Connect()
        {
         //   databaseReference = Database.DefaultInstance.GetRootReference();
        }

        public void AddEntryAsync(TripLogEntry entry)
        {
          // var entries = databaseReference.GetChild("tripLogs/");
            var entryJson = JsonConvert.SerializeObject(entry);
            var x = 2;
        }

        public void GetEntriesAsync()
        {
           // var entries = databaseReference.GetChild("tripLogs");
            //nuint handleReference = entries.ObserveEvent(DataEventType.Value, (snapshot) =>
            //{
            //    var tripLogs = new List<TripLogEntry>();
            //    if(snapshot.GetValues().Any())
            //    {
            //        var x = 2;
            //    }
            //});
        }

        public void GetEntryAsync(string id)
        {
            throw new NotImplementedException();
        }

        public void RemoveEntryAsync(TripLogEntry enty)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntryAsync(TripLogEntry entry)
        {
            throw new NotImplementedException();
        }
    }
}
