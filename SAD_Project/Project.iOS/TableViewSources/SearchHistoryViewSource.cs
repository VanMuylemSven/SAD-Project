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
        public SearchHistoryViewSource(UITableView tableView) : base(tableView)
        {
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

        //Set row height manually.
        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 110f;
        }


        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return base.RowsInSection(tableview, section);
        }

        //Delete button
        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return true;
        }
        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
        {
            switch (editingStyle)
            {
                case UITableViewCellEditingStyle.Delete:
                    RemoveRowCommand.Execute(indexPath.Row);
                    break;
                case UITableViewCellEditingStyle.Insert:
                    break;
                case UITableViewCellEditingStyle.None:
                    break;
            }
        }

        public IMvxCommand RemoveRowCommand { get; set; }



    }
}