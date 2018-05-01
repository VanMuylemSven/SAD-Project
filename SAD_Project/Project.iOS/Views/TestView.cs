using Foundation;
using MvvmCross.iOS.Views;
using System;
using UIKit;

namespace Project.iOS
{
    [MvxFromStoryboard(StoryboardName ="Main")]
    public partial class TestView : MvxViewController
    {
        public TestView (IntPtr handle) : base (handle)
        {
        }
    }
}