using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;

namespace TravelRecordApp.Logic
{
    class VenueLogic
    {
        public async static Task<List<Venue>> GetVenues(double Latitude, double Longitude)
        {
            List<Venue> venues = new List<Venue>();

            var url = VenueRoot.GenerateURL(Latitude, Longitude);            
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (!string.IsNullOrWhiteSpace(response.ToString()))
                {
                    var json = await response.Content.ReadAsStringAsync();
                    //Debug.WriteLine(json.ToString());
                    var venueRoot = JsonConvert.DeserializeObject<VenueRoot>(json);
                    venues = venueRoot.response.venues as List<Venue>;
                }
            }

         return venues;
        }
    }
}
