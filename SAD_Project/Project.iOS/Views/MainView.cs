﻿using CoreLocation;
using Foundation;
using MapKit;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.Plugins.Messenger;
using Project.Core.Models;
using Project.Core.ViewModels;
using System;
using System.Diagnostics;
using UIKit;

namespace Project.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class MainView : MvxViewController
    {

        MyMapDelegate mapDelegate;
        UISearchController searchController;
        CLLocationManager locationManager = new CLLocationManager();
        HistoryItem selectedHistoryItem;

        public MainView(IntPtr handle) : base(handle)
        {
            //_messenger = messenger;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //If no historyitem is selected
            var mainVM = this.ViewModel as MainViewModel; //To get the item from the ViewModel, Get it via the VM itself, and cast it as that type of VM.
            if (mainVM != null)
            {
                selectedHistoryItem = mainVM.SelectedHistoryItem;
            }

            //If you haven't selected an item,  show the History/... bottom bars + search bar
            if (selectedHistoryItem == null)
            {
                //Bottom Tab bar 
                UIBarButtonItem recentHistoryBarButton = new UIBarButtonItem(UIBarButtonSystemItem.Rewind);
                recentHistoryBarButton.Title = "Recent History";
                UIBarButtonItem[] toolbarItems = new UIBarButtonItem[] {
                recentHistoryBarButton//,
                //...
                };

                this.SetToolbarItems(toolbarItems, false);
                this.NavigationController.ToolbarHidden = false;

                /////////////
                // BINDING //
                MvxFluentBindingDescriptionSet<MainView, MainViewModel> set = new MvxFluentBindingDescriptionSet<MainView, MainViewModel>(this);
                set.Bind(recentHistoryBarButton).To(vm => vm.SearchHistoryCommand); //show Search History window

                set.Apply();
            }


            ////////////
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
            const double lat = 50.8247952; //Stationsplein kortrijk
            const double lon = 3.2643516000000545;
            var mapCenter = new CLLocationCoordinate2D(lat, lon);
            var mapRegion = MKCoordinateRegion.FromDistance(mapCenter/*MainMap.UserLocation.Coordinate*/, 2000, 2000);
            //MainMap.CenterCoordinate = mapCenter/*MainMap.UserLocation.Coordinate*/;
            MainMap.Region = mapRegion;

            
            if (selectedHistoryItem != null)
            {
                CLLocationCoordinate2D coordinate2D = new CLLocationCoordinate2D(double.Parse(selectedHistoryItem.Latitude), double.Parse(selectedHistoryItem.Longitude));
                //Adding an annotation
                MainMap.AddAnnotations(new MKPointAnnotation()
                {
                    Title = selectedHistoryItem.Name,
                    Coordinate = coordinate2D,
                    Subtitle = selectedHistoryItem.LatLong
                   

                });
                MainMap.SetCenterCoordinate(coordinate2D, true);
                MainMap.Region = MKCoordinateRegion.FromDistance(coordinate2D, 10000, 10000);
            }
            

            // set the map delegate
            mapDelegate = new MyMapDelegate();
            MainMap.Delegate = mapDelegate;


            ////////////
            //Local Search UIBar
            if (selectedHistoryItem == null)
            {
                var searchResultsController = new SearchResultsView(MainMap, mainVM); //Also give the Viewmodel, so we can access it for the Messenger/Posting

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

            //Compass
            var compass = MKCompassButton.FromMapView(MainMap);
            compass.CompassVisibility = MKFeatureVisibility.Visible;
            NavigationItem.RightBarButtonItem = new UIBarButtonItem(compass);
            MainMap.ShowsCompass = false; // so we don't have two compasses!
            // User tracking button
            //Because of using it on a simulator, you can't actually SEE it, but it does work. probably.
            var button = MKUserTrackingButton.FromMapView(MainMap);
            button.Layer.BackgroundColor = UIColor.FromRGBA(255, 255, 255, 80).CGColor;
            button.Layer.BorderColor = UIColor.White.CGColor;
            button.Layer.BorderWidth = 1;
            button.Layer.CornerRadius = 5;
            button.TranslatesAutoresizingMaskIntoConstraints = false;
            View.AddSubview(button);


        }
    }
}
 