using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using Project.Core.Models;
using System;
using System.Collections.Generic;
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
            //set.Bind(TextLabel).For(lbl => lbl.Text).To(res => res.Name);
            //set.Bind(DetailTextLabel).For(lbl => lbl.Text).To(res => res.LatLong);

            set.Bind(lblTitle).For(lbl => lbl.Text).To(res => res.Name);
            set.Bind(lblTime).For(lbl => lbl.Text).To(res => res.DateOfSearch);
            set.Bind(lblLat).For(lbl => lbl.Text).To(res => res.Latitude);
            set.Bind(lblLong).For(lbl => lbl.Text).To(res => res.Longitude);
            set.Bind(lblID).For(lbl => lbl.Text).To(res => res.Id);
            set.Apply();

        }

    }
}