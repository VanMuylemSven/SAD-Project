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

            this.TableView.Source = _searchHistoryViewSource;
            this.TableView.ReloadData();

            MvxFluentBindingDescriptionSet<SearchHistoryView, SearchHistoryViewModel> set = new MvxFluentBindingDescriptionSet<SearchHistoryView, SearchHistoryViewModel>(this);
            set.Bind(_searchHistoryViewSource).To(vm => vm.HistoryItems);
            set.Bind(HistoryItems).To(vm => vm.HistoryItems);

            //Setting annotation in the mainview
            //MvxFluentBindingDescriptionSet<SearchHistoryView, MainViewModel> set2 = new MvxFluentBindingDescriptionSet<SearchHistoryView, MainViewModel>(this);
            //set2.Bind(_searchHistoryViewSource).For(s => s.SelectionChangedCommand).To(vm => vm.AddAnnoCommand);
            //set.Bind(_searchHistoryViewSource.SelectionChangedCommand).To(vm => vm.HistoryNavCommand);
            set.Bind(_searchHistoryViewSource).For(s => s.SelectionChangedCommand).To(vm => vm.HistoryNavCommand);

            set.Apply();
            //set2.Apply();
        }

    }
}