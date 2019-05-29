using System;
namespace TripLog.Models
{
    public class TripLogEntry
    {
        public string Title { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public string Notes { get; set; }
    }
}
