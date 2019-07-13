using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Examples_4_2
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //在.xaml.cs页面动态生成TextBlock控件
            TextBlock textBlock = new TextBlock();
            textBlock.Height = 50;
            textBlock.Width = 200;
            textBlock.FontSize = 18;
            textBlock.Text = "在CS页面生成TextBlock";
            textBlock.Foreground = new SolidColorBrush(Colors.Blue);
            stackPanel.Children.Add(textBlock);
        }
    }
}
