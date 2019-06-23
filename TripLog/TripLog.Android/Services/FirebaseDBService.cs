using TripLog.Models;
using TripLog.Services;

namespace TripLog.Droid.Services
{
    public class FirebaseDBService : IFirebaseDBService
    {
        //private FirebaseDatabase database;
        //private DatabaseReference databaseReference;

        public void Connect()
        {
          //  database = FirebaseDatabase.GetInstance(MainActivity.firebaseApp);
        }

        public void AddEntryAsync(TripLogEntry entry)
        {
            //databaseReference = database.GetReference("tripLogs/" + entry.Id);
            //var entryJson = JsonConvert.SerializeObject(entry);
            //databaseReference.SetValue(entryJson);
        }

        public void GetEntriesAsync()
        {
           // databaseReference = database.GetReference("tripLogs/");
            //databaseReference.AddValueEventListener(new ValueEventListener());
        }

        public void GetEntryAsync(string id)
        {
            //if (databaseReference == null) databaseReference = database.GetReference("tripLogs/");
        }

        public void RemoveEntryAsync(TripLogEntry enty)
        {
            //if (databaseReference == null) databaseReference = database.GetReference("tripLogs/");
        }

        public void UpdateEntryAsync(TripLogEntry entry)
        {
          //  if (databaseReference == null) databaseReference = database.GetReference("tripLogs/");
        }

        //public class ValueEventListener : Java.Lang.Object, IValueEventListener
        //{
        //    public void OnCancelled(DatabaseError error)
        //    {
        //        System.Diagnostics.Debug.WriteLine(error.ToString());
        //    }

        //    public void OnDataChange(DataSnapshot snapshot)
        //    {
        //        var entry = snapshot.Value;
        //    }
        //}
    }
}
