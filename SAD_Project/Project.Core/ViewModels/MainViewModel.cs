using CoreLocation;
using MapKit;
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
        //ctor
        private readonly IMainService _mainService;
        private readonly IMvxNavigationService _navigationService;
        private readonly ISearchHistoryService _searchHistoryService;

        private HistoryItem _selectedHistoryItem;

        public HistoryItem SelectedHistoryItem
        {
            get { return _selectedHistoryItem; }
            set { _selectedHistoryItem = value;
                RaisePropertyChanged(() => SelectedHistoryItem);
            }
        }


        //public MKMapView mainMap { get; set; }


        public MainViewModel(IMainService mainService, ISearchHistoryService searchHistoryService, IMvxNavigationService navigationService)
        {
            _mainService = mainService;
            _navigationService = navigationService;
            _searchHistoryService = searchHistoryService;

            //mainMap = new MKMapView();
            //CLLocationCoordinate2D coord = new CLLocationCoordinate2D(50, 50);
            //mainMap.SetCenterCoordinate(coord, true);

        }

        //Props


        //Methods //Services gebruiken, ya dolt!


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


        /*public IMvxCommand AddAnnoCommand
        {
            get
            {
                return new MvxCommand(test);
            }
        }
        public void test()
        {
            Debug.WriteLine("sdgfhsdjhfdskf");
        }*/

        public override void Prepare(HistoryItem parameter)
        {
            this.SelectedHistoryItem = parameter;
        }
    }
}
