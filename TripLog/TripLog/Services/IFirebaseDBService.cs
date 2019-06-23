using System;
using System.Collections.Generic;
using TripLog.Models;

namespace TripLog.Services
{
    public interface  IFirebaseDBService
    {
        void Connect();
        void GetEntriesAsync();
        void GetEntryAsync(string id);
        void AddEntryAsync(TripLogEntry entry);
        void UpdateEntryAsync(TripLogEntry entry);
        void RemoveEntryAsync(TripLogEntry enty);
    }
}
