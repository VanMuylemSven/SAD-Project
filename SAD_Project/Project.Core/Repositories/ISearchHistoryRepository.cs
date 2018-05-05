using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Core.Models;

namespace Project.Core.Repositories
{
    public interface ISearchHistoryRepository
    {
        Task DeleteHistoryItem(string id);
        Task<List<HistoryItem>> GetHistory();
        Task<HistoryItem> PosthistoryItem(HistoryItem historyItem);
        Task<List<HistoryItem>> GetHistoryByName(string name);
    }
}