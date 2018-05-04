using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using Project.Core.Models;
using System;
using UIKit;

namespace Project.iOS.Views
{
    public partial class SearchHistoryTableCell : MvxTableViewCell
    {
        internal static readonly NSString Identifier = new NSString("SearchHistoryCell");

        public SearchHistoryTableCell (IntPtr handle) : base (handle)
        {

        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            MvxFluentBindingDescriptionSet<SearchHistoryTableCell, HistoryItem> set = new MvxFluentBindingDescriptionSet<SearchHistoryTableCell, HistoryItem>(this);
            set.Bind(TextLabel).To(res => res.Name);
            set.Bind(DetailTextLabel).To(res => res.LatLong);
            set.Apply();

        }
    }
}