using Foundation;
using MvvmCross.iOS.Views;
using System;
using UIKit;

namespace Project.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class SearchHistoryFilterView : MvxViewController
    {
        public SearchHistoryFilterView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }
    }
}