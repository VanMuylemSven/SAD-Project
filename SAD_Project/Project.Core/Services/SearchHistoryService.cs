using Project.Core.Models;
using Project.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Services
{
    public class SearchHistoryService : ISearchHistoryService
    {

        private static List<HistoryItem> historyItems = new List<HistoryItem>();
        private readonly ISearchHistoryRepository _searchHistoryRepository;

        //Ctor
        public SearchHistoryService(ISearchHistoryRepository searchHistoryRepository)
        {
            _searchHistoryRepository = searchHistoryRepository;
        }

        // Repo methods //
        public async Task AddHistoryItem(HistoryItem item)
        {
            await _searchHistoryRepository.PosthistoryItem(item);
        }

        public async Task<List<HistoryItem>> GetHistoryItems()
        {
            return await _searchHistoryRepository.GetHistory();
        }

        public async Task DeleteHistoryItem(string id)
        {
            await _searchHistoryRepository.DeleteHistoryItem(id);
        }


    }
}
