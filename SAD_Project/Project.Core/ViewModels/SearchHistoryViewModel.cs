using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Project.Core.Models;
using Project.Core.Services;
using System;
using System.Collections.Generic;
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

        //ctor
        public SearchHistoryViewModel(ISearchHistoryService searchHistoryService, IMvxNavigationService navigationService)
        {
            _searchHistoryService = searchHistoryService;
            _navigationService = navigationService;

            FillHistory();

            /* Test post history */
            string date = DateTime.Now.ToString();
            HistoryItem testItem = new HistoryItem() { Id="4", Name = "Hogeschool Kortrijk", DateOfSearch = "1999-01-01 00:00:00",
                Latitude = "55.5", Longitude = "42.2" } ;
            PostHistory(testItem);

        }

        private async void FillHistory()
        {
            HistoryItems = await _searchHistoryService.GetHistoryItems();

        }

        private async void PostHistory(HistoryItem item)
        {
            await _searchHistoryService.AddHistoryItem(item);
            //await _navigationService.Navigate...
        }
    }
}
