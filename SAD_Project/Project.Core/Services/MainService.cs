using Project.Core.Models;
using Project.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Services
{
    public class MainService : IMainService
    {
        private readonly ISearchHistoryRepository _searchHistoryRepository;

        //Ctor
        public MainService(ISearchHistoryRepository searchHistoryRepository)
        {
            _searchHistoryRepository = searchHistoryRepository;
        }

        public async Task AddHistoryItem(HistoryItem item)
        {
            await _searchHistoryRepository.PosthistoryItem(item);
        }
    }
}
