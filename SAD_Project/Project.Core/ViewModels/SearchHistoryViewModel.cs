using MapKit;
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

        /*define the classes which will subscribe to and receive these messages. Each of these classes must call one of the Subscribe methods 
         * on the IMvxMessenger and must store the returned token. For example part of a ViewModel receiving LocationMessages might look like:*/
        private readonly MvxSubscriptionToken _token; 

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
        public SearchHistoryViewModel(ISearchHistoryService searchHistoryService, IMvxNavigationService navigationService, IMvxMessenger messenger)
        {
            _searchHistoryService = searchHistoryService;
            _navigationService = navigationService;
                //Subscribe - messages will be passed directly on the Publish thread.
            _token = messenger.Subscribe<HistoryItemMessage>(OnHistoryItemMessage); 

            /* //Test post history */
            /*string date = DateTime.Now.ToString();
            HistoryItem testItem = new HistoryItem() { Id="10", Name = "Test7", DateOfSearch = date,
                Latitude = "55.5", Longitude = "42.2" } ;
            PostHistory(testItem);*/

            //Fill the table with data from the SearchHistory API
            FillHistory();
            
        }

        //Messenger
        private void OnHistoryItemMessage(HistoryItemMessage historyItemMessage)
        {
            Debug.WriteLine("RECEIVED HISTORY ITEM TO POST FROM MESSAGE");

            //Now Post received historyItem to the HistoryAPI
            //PostHistory(historyItemMessage.NewHistoryItem);
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


        public static List<HistoryItem> GetHistoryItems()
        {
            return StaticHistoryItems;
        }

        public IMvxCommand PostHistoryItem
        {
            get
            {
                return new MvxCommand<HistoryItem>(PostHistory);
            }

        }

    }
}
