﻿/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:PowerliminalsPlayer"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using System;
using System.Diagnostics.CodeAnalysis;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CommonServiceLocator;
using CommonServiceLocator.WindsorAdapter;
using GalaSoft.MvvmLight;
using HanumanInstitute.CommonServices;
using HanumanInstitute.CommonWpfApp;
using HanumanInstitute.Downloads;
using HanumanInstitute.FFmpeg;
using MvvmDialogs;

namespace HanumanInstitute.YangYouTubeDownloader.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    [SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "Required for designer integration")]
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            using var container = new WindsorContainer();
            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            // Services
            container.AddCommonServices();
            container.AddDownloads();
            container.AddFFmpeg();

            container.Register(Component.For<IDialogService>().ImplementedBy<DialogService>()
                .DependsOn(Dependency.OnValue("dialogTypeLocator", new AppDialogTypeLocator())).LifeStyle.Transient);

            // ViewModdels
            if (ViewModelBase.IsInDesignModeStatic)
            {
                container.Register(Component.For<IMainViewModel>().ImplementedBy<MainViewModelDesign>().LifeStyle.Transient);
            }
            else
            {
                container.Register(Component.For<IMainViewModel>().ImplementedBy<MainViewModel>().LifeStyle.Transient);
            }
        }

        public static IMainViewModel Main => ServiceLocator.Current.GetInstance<IMainViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
