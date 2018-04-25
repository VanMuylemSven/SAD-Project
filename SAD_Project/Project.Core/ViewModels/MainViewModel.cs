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
        private IMainService _mainService;
        public MainViewModel(IMainService mainService)
        {
            _mainService = mainService;

            
        }
        
        //Props


        //Methods //Services gebruiken, ya dolt!


        /*Commands: speciale properties in een ViewModel waaraan we een actie kunnen koppelen. 
        De command zelf binden we dan aan een knop. Wanneer iemand op de knop drukt dan zal het command uitgevoerd worden.*/
        /*public ICommand BmiCalculatorScreenCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<BmiCalculatorViewModel>());
            }
        }*/
  


        
    }
}
