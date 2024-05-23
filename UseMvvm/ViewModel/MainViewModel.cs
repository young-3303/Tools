using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Helper;

namespace UseMvvm.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            
        }
        [RelayCommand]
        private void Terminate(string flag)
        {
            ScheduleShutdownOrRestart(flag);
        }
        [RelayCommand]
        //[RelayCommand(CanExecute = nameof(CanBtnEnable))]
        private void BtnClick(object flag)
        {
            Regex regex = new Regex("[^0-9]+");
            Console.WriteLine(CanBtnEnable());
            //Console.WriteLine(regex.IsMatch(Hour));
            //value = regex.IsMatch(value) ? null : value;
            if (CanBtnEnable())
            {
                MsgBoxHelper.Warning("请输入大于零的整数");
            }
            else if(regex.IsMatch(Hour))
            {
                MsgBoxHelper.Warning("请输入大于零的整数");
            }
            else
            {
                ScheduleShutdownOrRestart(flag as string);
                Hour = null;
            }
        }
        public class MyTabItemModel
        {
            public string Header { get; set; }
            public string Content { get; set; }
            // 你可以添加更多属性来表示TabItem上需要绑定的数据
        }
        [ObservableProperty]
        public List<MyTabItemModel> tabItems = new List<MyTabItemModel>() {
            new MyTabItemModel { Header = "hala1", Content = "Content1" },
            new MyTabItemModel { Header = "hala2", Content = "Content2" },
        };
        [ObservableProperty]
        private ObservableCollection<NavigationItemViewModel> navigationItems = new()
        {
            new NavigationItemViewModel {
                Name = "home",
                Content = new TextBox { Width=100, Height = 50}
            },
            new NavigationItemViewModel {
                Name = "setting",
                Content= new TextBox { Width=100, Height = 50}
            }
        };
        private string hour = null;
        public string Hour { 
            get => hour;
            set {
                SetProperty(ref hour, value);
                //BtnClickCommand.NotifyCanExecuteChanged();
            }   
            
        }
        private void ScheduleShutdownOrRestart(string flag)
        {
            int seconds = 0;
            if(!string.IsNullOrWhiteSpace(hour)) seconds = int.Parse(hour) * 3600; // 将小时转换为秒
            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "shutdown";
                    //process.StartInfo.Arguments = flag == "shutDown" ? $"/s /t {seconds}" ? flag == "restart" ? $"/r /t {seconds}" : $"/s /t {seconds}"；
                    switch(flag)
                    {
                        case "shutdown":
                            process.StartInfo.Arguments = $"/s /t {seconds}";
                            break;
                        case "restart":
                            process.StartInfo.Arguments = $"/r /t {seconds}";
                            break;
                        default:
                            process.StartInfo.Arguments = $"/a";
                            break;
                    }
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;
                    process.Start();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("错误: " + ex.Message);
            }
        }
        private bool CanBtnEnable()
        {
            return string.IsNullOrWhiteSpace(Hour);
        }
        public class PropertyGridDemoModel
        {
            [Category("系统信息")]
            public string 操作系统 { get; set; }
            [Category("系统信息")]
            public string String { get; set; }
        }
        [ObservableProperty]
        private PropertyGridDemoModel demoModel = new PropertyGridDemoModel
        {
            //String = "TestString",
        };
    }
}
