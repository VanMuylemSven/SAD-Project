using MvvmCross.Core.ViewModels;
using Project.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.ViewModels
{
    public class TestViewModel : MvxViewModel
    {
        private readonly ITestService _testService;

        public TestViewModel(ITestService testService)
        {
            _testService = testService;
        }

        public void DoStuff()
        {

        }
    }
}
