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
    public class SearchHistoryViewModel: MvxViewModel
    {
        private readonly ISearchHistoryService _searchHistoryService;

        private List<HistoryItem> _historyItems;
        public List<HistoryItem> HistoryItems
        {
            get { return _historyItems; }
            set
            {
                _historyItems = value;
                RaisePropertyChanged(() => HistoryItems);
            }
        }

        public SearchHistoryViewModel(ISearchHistoryService searchHistoryService, IMvxNavigationService navigationService)
        {
            _searchHistoryService = searchHistoryService;
            //_navigationService = navigationService;

            //Fill up the historyItem list
            FillHistoryItems();
        }
        private async void FillHistoryItems()
        {
            HistoryItems = await _searchHistoryService.GetHistoryItems();
        }
    }
}
