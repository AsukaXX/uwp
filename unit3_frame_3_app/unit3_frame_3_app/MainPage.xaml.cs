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

namespace unit3_frame_3_app
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

        private void OnClick(object sender, RoutedEventArgs e)
        {
            if(txtID.Text == ""||txtName.Text ==""||txtAge.Text == "")
            {
                return;
            }
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("id", txtID.Text);
            data.Add("name", txtName.Text);
            data.Add("age", txtAge.Text);
            this.Frame.Navigate(typeof(DisplayPage), data);
        }
    }
}
