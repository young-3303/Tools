using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Utils
{
    internal class Common
    {
        /// <summary>
        /// win32 api窗口最小化还原正常状态
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="cmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int cmdShow);
        /// <summary>
        /// win32 api 将窗口置于前台
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        /// <summary>
        /// 激活线程
        /// </summary>
        public static void ActivationThread()
        {
            Process mainProces= Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(mainProces.ProcessName);
            const int SW_RESTORE = 9;
            foreach (var process in processes)
            {
                if(process.Id != mainProces.Id)
                {
                    ShowWindow(process.MainWindowHandle, SW_RESTORE);
                    SetForegroundWindow(process.MainWindowHandle);
                    break;
                }
            }
        }
    }
}
