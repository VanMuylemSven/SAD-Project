using CoreLocation;
using Foundation;
using MapKit;
using MvvmCross.iOS.Views;
using Project.iOS.Models;
using System;
using UIKit;

namespace Project.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class MainView : MvxViewController
    {

        MyMapDelegate mapDelegate;
        UISearchController searchController;
        CLLocationManager locationManager = new CLLocationManager();


        public MainView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            // MapKit //
            locationManager.RequestWhenInUseAuthorization(); //Request authorisation to use location when app is in foreground. (Error in versions below 8.0)
            //Type
            MainMap.MapType = MapKit.MKMapType.Standard;
            //Panning and Zooming
            MainMap.ZoomEnabled = true;
            MainMap.ScrollEnabled = true;
            //User Location
            MainMap.ShowsUserLocation = true;

            // set map center and region
            const double lat = 42.374260;
            const double lon = -71.120824;
            var mapCenter = new CLLocationCoordinate2D(lat, lon);
            var mapRegion = MKCoordinateRegion.FromDistance(mapCenter/*MainMap.UserLocation.Coordinate*/, 2000, 2000);
            MainMap.CenterCoordinate = mapCenter/*MainMap.UserLocation.Coordinate*/;
            MainMap.Region = mapRegion;

            //Adding an annotation
            MainMap.AddAnnotations(new MKPointAnnotation()
            {
                Title = "New Annotation",
                Coordinate = MainMap.UserLocation.Coordinate,
                Subtitle = "subtitle"

            });

            // set the map delegate
            mapDelegate = new MyMapDelegate();
            MainMap.Delegate = mapDelegate;

            ////////////
            //Local Search UIBar
            var searchResultsController = new SearchResultsViewController(MainMap);

            var searchUpdater = new SearchResultsUpdater();
            searchUpdater.UpdateSearchResults += searchResultsController.Search;

            //add the search controller
            searchController = new UISearchController(searchResultsController)
            {
                SearchResultsUpdater = searchUpdater
            };

            searchController.SearchBar.SizeToFit();
            searchController.SearchBar.SearchBarStyle = UISearchBarStyle.Minimal;
            searchController.SearchBar.Placeholder = "Enter a search query";

            searchController.HidesNavigationBarDuringPresentation = false;
            NavigationItem.TitleView = searchController.SearchBar;
            DefinesPresentationContext = true;
        }





        /////////////////////////////////
        
    }
}