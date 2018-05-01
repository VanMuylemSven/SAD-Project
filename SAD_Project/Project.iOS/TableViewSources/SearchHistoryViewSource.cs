using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Foundation;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Core.ViewModels;
using Project.iOS.Views;
using UIKit;

namespace Project.iOS.TableViewSources
{
    public class SearchHistoryViewSource : MvxTableViewSource
    {
        public SearchHistoryViewSource(UITableView tableView): base(tableView)
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

        
        
    }
}