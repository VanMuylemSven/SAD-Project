using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CoreLocation;
using Foundation;
using MapKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Core.ViewModels;
using Project.Core.Models;
using Project.Core.ViewModels;
using Project.iOS.Views;
using UIKit;

namespace Project.iOS.TableViewSources
{
    public class SearchHistoryViewSource : MvxTableViewSource
    {
        public List<HistoryItem> historyItems;
        //MKMapView map;

        public SearchHistoryViewSource(UITableView tableView/*, MKMapView map*/) : base(tableView)
        {
            historyItems = new List<HistoryItem>();
            //this.map = map;
        }



        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            try
            {
                var cell = (SearchHistoryTableCell)tableView.DequeueReusableCell(SearchHistoryTableCell.Identifier, indexPath);
                return cell;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return null;
            }
        }




        /*public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(mapItemCellId);

            if (cell == null)
                cell = new UITableViewCell();

            cell.TextLabel.Text = MapItems[indexPath.Row].Name;
            return cell;
            return null;
        }*/
        
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            base.RowSelected(tableView, indexPath);

            /*
            //If row is selected, make a historyItem object, //post it//, 
            HistoryItem selected = SearchHistoryViewModel.GetHistoryItems()[indexPath.Row];
            selected.DateOfSearch = DateTime.Now.ToString();
           
            //Annotate it on the map and Center it
            CLLocationCoordinate2D coord = new CLLocationCoordinate2D(double.Parse(selected.Latitude), double.Parse(selected.Longitude));

            map.AddAnnotations(new MKPointAnnotation()
            {
                Title = selected.Name,
                Coordinate = coord
            });

            map.SetCenterCoordinate(coord, true);
            //And navigate back to the mapscreen*/

            //Navigate to new mainmap screen, and give the selected model along it.


        }




    }
}