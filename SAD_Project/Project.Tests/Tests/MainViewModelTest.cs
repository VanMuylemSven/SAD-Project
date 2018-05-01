using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmCross.Core;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;
using MvvmCross.Tests;
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
        public void Can_Navigate_To_SearchHistoryViewModel()
        {

        }
    }
}
