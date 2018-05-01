using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using Project.Core.ViewModels;
using Project.iOS.TableViewSources;
using System;
using UIKit;

namespace Project.iOS.Views
{
    [MvxFromStoryboard(StoryboardName ="Main")]
    public partial class SearchHistoryView : MvxTableViewController<SearchHistoryViewModel>
    {
        public SearchHistoryView (IntPtr handle) : base (handle)
        {
        }

        private SearchHistoryViewSource _searchHistoryViewSource;
        public override void ViewDidLoad()
        {
            _searchHistoryViewSource = new SearchHistoryViewSource(this.TableView);
            base.ViewDidLoad();

            this.TableView.Source = _searchHistoryViewSource;
            this.TableView.ReloadData();

            MvxFluentBindingDescriptionSet<SearchHistoryView, SearchHistoryViewModel> set = new MvxFluentBindingDescriptionSet<SearchHistoryView, SearchHistoryViewModel>(this);
            set.Bind(_searchHistoryViewSource).To(vm => vm.HistoryItems);

            set.Apply();
        }
    }
}