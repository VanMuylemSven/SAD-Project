using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvvmCross.Core;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;
using MvvmCross.Tests;
using Project.Core.ViewModels;
using Project.Tests.Plumbing;

namespace Project.Tests.Tests
{
    [TestClass]
    public class MainViewModelTest : MvxIoCSupportingTest
    {
        protected MockDispatcher MockDispatcher;

        protected override void AdditionalSetup()
        {
            base.AdditionalSetup();
            MockDispatcher = new MockDispatcher();
            Ioc.RegisterSingleton<IMvxViewDispatcher>(MockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(MockDispatcher);
            //Required only when passing parameters
            Ioc.RegisterSingleton<IMvxStringToTypeParser>(new MvxStringToTypeParser());
        }

        [TestMethod]
        public void Executing_SearchHistoryCommand_Navigates_To_History_Screen()
        {
            //ARRANGE 
            var mockNavService = new Mock<IMvxNavigationService>();

            var vm = new MainViewModel(null, mockNavService.Object);
            vm.SearchHistoryCommand.Execute();
            //ACT 

            //ASSERT
            mockNavService.Verify(nav => nav.Navigate<SearchHistoryViewModel>(null), Times.Once());
        }
    }
}
