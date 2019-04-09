using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace App
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MyApp : Application
    {
        private TransitionCollection transitions;
        public MyApp()
        {
            this.InitializeComponent();
            this.Suspending +=this.OnSuspending;
        }
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            //MainPage page = new MainPage();
            //base.OnLaunched(args);
            //Window.Current.Content = page;
            Frame rootFrame = Window.Current.Content as Frame;
            if(rootFrame == null)
            {
                rootFrame = new Frame();
                rootFrame.CacheSize = 1;

                if(args.PreviousExecutionState == ApplicationExecutionState.Terminated||args.PreviousExecutionState == ApplicationExecutionState.ClosedByUser)
                {
                    UserData.LoadData();
                }
            }
            Window.Current.Content = rootFrame;
            //root.Navigate(typeof(MainPage));
            if(rootFrame.Content == null)
            {
                if(rootFrame.ContentTransitions != null)
                {
                    this.transitions = new TransitionCollection();
                    foreach(var c in rootFrame.ContentTransitions)
                    {
                        this.transitions.Add(c);
                    }
                }
                rootFrame.ContentTransitions = null;
                rootFrame.Navigated += this.RootFrame_FirstNavigated;
                if (!rootFrame.Navigate(typeof(MainPage), args.Arguments))
                {
                    throw new Exception("failed");
                }
            }
            Window.Current.Activate();
        }
        private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
        {
            var rootFrame = sender as Frame;
            rootFrame.ContentTransitions = this.transitions ?? new TransitionCollection() { new NavigationThemeTransition() };
            rootFrame.Navigated -= RootFrame_FirstNavigated;
        }
        private void OnSuspending(object sender,SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            UserData.SaveData();
            deferral.Complete();
        }
    }
}
