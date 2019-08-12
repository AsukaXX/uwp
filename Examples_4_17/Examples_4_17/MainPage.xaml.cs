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

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Examples_4_17
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

        private void CommandBar_Opened(object sender, object e)
        {
            info.Text = "菜单栏打开了";
        }

        private void CommandBar_Closed(object sender, object e)
        {
            info.Text = "菜单栏关闭了";
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            info.Text = "单击了菜单栏：" + (sender as AppBarButton).Label;
        }

    }
}
