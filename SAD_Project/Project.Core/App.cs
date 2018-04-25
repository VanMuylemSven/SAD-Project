using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes().
                EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes().
                EndingWith("Repository")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //Als voorlopig laatste stap stellen we nu xxxViewModel in als startviewmodel in App.cs via
            RegisterNavigationServiceAppStart<ViewModels.MainViewModel>();
        }
    }
}
