using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace UseMvvm.ViewModel
{
    public partial class MainViewModel : ObservableValidator
    {
        public MainViewModel()
        {
           
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
    }
}
