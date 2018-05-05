using System;
using UIKit;
using Foundation;
using MapKit;
using System.Collections.Generic;
using CoreLocation;
using System.Linq;
using MvvmCross.Binding.BindingContext;
using Project.Core.ViewModels;
using Project.Core.Models;

namespace Project.iOS.Views
{
    public class SearchResultsView : UITableViewController
    {
        static readonly string mapItemCellId = "mapItemCellId";
        MKMapView map;

        public List<MKMapItem> MapItems { get; set; }
        MainViewModel _mainViewModel;

        public SearchResultsView(MKMapView map, MainViewModel mainViewModel)
        {
            this.map = map;
            _mainViewModel = mainViewModel;
            MapItems = new List<MKMapItem>();
        }


        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return MapItems.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(mapItemCellId);

            if (cell == null)
                cell = new UITableViewCell();

            cell.TextLabel.Text = MapItems[indexPath.Row].Name;
            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {

            // add item to map
            CLLocationCoordinate2D coord = MapItems[indexPath.Row].Placemark.Location.Coordinate;
            map.AddAnnotations(new MKPointAnnotation()
            {
                Title = MapItems[indexPath.Row].Name,
                Coordinate = coord
            });

            map.SetCenterCoordinate(coord, true);

            //Also POST this item to the RecentHistory API
            HistoryItem item = new HistoryItem()
            {
                Id = "0",
                Name = MapItems[indexPath.Row].Name,
                DateOfSearch = DateTime.Now.ToString("F"),
                Latitude = coord.Latitude.ToString(),
                Longitude = coord.Longitude.ToString()
            };
            /*string test = DateTime.Now.ToLongDateString();
            test = DateTime.Now.ToLongTimeString();
            test = DateTime.Now.ToShortDateString();
            test = DateTime.Now.ToShortTimeString();
            test = DateTime.Now.ToString();
            test = DateTime.Now.ToString("f0");
            test = DateTime.Now.ToString("F");*/

            _mainViewModel.PostHistoryItem(item);

            //Back to main view
            DismissViewController(false, null);
        }

        public void Search(string forSearchString)
        {
            // create search request
            var searchRequest = new MKLocalSearchRequest();
            searchRequest.NaturalLanguageQuery = forSearchString;
            searchRequest.Region = new MKCoordinateRegion(map.UserLocation.Coordinate, new MKCoordinateSpan(0.25, 0.25));

            // perform search
            var localSearch = new MKLocalSearch(searchRequest);

            localSearch.Start(delegate (MKLocalSearchResponse response, NSError error) {
                if (response != null && error == null)
                {
                    this.MapItems = response.MapItems.ToList();
                    this.TableView.ReloadData();
                }
                else
                {
                    Console.WriteLine("local search error: {0}", error);
                }
            });


        }
    }
}

