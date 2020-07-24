using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static bool IsNumberic(string oText)
        {
            try
            {
                ulong var1 = ulong.Parse(oText);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string F1T1, F1T2_1, F1T2_2, F1T3;
        public static string F2T1, F2T2, F2T3, F2T4, F2T5, F2T6;
        public static string F3T1, F3T2;
        public static string F4T1, F4T2, F4T3, F4T4, F4T5, F4T6;
        public static bool C1, C2, C3, C4, C5, C6, C7, C8;
    }
}
