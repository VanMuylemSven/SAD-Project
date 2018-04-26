using Foundation;
using MvvmCross.iOS.Views;
using Project.Core.ViewModels;
using System;
using UIKit;

namespace Project.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class SearchHistoryView : MvxTableViewController<SearchHistoryViewModel>
    {
        public SearchHistoryView (IntPtr handle) : base (handle)
        {
        }
    }
}