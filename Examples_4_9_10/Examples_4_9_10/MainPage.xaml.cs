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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Examples_4_9_10
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DispatcherTimer tmrDown;
        private DispatcherTimer tmrUp;
        public MainPage()
        {
            this.InitializeComponent();
            for(int i = 0; i <= 30; i++)
            {
                Image imgItem = new Image();
                imgItem.Width = 500;
                imgItem.Height = 500;
                if (i % 4==0)
                {
                    imgItem.Source = (new BitmapImage(new Uri("ms-appx:///Image/9b8c16f5gw1f5q1oga0roj215o1qigw9.jpg", UriKind.RelativeOrAbsolute)));
                }else if(i%4 == 1)
                {
                    imgItem.Source = (new BitmapImage(new Uri("ms-appx:///Image/9b8c16f5gw1f5q1phj6hbj215o1qiws0.jpg", UriKind.RelativeOrAbsolute)));
                }else if (i % 4 == 2)
                {
                    imgItem.Source = (new BitmapImage(new Uri("ms-appx:///Image/9b8c16f5ly1flr6x1uz4rj21901o0qv5.jpg", UriKind.RelativeOrAbsolute)));
                }else
                {
                    imgItem.Source = (new BitmapImage(new Uri("ms-appx:///Image/9b8c16f5ly1fqgnbsuqysj20yo0q0h5f.jpg", UriKind.RelativeOrAbsolute)));
                }
                this.stkpnlImage.Children.Add(imgItem);
            }
            tmrDown = new DispatcherTimer();
            tmrDown.Interval = new TimeSpan(500);
            tmrDown.Tick += tmrDown_Tick;
            tmrUp = new DispatcherTimer();
            tmrUp.Interval = new TimeSpan(500);
            tmrUp.Tick += tmrUp_Tick;
        }

        [Obsolete]
        private void tmrUp_Tick(object sender, object e)
        {
            scrollViewer1.ScrollToVerticalOffset(scrollViewer1.VerticalOffset - 10);
        }

        [Obsolete]
        private void tmrDown_Tick(object sender, object e)
        {
            tmrUp.Stop();
            scrollViewer1.ScrollToVerticalOffset(scrollViewer1.VerticalOffset + 10);
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            tmrDown.Stop();
            tmrUp.Start();
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            tmrDown.Start();
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            tmrUp.Stop();
            tmrDown.Stop();
        }
    }
}
