// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Project.iOS.Views
{
    [Register ("SearchHistoryFilterView")]
    partial class SearchHistoryFilterView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnFilter { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtFilter { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnFilter != null) {
                btnFilter.Dispose ();
                btnFilter = null;
            }

            if (txtFilter != null) {
                txtFilter.Dispose ();
                txtFilter = null;
            }
        }
    }
}