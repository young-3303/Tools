using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Tools.Utils;

namespace Tools
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Startup += (object sender, StartupEventArgs e) =>
            {
                // 使线程互斥，只有一个app实例
                mutex = new Mutex(true, "name", out bool createdNew);
                if(!createdNew)
                {
                    // 打开应用如果程序已启动，就激活窗口到最前面
                    Common.ActivationThread();
                    //如果有一样的实例就退出新开的app实例
                    Environment.Exit(0);
                }
            };
        }
        private static Mutex mutex;
    }
}
