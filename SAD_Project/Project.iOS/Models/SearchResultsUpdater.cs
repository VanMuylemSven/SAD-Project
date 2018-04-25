using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace Project.iOS.Models
{
    /*The implementation adds an annotation to the map when an item is selected from the results*/
    public class SearchResultsUpdater : UISearchResultsUpdating
    {
        public event Action<string> UpdateSearchResults = delegate { };

        public override void UpdateSearchResultsForSearchController(UISearchController searchController)
        {
            this.UpdateSearchResults(searchController.SearchBar.Text);
        }
    }
}