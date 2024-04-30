using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UseMvvm.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
           
        }
        [RelayCommand(CanExecute = nameof(CanBtnEnable))]
        private void BtnClick(object flag)
        {
            ScheduleShutdownOrRestart(flag as string);
            hour = null;
        }
        public class MyTabItemModel
        {
            public string Header { get; set; }
            public string Content { get; set; }
            // 你可以添加更多属性来表示TabItem上需要绑定的数据
        }
        [ObservableProperty]
        public string hala = "233";
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
                Regex regex = new Regex("[^0-9]+");
                value = regex.IsMatch(value) ? null : value;
                SetProperty(ref hour, value);
            }   
            
        }
        private void ScheduleShutdownOrRestart(string flag)
        {
            int seconds = 0;
            seconds = int.Parse(hour) * 3600; // 将小时转换为秒
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
            return hour is not null;
        }
    }
}
