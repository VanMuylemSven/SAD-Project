using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Core.Models;

namespace Project.Core.Repositories
{
    interface ISearchHistoryRepository
    {
        Task DeleteHistoryItem(string id);
        Task<List<HistoryItem>> GetHistory();
        Task<HistoryItem> PosthistoryItem(HistoryItem historyItem);
    }
}