using MapKit;
using Microsoft.AppCenter.Analytics;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
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

        /*define the classes which will subscribe to and receive these messages. Each of these classes must call one of the Subscribe methods 
        * on the IMvxMessenger and must store the returned token.*/
        private readonly MvxSubscriptionToken _token; 

        //no static. :<
        //public static List<HistoryItem> StaticHistoryItems { get; set; }

        //ctor
        public SearchHistoryViewModel(ISearchHistoryService searchHistoryService, IMvxNavigationService navigationService, IMvxMessenger messenger)
        {
            _searchHistoryService = searchHistoryService;
            _navigationService = navigationService;
            //Subscribe - Whenever a SearchFilterMessage is received, trigger the OnFIlterMessage method 
            _token = messenger.Subscribe<SearchFilterMessage>((message => { OnFilterMessage(message.FilterName); })
                );

            //Fill the table with data from the SearchHistory API
            FillHistory();
        }

        private async void FillHistory()
        {
            HistoryItems = await _searchHistoryService.GetHistoryItems();
            Analytics.TrackEvent("Search History - GETting history items from API");
        }

        private async void PostHistory(HistoryItem item)
        {
            await _searchHistoryService.AddHistoryItem(item);
            Analytics.TrackEvent("Search History - POSTing item to API");
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



        public IMvxCommand PostHistoryItem
        {
            get
            {
                return new MvxCommand<HistoryItem>(PostHistory);
            }
        }

        public IMvxCommand<int> RemoveRowCommand
        {
            get
            {
                return new MvxCommand<int>(RemoveHistoryItem);
            }
        }

        private void RemoveHistoryItem(int index)
        {
            HistoryItem historyItem = HistoryItems[index];
            _searchHistoryService.DeleteHistoryItem(historyItem.Id);
            FillHistory();
            Analytics.TrackEvent("Search History - DELETEing item from API");
        }


        /* Do this Whenever the SearchFilterMessage is Received */
        public async void OnFilterMessage(string name)
        {
            HistoryItems = await _searchHistoryService.GetHistoryByName(name);
            Analytics.TrackEvent("Search History - GETting filtered history items from API");
        }


        public IMvxCommand TestCommand
        {
            get
            {
                return new MvxCommand(testlog);
            }
        }

        private void testlog()
        {
            int i = 0;
        }
    }
}
