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

namespace Examples_4_16
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            List<Man> datas = new List<Man>
            {
                new Man{Name = "张三",Age=20},
                new Man{Name="李四",Age=34},
                new Man{Name="王五" ,Age=43},
                new Man{Name="刘六",Age=33},
                new Man{Name="王七",Age=44}
            };
            comboBox2.ItemsSource = datas;
        }

        private void ComboBox2_DropDownClosed(object sender, object e)
        {
            if (comboBox2.SelectedItem != null)
            {
                Man man = comboBox2.SelectedItem as Man;
                Info.Text = "name: " + man.Name + " age: " + man.Age;
            }
        }
    }

    public class Man
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
