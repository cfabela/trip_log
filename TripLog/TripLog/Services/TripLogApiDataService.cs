using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TripLog.Models;

namespace TripLog.Services
{
    public class TripLogApiDataService : BaseHttpService, ITripLogDataService
    {
        private readonly Uri _baseUri;
        private readonly IDictionary<string, string> _headers;


        public TripLogApiDataService(Uri baseUri)
        {
            _baseUri = baseUri;
            _headers = new Dictionary<string, string>();

            _headers.Add("zumo-api", "2.0.0");
        }

        public async Task<IList<TripLogEntry>> GetTaskAsync()
        {
            var url = new Uri(_baseUri, "/tables/entry");
            var response = await SendRequestAsync<TripLogEntry[]>(url,
                HttpMethod.Get, _headers);

            return response;
        }

        public async Task<TripLogEntry> GetEntryAsync(string id)
        {
            var url = new Uri(_baseUri, string.Format("/tables/entry/{0}", id));
            var response = await SendRequestAsync<TripLogEntry>(url, HttpMethod.Get, _headers);

            return response;
        }

        public async Task<TripLogEntry> AddEntryAsync(TripLogEntry entry)
        {
            var url = new Uri(_baseUri, "/tables/entry");
            var response = await SendRequestAsync<TripLogEntry>(url, HttpMethod.Post, _headers, entry);

            return response;
        }

        public async Task<TripLogEntry> UpdateEntryAsync(TripLogEntry entry)
        {
            var url = new Uri(_baseUri, string.Format("/tables/entry/{0}", entry.Id));
            var response = await SendRequestAsync<TripLogEntry>(url,
                new HttpMethod("PATCH"), _headers, entry);

            return response;
        }


        public async Task RemoveEntryAsync(TripLogEntry entry)
        {
            var url = new Uri(_baseUri, string.Format("/tables/entry/{0}", entry.Id));
            var response = await SendRequestAsync<TripLogEntry>(url, HttpMethod.Delete, _headers);
        }
    }
}
