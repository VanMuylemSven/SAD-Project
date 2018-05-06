using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvvmCross.Core;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;
using MvvmCross.Plugins.Messenger;
using MvvmCross.Tests;
using Project.Core.Models;
using Project.Core.Services;
using Project.Core.ViewModels;
using Project.Tests.Plumbing;

namespace Project.Tests.Tests
{
    [TestClass]
    public class SearchHistoryViewModelTest : MvxIoCSupportingTest
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

        /*Check if property SearchHistory of ViewModel actually contains objects 
         * */
        [TestMethod]
        public void History_Property_Return_All_HistoryItems()
        {
            //ARRANGE
            var historyList = new List<HistoryItem>();
            historyList.Add(new HistoryItem() { Id = "1",  Name = "Hogeschool Kortrijk", DateOfSearch = "1999-01-01 00:00:00", Latitude = "55.5", Longitude = "42.2" });
            historyList.Add(new HistoryItem() { Id = "2", Name = "Hogeschool Gent", DateOfSearch = "2019-01-01 00:00:00", Latitude = "85.5", Longitude = "41.2" });

            var mockHistoryService = new Mock<ISearchHistoryService>();
            var mockNavService = new Mock<IMvxNavigationService>();
            var mockMessenger = new Mock<IMvxMessenger>();
            mockHistoryService.Setup(ws => ws.GetHistoryItems()).Returns(Task.FromResult(historyList));

            var vm = new SearchHistoryViewModel(mockHistoryService.Object,mockNavService.Object, mockMessenger.Object);

            //ACT
            var allHistoryItems = vm.HistoryItems;

            //ASSERT
            Assert.IsNotNull(allHistoryItems);
            Assert.IsTrue(allHistoryItems.Count == 2);
        }

        [TestMethod]
        public void Add_Valid_HistoryItem()
        {
            HistoryItem historyItem = new HistoryItem() {
                Id = "0", Name = "Kortrijk", DateOfSearch = DateTime.Now.ToString(), Latitude = "55.5", Longitude = "42.2"
            };

            Assert.IsTrue(CheckHistoryItem(historyItem));

        }
        private bool CheckHistoryItem(HistoryItem item)
        {
            if (item.Name != null && item.Latitude != null && item.Longitude != null && item.Id != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [TestMethod]
        public void Add_Invalid_HistoryItem_No_Name()
        {
            HistoryItem historyItem = new HistoryItem()
            {
                Name = "Kortrijk",
                DateOfSearch = DateTime.Now.ToString(),
                Latitude = "55.5",
                Longitude = "42.2"
            };

            Assert.IsFalse(CheckHistoryItem(historyItem));
        }


        [TestMethod]
        public void Executing_HistoryNavCommand_Navigates_Back_To_Main_Screen()
        {
            //ARRANGE 
            var mockNavService = new Mock<IMvxNavigationService>();

            HistoryItem historyItem = new HistoryItem()
            {
                Name = "Kortrijk",
                DateOfSearch = DateTime.Now.ToString(),
                Latitude = "55.5",
                Longitude = "42.2"
            };
            var vm = new SearchHistoryViewModel(null, mockNavService.Object, null);
            vm.HistoryNavCommand.Execute(historyItem);
            //ACT 

            //ASSERT
            mockNavService.Verify(nav => nav.Navigate<MainViewModel>(null), Times.Once());
        }


    }
}
