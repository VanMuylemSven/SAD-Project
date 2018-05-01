using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Project.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        //ctor
        private readonly IMainService _mainService;
        private readonly IMvxNavigationService _navigationService;
        public MainViewModel(IMainService mainService, IMvxNavigationService navigationService)
        {
            _mainService = mainService;
            _navigationService = navigationService;
            
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




    }
}
