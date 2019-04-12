using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace unit3_frame_2_app
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            string item = e.ClickedItem as string;
            if (!string.IsNullOrEmpty(item))
            {
                switch (item)
                {
                    case "Page 1":
                        fame.Navigate(typeof(Page1));
                        break;
                    case "Page 2":
                        fame.Navigate(typeof(Page2));
                        break;
                    case "Page 3":
                        fame.Navigate(typeof(Page3));
                        break;
                }
            }
        }

        private void OnFrameNavigating(object sender, NavigatingCancelEventArgs e)
        {
            string msg = "Frame的Navigating事件发生，SourcePageType = {0}";
            System.Diagnostics.Debug.WriteLine(msg, e.SourcePageType);
        }

        private void OnFrameNavigated(object sender, NavigationEventArgs e)
        {
            string msg = "Frame的Navigated事件发生，SourcePageType = {0}";
            System.Diagnostics.Debug.WriteLine(msg, e.SourcePageType);
        }
    }
}
