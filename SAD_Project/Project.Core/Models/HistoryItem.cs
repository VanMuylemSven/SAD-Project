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

        private string _dateOfSearch;
        public string DateOfSearch
        {
            get { return _dateOfSearch; }
            set {
                _dateOfSearch = DateTime.Parse(value).ToString("F"); //Sets the Datetime to a more readable format.
                //Have to do that here because I made this change way too late and its already like this in the database for older items. :(
            }
        }
        
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
