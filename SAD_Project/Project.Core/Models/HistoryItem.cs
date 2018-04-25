using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Models
{
    class HistoryItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfSearch { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
