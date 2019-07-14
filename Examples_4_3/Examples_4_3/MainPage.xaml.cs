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

namespace Examples_4_3
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
        string text = "";
        string selectedText = "";
        string pasteTest = "";

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            text = TextBox1.Text;
            ShowInformation();
        }

        private void ShowInformation()
        {
            textBlock1.Text="文本信息："+"\"" + text + "\""+"选择的信息："+"\"" + selectedText+"\""+"粘贴的信息："+"\""+pasteTest+"\"";
        }

        private void TextBox1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            selectedText = TextBox1.SelectedText;
            ShowInformation();
        }

        private void TextBox1_Paste(object sender, TextControlPasteEventArgs e)
        {
            text = TextBox1.Text;
            selectedText = TextBox1.SelectedText;
            pasteTest = "产生了粘贴操作";
            ShowInformation();
        }
    }
}
