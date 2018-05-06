using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using Project.Core.ViewModels;
using System;
using UIKit;

namespace Project.iOS.Views
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class SearchHistoryFilterView : /*UIViewController*/ MvxViewController<SearchHistoryFilterViewModel>
    {
        public SearchHistoryFilterView (IntPtr handle) : base (handle)
        {

        }

        /*public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //Make it so that the keyboard disappears for the txtFilter after entering
            txtFilter.ShouldReturn = delegate
            {
                txtFilter.ResignFirstResponder();
                return true;
            };
            //Tapping outside of the view also closes the keyboard
            var g = new UITapGestureRecognizer(() => View.EndEditing(true));
            View.AddGestureRecognizer(g);


        }*/

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //Make it so that the keyboard disappears for the txtFilter after entering
            txtFilter.ShouldReturn = delegate
            {
                txtFilter.ResignFirstResponder();
                return true;
            };
            //Tapping outside of the view also closes the keyboard
            var g = new UITapGestureRecognizer(() => View.EndEditing(true));
            View.AddGestureRecognizer(g);


           // MvxFluentBindingDescriptionSet<SearchHistoryFilterView, SearchHistoryViewModel> set = new MvxFluentBindingDescriptionSet<SearchHistoryFilterView, SearchHistoryViewModel>(this);

            MvxFluentBindingDescriptionSet<SearchHistoryFilterView, SearchHistoryFilterViewModel> set = 
                new MvxFluentBindingDescriptionSet<SearchHistoryFilterView, SearchHistoryFilterViewModel>(this);
            set.Bind(txtFilter).For(txt => txt.Text).To(vm => vm.Name);
            set.Bind(btnFilter).To(vm => vm.FilterCommand);
            set.Apply();
        }
    }
}