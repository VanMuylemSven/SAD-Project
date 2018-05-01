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

        private List<HistoryItem> _historyItems;

        public List<HistoryItem> HistoryItems
        {
            get { return _historyItems; }
            set { _historyItems = value;
                RaisePropertyChanged(() => HistoryItems);
            }
        }

        //ctor
        public SearchHistoryViewModel(ISearchHistoryService searchHistoryService)
        {
            _searchHistoryService = searchHistoryService;

            FillHistory();


        }

        private async void FillHistory()
        {
            HistoryItems = await _searchHistoryService.GetHistoryItems();

        }

    }
}
