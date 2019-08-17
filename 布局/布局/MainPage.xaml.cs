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

namespace 布局
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string Operation = "";
        private double numl = 0;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            info.Text = (sender as TextBox).Text;
        }

        private void Digitbtn_Click(object sender, RoutedEventArgs e)
        {
            if(Operation == "=")
            {
                OperatinResult.Text = "";
                InpuInformation.Text = "";
                Operation = "";
                numl = 0;
            }
            string s = ((Button)sender).Content.ToString();
            OperatinResult.Text = OperatinResult.Text + s;
            InpuInformation.Text = InpuInformation.Text + s;
        }

        private void OperationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Operation == "=")
            {
                InpuInformation.Text = OperatinResult.Text;
                Operation = "";
            }
            string s = (sender as Button).Content.ToString();
            InpuInformation.Text = InpuInformation.Text + s;
            OperationNum(s);
            OperatinResult.Text = "";
        }

        private void OperationNum(string s)
        {
            if (OperatinResult.Text != "")
            {
                switch (Operation)
                {
                    case "":
                        numl = Int32.Parse(OperatinResult.Text);
                        Operation = s;
                        break;
                    case "+":
                        numl = numl + Int32.Parse(OperatinResult.Text);
                        Operation = s;
                        break;
                    case "-":
                        numl = numl - Int32.Parse(OperatinResult.Text);
                        Operation = s;
                        break;
                    case "*":
                        numl = numl * Int32.Parse(OperatinResult.Text);
                        Operation = s;
                        break;
                    case "/":
                        if (Int32.Parse(OperatinResult.Text) != 0)
                            numl = numl / Int32.Parse(OperatinResult.Text);
                        else
                            numl = 0;
                        Operation = s;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Operation = s;
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            OperatinResult.Text = "";
            InpuInformation.Text = "";
            Operation = "";
            numl = 0;
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            OperationNum("=");
            OperatinResult.Text = numl.ToString();
        }
    }
}
