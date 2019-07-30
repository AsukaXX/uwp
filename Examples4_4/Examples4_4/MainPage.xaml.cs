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
using Windows.UI.Xaml.Shapes;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Examples4_4
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //动态填充brdTest里面的子元素
            Rectangle rectBule = new Rectangle();
            rectBule.Width = 1000;
            rectBule.Height = 1000;
            SolidColorBrush scBrush = new SolidColorBrush(Colors.Blue);
            rectBule.Fill = scBrush;
            this.brdTest.Child = rectBule;
        }

        private void TextBlock_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            //0表示完全透明的；1表示完全显示出来的
            TextBoeder.BorderBrush.Opacity = 0.5;
        }
    }
}
