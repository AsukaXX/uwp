using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace 控件
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string text = "";
        string selectedText = "";
        string pasteTest = "";

        private DispatcherTimer tmrDown;
        private DispatcherTimer tmrUp;

        [Obsolete]
        public MainPage()
        {
            this.InitializeComponent();

            TextBlock textBlock = new TextBlock();
            textBlock.Height = 50;
            textBlock.Width = 200;
            textBlock.FontSize = 18;
            textBlock.Text = "在CS页面生成TextBlock";
            textBlock.Foreground = new SolidColorBrush(Colors.Blue);
            stackPanel.Children.Add(textBlock);

            Rectangle rectBule = new Rectangle();
            rectBule.Width = 1000;
            rectBule.Height = 1000;
            SolidColorBrush scBrush = new SolidColorBrush(Colors.Blue);
            rectBule.Fill = scBrush;
            this.brdTest.Child = rectBule;

            progressBar1.Visibility = Visibility.Collapsed;

            for (int i = 0; i <= 30; i++)
            {
                Image imgItem = new Image();
                imgItem.Width = 500;
                imgItem.Height = 500;
                if (i % 4 == 0)
                {
                    imgItem.Source = (new BitmapImage(new Uri("ms-appx:///Image/9b8c16f5gw1f5q1oga0roj215o1qigw9.jpg", UriKind.RelativeOrAbsolute)));
                }
                else if (i % 4 == 1)
                {
                    imgItem.Source = (new BitmapImage(new Uri("ms-appx:///Image/9b8c16f5gw1f5q1phj6hbj215o1qiws0.jpg", UriKind.RelativeOrAbsolute)));
                }
                else if (i % 4 == 2)
                {
                    imgItem.Source = (new BitmapImage(new Uri("ms-appx:///Image/9b8c16f5ly1flr6x1uz4rj21901o0qv5.jpg", UriKind.RelativeOrAbsolute)));
                }
                else
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

            DateTime dateTime = DateTime.Now;
            time.Time = new TimeSpan(dateTime.Hour, dateTime.Minute, dateTime.Second);
            date.Date = DateTimeOffset.Now;
            info.Text = "时间：" + time.Time.ToString() + " 日期：" + date.Date.Date.ToString();

            listPickerFlyout.ItemsSource = new List<string> { "诺基亚", "三星", "索尼" };

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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            button1.Content = "你点击我了！";
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            text = TextBox1.Text;
            ShowInformation();
        }

        private void ShowInformation()
        {
            textBlock1.Text = "文本信息：" + "\"" + text + "\"" + "选择的信息：" + "\"" + selectedText + "\"" + "粘贴的信息：" + "\"" + pasteTest + "\"";
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

        private void TextBlock_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            //0表示完全透明的；1表示完全显示出来的
            TextBoeder.BorderBrush.Opacity = 0.5;
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if (a.IsChecked == true)
                answer.Text = a.Content.ToString();
            if (b.IsChecked == true)
                answer.Text = b.Content.ToString();
            if (c.IsChecked == true)
                answer.Text = c.Content.ToString();
            if (d.IsChecked == true)
                answer.Text = d.Content.ToString();
        }

        private void McCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (McCheckBox3 != null)
                McCheckBox3.Content = "Checked";
        }

        private void McCheckBox_Unckecked(object sender, RoutedEventArgs e)
        {
            if (McCheckBox3 != null)
                McCheckBox3.Content = "Unckecked";
        }

        private void begin_Click(object sender, RoutedEventArgs e)
        {
            progressBar1.Visibility = Visibility.Visible;
            if (radioButton1.IsChecked == true)
            {
                progressBar1.IsIndeterminate = false;
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += timer_Tick;
                timer.Start();
            }
            else
            {
                progressBar1.Value = 0;
                progressBar1.IsIndeterminate = true;
            }
        }

        async void timer_Tick(object sender, object e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 10;
            }
            else
            {
                (sender as DispatcherTimer).Tick -= timer_Tick;
                (sender as DispatcherTimer).Stop();
                await new MessageDialog("进度完成").ShowAsync();
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            progressBar1.Visibility = Visibility.Collapsed;
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

        private void OnSliderValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Color clr = Color.FromArgb(255, (byte)redSlider.Value, (byte)greenSlider.Value, (byte)buleSlider.Value);
            ellipse1.Fill = new SolidColorBrush(clr);
            textBlock3.Text = clr.ToString();
            redText.Text = clr.R.ToString("X2");
            greenText.Text = clr.G.ToString("X2");
            buleText.Text = clr.B.ToString("X2");
        }

        private void time_TimeChanged(object sender, TimePickerValueChangedEventArgs e)
        {
            info.Text = "时间改变为：" + time.Time.ToString() + " 日期：" + date.Date.Date.ToString();
        }

        private void date_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            info.Text = "时间：" + time.Time.ToString() + " 日期改变为：" + date.Date.Date.ToString();
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            menuFlyoutButton.Content = (sender as MenuFlyoutItem).Text;
        }

        private async void DatePickerFlyout_DatePicked(DatePickerFlyout sender, DatePickedEventArgs args)
        {
            await new MessageDialog(args.NewDate.ToString()).ShowAsync();
        }

        private async void TimePickerFlyout_TimePicked(TimePickerFlyout sender, TimePickedEventArgs args)
        {
            await new MessageDialog(args.NewTime.ToString()).ShowAsync();
        }

        private async void PickerFlyout_Confirmed(PickerFlyout sender, PickerConfirmedEventArgs args)
        {
            await new MessageDialog("你点了确定").ShowAsync();
        }

        private async void ListPickerFlyout_ItemsPicked(ListPickerFlyout sender, ItemsPickedEventArgs args)
        {
            if (sender.SelectedItem != null)
            {
                await new MessageDialog("你选择的是：" + sender.SelectedItem.ToString()).ShowAsync();
            }
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            if (element != null)
            {
                FlyoutBase.ShowAttachedFlyout(element);
            }
        }

        private void ComboBox2_DropDownClosed(object sender, object e)
        {
            if (comboBox2.SelectedItem != null)
            {
                Man man = comboBox2.SelectedItem as Man;
                Info.Text = "name: " + man.Name + " age: " + man.Age;
            }
        }

        private void CommandBar_Opened(object sender, object e)
        {
            info1.Text = "菜单栏打开了";
        }

        private void CommandBar_Closed(object sender, object e)
        {
            info1.Text = "菜单栏关闭了";
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            info1.Text = "单击了菜单栏：" + (sender as AppBarButton).Label;
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            Splitter.IsPaneOpen = (Splitter.IsPaneOpen == true) ? false : true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Splitter.IsPaneOpen = false;
            tb.Text = "你好" + (sender as Button).Content.ToString();
        }
    }

    public class Man
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
