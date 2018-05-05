using Foundation;
using MapKit;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using Project.Core.Models;
using Project.Core.ViewModels;
using Project.iOS.TableViewSources;
using System;
using System.Collections.Generic;
using UIKit;

namespace Project.iOS.Views
{
    [MvxFromStoryboard(StoryboardName ="Main")]
    public partial class SearchHistoryView : MvxTableViewController<SearchHistoryViewModel>
    {
        //Get map from MainView?
        public List<HistoryItem> HistoryItems { get; set; }

        public SearchHistoryView (IntPtr handle) : base (handle)
        {
            
        }

        private SearchHistoryViewSource _searchHistoryViewSource;
        public override void ViewDidLoad()
        {
            _searchHistoryViewSource = new SearchHistoryViewSource(this.TableView);

            base.ViewDidLoad();
            //Set viewsource properties
            this.TableView.Source = _searchHistoryViewSource;
            this.TableView.RowHeight = UITableView.AutomaticDimension;

            MvxFluentBindingDescriptionSet<SearchHistoryView, SearchHistoryViewModel> set = new MvxFluentBindingDescriptionSet<SearchHistoryView, SearchHistoryViewModel>(this);
            set.Bind(_searchHistoryViewSource).To(vm => vm.HistoryItems);
            set.Bind(HistoryItems).To(vm => vm.HistoryItems);
            
            set.Bind(_searchHistoryViewSource).For(s => s.SelectionChangedCommand).To(vm => vm.HistoryNavCommand);
            set.Bind(_searchHistoryViewSource).For(s => s.RemoveRowCommand).To(vm => vm.RemoveRowCommand); //Delete

            set.Apply();

            this.TableView.EstimatedRowHeight = 100f;
            this.TableView.ReloadData();
        }

    }
}