using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Core.Models;

namespace Project.Core.Services
{
    public interface ISearchHistoryService
    {
        Task AddHistoryItem(HistoryItem item);
        Task DeleteHistoryItem(string id);
        Task<List<HistoryItem>> GetHistoryItems();
    }
}