using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;

namespace UseMvvm.ViewModel
{
    public partial class MainViewModel : ObservableValidator
    {
        public class MyTabItemModel
        {
            public string Header { get; set; }
            public string Content { get; set; }
            // 你可以添加更多属性来表示TabItem上需要绑定的数据
        }
        [ObservableProperty]
        public string hala = "233";
        [ObservableProperty]
        public ObservableCollection<MyTabItemModel> tabItems = new ObservableCollection<MyTabItemModel>() {
            new MyTabItemModel { Header = "hala1", Content = "Content1" },
            new MyTabItemModel { Header = "hala2", Content = "Content2" },
        };
    }
}
