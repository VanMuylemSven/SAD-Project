using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Models
{
    public class HistoryItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DateOfSearch { get; set; }

        private string _latitude;
        public string Latitude
        {
            get { return _latitude; }
            set {
                _latitude = value;
                LatLong = "Latitude: " + Latitude + " - Longitude: " + Longitude;
            }
        }
        private string _longitude;
        public string Longitude
        {
            get { return _longitude; }
            set {
                _longitude = value;
                LatLong = "Latitude: " + Latitude + " - Longitude: " + Longitude;
            }
        }
        
        public string LatLong {get; set; }

    }
}
