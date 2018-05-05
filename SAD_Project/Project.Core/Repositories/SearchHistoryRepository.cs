using Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Repositories
{
    public class SearchHistoryRepository : BaseRepository, ISearchHistoryRepository
    {
        private const string _BASEURL = "https://sad-history.azurewebsites.net/api/history/";

        public Task<List<HistoryItem>> GetHistory()
        {
            /*https://sad-history.azurewebsites.net/api/history/GetAll*/
            string url = String.Format("{0}{1}", _BASEURL, "getall");
            Task<List<HistoryItem>> list = GetAsync<List<HistoryItem>>(url);
            return GetAsync<List<HistoryItem>>(url);
        }


        /*https://sad-history.azurewebsites.net/api/history/add/
        { 
            "Name": "station kortrijk",
            "DateOfSearch": "1900-01-01 00:00:00",
            "Latitude": 50.8247952,
            "Longitude": 3.26435160000005
        }*/
        public Task<HistoryItem> PosthistoryItem(HistoryItem historyItem)
        {
            string url = String.Format("{0}{1}/", _BASEURL, "add");
            return PostAsync<HistoryItem>(url, historyItem);
        }

        public Task DeleteHistoryItem(string id)
        {
            string url = String.Format("{0}{1}/{2}", _BASEURL, "delete", id);
            return DeleteAsync<HistoryItem>(url);
        }

        public Task<List<HistoryItem>> GetHistoryByName(string name)
        {
            string url = String.Format("{0}{1}/{2}", _BASEURL, "get", name);
            Task<List<HistoryItem>> list = GetAsync<List<HistoryItem>>(url);
            return GetAsync<List<HistoryItem>>(url);
        }
    }
}
