using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvvmCross.Core;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;
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
            /*We moeten dus eerst onze test parameters opstellen. We voegen een aantal dummy wijnen toe.*/
            var historyList = new List<HistoryItem>();
            historyList.Add(new HistoryItem() { Id = "1",  Name = "Hogeschool Kortrijk", DateOfSearch = "1999-01-01 00:00:00", Latitude = "55.5", Longitude = "42.2" });
            historyList.Add(new HistoryItem() { Id = "2", Name = "Hogeschool Gent", DateOfSearch = "2019-01-01 00:00:00", Latitude = "85.5", Longitude = "41.2" });
            /*Daarna zullen we via Moq een fake Service aanmaken. Via de Setup() methode van Moq kunnen we zeggen dat de methode GetHistory() van 
             * onze webservice een lijst van wijnen moet terugkeren. We gaan hier dus NIET de live webservice aanspreken maar dummy data.*/
            var mockHistoryService = new Mock<ISearchHistoryService>();
            mockHistoryService.Setup(ws => ws.GetHistoryItems()).Returns(Task.FromResult(historyList));
            /*Als laatste moeten we de fake service doorgeven aan het viewmodel.*/
            var vm = new SearchHistoryViewModel(mockHistoryService.Object);

            //ACT
            var allHistoryItems = vm.HistoryItems;

            //ASSERT
            Assert.IsNotNull(allHistoryItems);
            Assert.IsTrue(allHistoryItems.Count == 2);
        }

        [TestMethod]
        public void test()
        {

        }

    }
}
