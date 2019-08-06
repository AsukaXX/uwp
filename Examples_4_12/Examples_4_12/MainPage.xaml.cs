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

namespace Examples_4_12
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            DateTime dateTime = DateTime.Now;
            time.Time = new TimeSpan(dateTime.Hour,dateTime.Minute,dateTime.Second);
            date.Date = DateTimeOffset.Now;
            info.Text = "时间：" + time.Time.ToString() + " 日期：" + date.Date.Date.ToString();
        }

        private void time_TimeChanged(object sender, TimePickerValueChangedEventArgs e)
        {
            info.Text = "时间改变为：" + time.Time.ToString() + " 日期：" + date.Date.Date.ToString();
        }

        private void date_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            info.Text = "时间：" + time.Time.ToString() + " 日期改变为：" + date.Date.Date.ToString();
        }
    }
}
