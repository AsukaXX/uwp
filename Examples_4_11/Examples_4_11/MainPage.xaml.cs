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

namespace Examples_4_11
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            redSlider.Value = 128;
            buleSlider.Value = 128;
            greenSlider.Value = 128;
        }

        private void OnSliderValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Color clr = Color.FromArgb(255, (byte)redSlider.Value, (byte)greenSlider.Value, (byte)buleSlider.Value);
            ellipse1.Fill = new SolidColorBrush(clr);
            textBlock1.Text = clr.ToString();
            redText.Text = clr.R.ToString("X2");
            greenText.Text = clr.G.ToString("X2");
            buleText.Text = clr.B.ToString("X2");
        }
    }
}
