using MapKit;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Project.Core.Models;
using Project.Core.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.ViewModels
{
    public class SearchHistoryViewModel : MvxViewModel
    {
        private readonly ISearchHistoryService _searchHistoryService;
        private readonly IMvxNavigationService _navigationService;

        private List<HistoryItem> _historyItems;

        public List<HistoryItem> HistoryItems
        {
            get { return _historyItems; }
            set { _historyItems = value;
                RaisePropertyChanged(() => HistoryItems);
            }
        }

        //To do: Do not use static copy????
        public static List<HistoryItem> StaticHistoryItems { get; set; }

        //ctor
        public SearchHistoryViewModel(ISearchHistoryService searchHistoryService, IMvxNavigationService navigationService)
        {
            _searchHistoryService = searchHistoryService;
            _navigationService = navigationService;

            /* //Test post history */
            /*string date = DateTime.Now.ToString();
            HistoryItem testItem = new HistoryItem() { Id="10", Name = "Test7", DateOfSearch = date,
                Latitude = "55.5", Longitude = "42.2" } ;
            PostHistory(testItem);*/

            //Fill the table with data from the SearchHistory API
            FillHistory();
            
        }

        private async void FillHistory()
        {
            HistoryItems = await _searchHistoryService.GetHistoryItems();
            StaticHistoryItems = HistoryItems;
        }

        private async void PostHistory(HistoryItem item)
        {
            await _searchHistoryService.AddHistoryItem(item);
            //await _navigationService.Navigate... //Back to mainscreen
        }

        public IMvxCommand HistoryNavCommand {
            get {
                return new MvxCommand<HistoryItem>(BackwardsNavCommand);
            }

        }

        private void BackwardsNavCommand(HistoryItem hiParam)
        {
            _navigationService.Navigate<MainViewModel, HistoryItem>(hiParam);
        }

        public IMvxCommand testlogCommand
        {
            get
            {
                return new MvxCommand(testlog);
            }
        }
        public void testlog()
        {
            Debug.WriteLine("TESTED THIS SHIZZLE");
        }

        public static List<HistoryItem> GetHistoryItems()
        {
            return StaticHistoryItems;
        }
    }
}
