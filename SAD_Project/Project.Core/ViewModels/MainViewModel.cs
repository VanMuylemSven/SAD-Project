using CoreLocation;
using MapKit;
using Microsoft.AppCenter.Analytics;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Project.Core.Models;
using Project.Core.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.Core.ViewModels
{
    public class MainViewModel : MvxViewModel<HistoryItem>
    {
        private readonly IMainService _mainService;
        private readonly IMvxNavigationService _navigationService;
        //private readonly ISearchHistoryService _searchHistoryService;

        private HistoryItem _selectedHistoryItem;

        public HistoryItem SelectedHistoryItem
        {
            get { return _selectedHistoryItem; }
            set { _selectedHistoryItem = value;
                RaisePropertyChanged(() => SelectedHistoryItem);
            }
        }


        //ctor
        public MainViewModel(IMainService mainService, IMvxNavigationService navigationService)
        {
            _mainService = mainService;
            _navigationService = navigationService;
            Analytics.TrackEvent("MainViewModel - constructor event");
        }

        /*Commands: speciale properties in een ViewModel waaraan we een actie kunnen koppelen. 
        De command zelf binden we dan aan een knop. Wanneer iemand op de knop drukt dan zal het command uitgevoerd worden.*/
        public IMvxCommand SearchHistoryCommand
        {
            get
            {
                return new MvxCommand(ShowSearchHistoryScreen);
            }
        }
        public void ShowSearchHistoryScreen()
        {
            _navigationService.Navigate<SearchHistoryViewModel>(); 

            //ShowViewModel<TestViewModel>();
            //_navigationService.Navigate<TestViewModel>();
        }

        public async void PostHistoryItem(HistoryItem item)
        {
            await _mainService.AddHistoryItem(item);
        }

        //When navigating back from other viewmodel with SelectedHistoryItem info, put it in the SelectedHistoryItem Variable
        //Afterwards the View will access it directly for use in the Map.
        public override void Prepare(HistoryItem parameter)
        {
            this.SelectedHistoryItem = parameter;
        }



    }
}
