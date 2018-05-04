using System.Threading.Tasks;
using Project.Core.Models;

namespace Project.Core.Services
{
    public interface IMainService
    {
        Task AddHistoryItem(HistoryItem item);
    }
}