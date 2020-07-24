using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Interop;

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Window1 W1;
        Window2 W2;
        Window3 W3;
        Window4 W4;
        private const uint WS_EX_CONTEXTHELP = 0x00000400;
        private const uint WS_MINIMIZEBOX = 0x00020000;
        private const uint WS_MAXIMIZEBOX = 0x00010000;
        private const int GWL_STYLE = -16;
        private const int GWL_EXSTYLE = -20;
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_FRAMECHANGED = 0x0020;
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_CONTEXTHELP = 0xF180;


        [DllImport("user32.dll")]
        private static extern uint GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hwnd, int index, uint newStyle);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter, int x, int y, int width, int height, uint flags);


        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            IntPtr hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            uint styles = GetWindowLong(hwnd, GWL_STYLE);
            styles &= 0xFFFFFFFF ^ (WS_MINIMIZEBOX | WS_MAXIMIZEBOX);
            SetWindowLong(hwnd, GWL_STYLE, styles);
            styles = GetWindowLong(hwnd, GWL_EXSTYLE);
            styles |= WS_EX_CONTEXTHELP;
            SetWindowLong(hwnd, GWL_EXSTYLE, styles);
            SetWindowPos(hwnd, IntPtr.Zero, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER | SWP_FRAMECHANGED);
            ((HwndSource)PresentationSource.FromVisual(this)).AddHook(HelpHook);
        }

        private IntPtr HelpHook(IntPtr hwnd,
                int msg,
                IntPtr wParam,
                IntPtr lParam,
                ref bool handled)
        {
            if (msg == WM_SYSCOMMAND &&
                    ((int)wParam & 0xFFF0) == SC_CONTEXTHELP)
            {
                if (W4 == null || !W4.IsLoaded)
                {
                    W4 = new Window4();
                    W4.Show();
                }
                else
                    W4.Activate();
                handled = true;
            }
            return IntPtr.Zero;
        }
        //调用exe
        [DllImport("kernel32.dll")]
        public static extern int WinExec(string exeName, int operType);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (W1 == null || !W1.IsLoaded)
            {
                W1 = new Window1();
                W1.Show();
            }
            else
                W1.Activate();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("setting.txt", FileMode.Open, FileAccess.Read);
            StreamReader RT = new StreamReader(fs);
            RT.BaseStream.Seek(0, SeekOrigin.Begin);
            App.F1T1 = RT.ReadLine();
            App.F1T2_1 = RT.ReadLine();
            App.F1T2_2 = RT.ReadLine();
            App.F1T3 = RT.ReadLine();
            App.F2T1 = RT.ReadLine();
            App.F2T2 = RT.ReadLine();
            App.F2T3 = RT.ReadLine();
            App.F2T4 = RT.ReadLine();
            App.F2T5 = RT.ReadLine();
            App.F2T6 = RT.ReadLine();
            App.F3T1 = RT.ReadLine();
            App.F3T2 = RT.ReadLine();
            App.F4T1 = RT.ReadLine();
            App.F4T2 = RT.ReadLine();
            App.F4T3 = RT.ReadLine();
            App.F4T4 = RT.ReadLine();
            App.F4T5 = RT.ReadLine();
            App.F4T6 = RT.ReadLine();
            if (RT.ReadLine() == "1") App.C1 = true;
            else App.C1 = false;
            if (RT.ReadLine() == "1") App.C2 = true;
            else App.C2 = false;
            if (RT.ReadLine() == "1") App.C3 = true;
            else App.C3 = false;
            if (RT.ReadLine() == "1") App.C4 = true;
            else App.C4 = false;
            if (RT.ReadLine() == "1") App.C5 = true;
            else App.C5 = false;
            if (RT.ReadLine() == "1") App.C6 = true;
            else App.C6 = false;
            if (RT.ReadLine() == "1") App.C7 = true;
            else App.C7 = false;
            if (RT.ReadLine() == "1") App.C8 = true;
            else App.C8 = false;
            RT.Close();
            Textbox1.Text = App.F1T1;
            Textbox2.Text = App.C8 ? App.F1T2_2 : App.F1T2_1;
            Textbox3.Text = App.F1T3;
            CheckBox1.IsChecked = App.C1;
            CheckBox2.IsChecked = App.C2;
            CheckBox3.IsChecked = App.C3;
            CheckBox4.IsChecked = App.C4;
            CheckBox5.IsChecked = App.C7;
            Textbox1.IsEnabled = !App.C1;
            Textbox2.IsEnabled = !App.C2;
            Textbox3.IsEnabled = !App.C3;
            B1.IsEnabled = App.C4;
            B2.IsEnabled = App.C4;
            B3.IsEnabled = App.C4;
            if (App.C8)
            {
                R1.IsChecked = false;
                R2.IsChecked = true;
            }
            else
            {
                R2.IsChecked = false;
                R1.IsChecked = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (W2 == null || !W2.IsLoaded)
            {
                W2 = new Window2();
                W2.Show();
            }
            else
                W2.Activate();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (W3 == null || !W3.IsLoaded)
            {
                W3 = new Window3();
                W3.Show();
            }
            else
                W3.Activate();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Button2.IsEnabled = false;
            if ((bool)R2.IsChecked && Textbox2.Text == "")
            {
                System.Windows.MessageBox.Show("磁盘名称不能为空", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                Textbox2.Focus();
                Button2.IsEnabled = true;
                return;
            }
            File.WriteAllText("setup.txt", String.Empty);
            File.WriteAllText("setting.txt", String.Empty);
            App.C1 = (bool)CheckBox1.IsChecked;
            App.C2 = (bool)CheckBox2.IsChecked;
            App.C3 = (bool)CheckBox3.IsChecked;
            App.C4 = (bool)CheckBox4.IsChecked;
            App.F1T1 = Textbox1.Text;
            if (App.C8)
                App.F1T2_2 = Textbox2.Text;
            else App.F1T2_1 = Textbox2.Text;
            App.F1T3 = Textbox3.Text;
            FileStream fs = new FileStream("setting.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter WT = new StreamWriter(fs);
            WT.Flush();
            //设置当前流的位置
            WT.BaseStream.Seek(0, SeekOrigin.Begin);
            //写入内容
            WT.WriteLine(App.F1T1);
            WT.WriteLine(App.F1T2_1);
            WT.WriteLine(App.F1T2_2);
            WT.WriteLine(App.F1T3);
            WT.WriteLine(App.F2T1);
            WT.WriteLine(App.F2T2);
            WT.WriteLine(App.F2T3);
            WT.WriteLine(App.F2T4);
            WT.WriteLine(App.F2T5);
            WT.WriteLine(App.F2T6);
            WT.WriteLine(App.F3T1);
            WT.WriteLine(App.F3T2);
            WT.WriteLine(App.F4T1);
            WT.WriteLine(App.F4T2);
            WT.WriteLine(App.F4T3);
            WT.WriteLine(App.F4T4);
            WT.WriteLine(App.F4T5);
            WT.WriteLine(App.F4T6);
            if (App.C1) WT.WriteLine("1");
            else WT.WriteLine("0");
            if (App.C2) WT.WriteLine("1");
            else WT.WriteLine("0");
            if (App.C3) WT.WriteLine("1");
            else WT.WriteLine("0");
            if (App.C4) WT.WriteLine("1");
            else WT.WriteLine("0");
            if (App.C5) WT.WriteLine("1");
            else WT.WriteLine("0");
            if (App.C6) WT.WriteLine("1");
            else WT.WriteLine("0");
            if (App.C7) WT.WriteLine("1");
            else WT.WriteLine("0");
            if (App.C8) WT.WriteLine("1");
            else WT.WriteLine("0");
            //关闭此文件
            WT.Flush();
            WT.Close();
            fs = new FileStream("setup.txt", FileMode.OpenOrCreate, FileAccess.Write);
            WT = new StreamWriter(fs, Encoding.GetEncoding("gb2312"));
            WT.Flush();
            //设置当前流的位置
            WT.BaseStream.Seek(0, SeekOrigin.Begin);
            WT.WriteLine("文件源模式(0:盘符，1:磁盘名称)");
            WT.WriteLine(App.C8 ? 1 : 0);
            WT.WriteLine("文件源");
            if (App.C2 && CheckBox2.IsEnabled)
                WT.WriteLine("");
            else
                WT.WriteLine(App.C8 ? App.F1T2_2 : App.F1T2_1);
            WT.WriteLine("文件名");
            if (!App.C3)
                WT.WriteLine(App.F1T3);
            else
                WT.WriteLine("");
            WT.WriteLine("目标目录");
            if (!App.C1)
                WT.WriteLine(App.F1T1);
            else
                WT.WriteLine("");
            if (App.C4)
            {
                WT.WriteLine("文件最大限制");
                WT.WriteLine(App.F2T1);
                WT.WriteLine("文件最小限制");
                WT.WriteLine(App.F2T2);
                WT.WriteLine("最长的文件存在时间");
                WT.WriteLine(App.F2T3);
                WT.WriteLine("最短的文件存在时间");
                WT.WriteLine(App.F2T4);
                WT.WriteLine("最大的最后访问日期");
                if (App.C5)
                    WT.WriteLine(App.F2T5);
                else
                    WT.WriteLine("");
                WT.WriteLine("最小的最后访问日期");
                if (App.C6)
                    WT.WriteLine(App.F2T6);
                else
                    WT.WriteLine("");
                WT.WriteLine("失败副本的重试次数");
                WT.WriteLine(App.F3T1);
                WT.WriteLine("两次重试间的等待时间");
                WT.WriteLine(App.F3T2);
                WT.WriteLine("仅复制源目录树的前 n 层");
                WT.WriteLine(App.F4T1);
                WT.WriteLine("使用 n 个线程进行多线程复制");
                WT.WriteLine(App.F4T2);
                WT.WriteLine("日志文件");
                WT.WriteLine(App.F4T4);
                WT.WriteLine("等待时间");
                WT.WriteLine(App.F4T5);
                WT.WriteLine("程序包间的距离");
                WT.WriteLine(App.F4T3);
            }
            else
            {
                WT.WriteLine("文件最大限制");
                WT.WriteLine("");
                WT.WriteLine("文件最小限制");
                WT.WriteLine("");
                WT.WriteLine("最长的文件存在时间");
                WT.WriteLine("");
                WT.WriteLine("最短的文件存在时间");
                WT.WriteLine("");
                WT.WriteLine("最大的最后访问日期");
                WT.WriteLine("");
                WT.WriteLine("最小的最后访问日期");
                WT.WriteLine("");
                WT.WriteLine("失败副本的重试次数");
                WT.WriteLine("0");
                WT.WriteLine("两次重试间的等待时间");
                WT.WriteLine("0");
                WT.WriteLine("仅复制源目录树的前 n 层");
                WT.WriteLine("");
                WT.WriteLine("使用 n 个线程进行多线程复制");
                WT.WriteLine("");
                WT.WriteLine("日志文件");
                WT.WriteLine("log.txt");
                WT.WriteLine("等待时间");
                WT.WriteLine("");
                WT.WriteLine("程序包间的距离");
                WT.WriteLine("");
            }
            WT.WriteLine("是否新建文件夹");
            WT.WriteLine(App.C7 ? 1 : 0);
            WT.WriteLine("检测到磁盘插入后延迟复制的时间（s）");
            if (App.C4) WT.WriteLine(App.F4T6);
            else WT.WriteLine("");
            WT.Flush();
            WT.Close();
            WinExec("copy.exe", 0);
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Button1.IsEnabled = false;
            if ((bool)R2.IsChecked && Textbox2.Text == "")
            {
                System.Windows.MessageBox.Show("磁盘名称不能为空", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                Textbox2.Focus();
                Button1.IsEnabled = true;
                return;
            }
            File.WriteAllText("setup.txt", String.Empty);
            File.WriteAllText("setting.txt", String.Empty);
            App.C1 = (bool)CheckBox1.IsChecked;
            App.C2 = (bool)CheckBox2.IsChecked;
            App.C3 = (bool)CheckBox3.IsChecked;
            App.C4 = (bool)CheckBox4.IsChecked;
            App.F1T1 = Textbox1.Text;
            if (App.C8)
                App.F1T2_2 = Textbox2.Text;
            else App.F1T2_1 = Textbox2.Text;
            App.F1T3 = Textbox3.Text;
            FileStream fs = new FileStream("setting.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter WT = new StreamWriter(fs);
            WT.Flush();
            //设置当前流的位置
            WT.BaseStream.Seek(0, SeekOrigin.Begin);
            //写入内容
            WT.WriteLine(App.F1T1);
            WT.WriteLine(App.F1T2_1);
            WT.WriteLine(App.F1T2_2);
            WT.WriteLine(App.F1T3);
            WT.WriteLine(App.F2T1);
            WT.WriteLine(App.F2T2);
            WT.WriteLine(App.F2T3);
            WT.WriteLine(App.F2T4);
            WT.WriteLine(App.F2T5);
            WT.WriteLine(App.F2T6);
            WT.WriteLine(App.F3T1);
            WT.WriteLine(App.F3T2);
            WT.WriteLine(App.F4T1);
            WT.WriteLine(App.F4T2);
            WT.WriteLine(App.F4T3);
            WT.WriteLine(App.F4T4);
            WT.WriteLine(App.F4T5);
            WT.WriteLine(App.F4T6);
            if (App.C1) WT.WriteLine("1");
            else WT.WriteLine("0");
            if (App.C2) WT.WriteLine("1");
            else WT.WriteLine("0");
            if (App.C3) WT.WriteLine("1");
            else WT.WriteLine("0");
            if (App.C4) WT.WriteLine("1");
            else WT.WriteLine("0");
            if (App.C5) WT.WriteLine("1");
            else WT.WriteLine("0");
            if (App.C6) WT.WriteLine("1");
            else WT.WriteLine("0");
            if (App.C7) WT.WriteLine("1");
            else WT.WriteLine("0");
            if (App.C8) WT.WriteLine("1");
            else WT.WriteLine("0");
            //关闭此文件
            WT.Flush();
            WT.Close();
            fs = new FileStream("setup.txt", FileMode.OpenOrCreate, FileAccess.Write);
            WT = new StreamWriter(fs, Encoding.GetEncoding("gb2312"));
            WT.Flush();
            //设置当前流的位置
            WT.BaseStream.Seek(0, SeekOrigin.Begin);
            WT.WriteLine("文件源模式(0:盘符，1:磁盘名称)");
            WT.WriteLine(App.C8 ? 1 : 0);
            WT.WriteLine("文件源");
            if (App.C2 && CheckBox2.IsEnabled)
                WT.WriteLine("");
            else
                WT.WriteLine(App.C8 ? App.F1T2_2 : App.F1T2_1);
            WT.WriteLine("文件名");
            if (!App.C3)
                WT.WriteLine(App.F1T3);
            else
                WT.WriteLine("");
            WT.WriteLine("目标目录");
            if (!App.C1)
                WT.WriteLine(App.F1T1);
            else
                WT.WriteLine("");
            if (App.C4)
            {
                WT.WriteLine("文件最大限制");
                WT.WriteLine(App.F2T1);
                WT.WriteLine("文件最小限制");
                WT.WriteLine(App.F2T2);
                WT.WriteLine("最长的文件存在时间");
                WT.WriteLine(App.F2T3);
                WT.WriteLine("最短的文件存在时间");
                WT.WriteLine(App.F2T4);
                WT.WriteLine("最大的最后访问日期");
                if (App.C5)
                    WT.WriteLine(App.F2T5);
                else
                    WT.WriteLine("");
                WT.WriteLine("最小的最后访问日期");
                if (App.C6)
                    WT.WriteLine(App.F2T6);
                else
                    WT.WriteLine("");
                WT.WriteLine("失败副本的重试次数");
                WT.WriteLine(App.F3T1);
                WT.WriteLine("两次重试间的等待时间");
                WT.WriteLine(App.F3T2);
                WT.WriteLine("仅复制源目录树的前 n 层");
                WT.WriteLine(App.F4T1);
                WT.WriteLine("使用 n 个线程进行多线程复制");
                WT.WriteLine(App.F4T2);
                WT.WriteLine("日志文件");
                WT.WriteLine(App.F4T4);
                WT.WriteLine("等待时间");
                WT.WriteLine(App.F4T5);
                WT.WriteLine("程序包间的距离");
                WT.WriteLine(App.F4T3);
            }
            else
            {
                WT.WriteLine("文件最大限制");
                WT.WriteLine("");
                WT.WriteLine("文件最小限制");
                WT.WriteLine("");
                WT.WriteLine("最长的文件存在时间");
                WT.WriteLine("");
                WT.WriteLine("最短的文件存在时间");
                WT.WriteLine("");
                WT.WriteLine("最大的最后访问日期");
                WT.WriteLine("");
                WT.WriteLine("最小的最后访问日期");
                WT.WriteLine("");
                WT.WriteLine("失败副本的重试次数");
                WT.WriteLine("0");
                WT.WriteLine("两次重试间的等待时间");
                WT.WriteLine("0");
                WT.WriteLine("仅复制源目录树的前 n 层");
                WT.WriteLine("");
                WT.WriteLine("使用 n 个线程进行多线程复制");
                WT.WriteLine("");
                WT.WriteLine("日志文件");
                WT.WriteLine("log.txt");
                WT.WriteLine("等待时间");
                WT.WriteLine("");
                WT.WriteLine("程序包间的距离");
                WT.WriteLine("");
            }
            WT.WriteLine("是否新建文件夹");
            WT.WriteLine(App.C7 ? 1 : 0);
            WT.WriteLine("检测到磁盘插入后延迟复制的时间（s）");
            if (App.C4) WT.WriteLine(App.F4T6);
            else WT.WriteLine("");
            WT.Flush();
            WT.Close();
            Button1.IsEnabled = true;
        }

        private void CheckBox1_Checked(object sender, RoutedEventArgs e)
        {
            Textbox1.IsEnabled = false;
            B5.IsEnabled = false;
        }

        private void CheckBox2_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)R2.IsChecked)
            {
                CheckBox2.IsChecked = false;
                return;
            }
            Textbox2.IsEnabled = false;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Textbox3.IsEnabled = false;
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            B1.IsEnabled = true;
            B2.IsEnabled = true;
            B3.IsEnabled = true;
            if (W1 != null)
                W1.IsEnabled = true;
            if (W2 != null)
                W2.IsEnabled = true;
            if (W3 != null)
                W3.IsEnabled = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            B1.IsEnabled = false;
            B2.IsEnabled = false;
            B3.IsEnabled = false;
            if (W1 != null)
                W1.IsEnabled = false;
            if (W2 != null)
                W2.IsEnabled = false;
            if (W3 != null)
                W3.IsEnabled = false;
        }

        private void CheckBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            Textbox1.IsEnabled = true;
            B5.IsEnabled = true;
        }

        private void CheckBox2_Unchecked(object sender, RoutedEventArgs e)
        {
            Textbox2.IsEnabled = true;
        }

        private void CheckBox3_Unchecked(object sender, RoutedEventArgs e)
        {
            Textbox3.IsEnabled = true;
        }

        private void Textbox1_LostFocus(object sender, RoutedEventArgs e)
        {
            Textbox1.Text = Textbox1.Text.Trim();
        }

        private void Textbox2_LostFocus(object sender, RoutedEventArgs e)
        {
            Textbox2.Text = Textbox2.Text.Trim();
        }

        private void Textbox3_LostFocus(object sender, RoutedEventArgs e)
        {
            Textbox3.Text = Textbox3.Text.Trim();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog m_Dialog = new FolderBrowserDialog
            {
                Description = "选择保存位置"
            };
            DialogResult result = m_Dialog.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.Cancel)
            {
                this.Textbox1.Text = m_Dialog.SelectedPath.Trim();
            }
            m_Dialog.Dispose();
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("setting.txt", FileMode.Open, FileAccess.Read);
            StreamReader RT = new StreamReader(fs);
            RT.BaseStream.Seek(0, SeekOrigin.Begin);
            App.F1T1 = RT.ReadLine();
            App.F1T2_1 = RT.ReadLine();
            App.F1T2_2 = RT.ReadLine();
            App.F1T3 = RT.ReadLine();
            App.F2T1 = RT.ReadLine();
            App.F2T2 = RT.ReadLine();
            App.F2T3 = RT.ReadLine();
            App.F2T4 = RT.ReadLine();
            App.F2T5 = RT.ReadLine();
            App.F2T6 = RT.ReadLine();
            App.F3T1 = RT.ReadLine();
            App.F3T2 = RT.ReadLine();
            App.F4T1 = RT.ReadLine();
            App.F4T2 = RT.ReadLine();
            App.F4T3 = RT.ReadLine();
            App.F4T4 = RT.ReadLine();
            App.F4T5 = RT.ReadLine();
            App.F4T6 = RT.ReadLine();
            if (RT.ReadLine() == "1") App.C1 = true;
            else App.C1 = false;
            if (RT.ReadLine() == "1") App.C2 = true;
            else App.C2 = false;
            if (RT.ReadLine() == "1") App.C3 = true;
            else App.C3 = false;
            if (RT.ReadLine() == "1") App.C4 = true;
            else App.C4 = false;
            if (RT.ReadLine() == "1") App.C5 = true;
            else App.C5 = false;
            if (RT.ReadLine() == "1") App.C6 = true;
            else App.C6 = false;
            if (RT.ReadLine() == "1") App.C7 = true;
            else App.C7 = false;
            if (RT.ReadLine() == "1") App.C8 = true;
            else App.C8 = false;
            RT.Close();
            Textbox1.Text = App.F1T1;
            Textbox2.Text = App.C8 ? App.F1T2_2 : App.F1T2_1;
            Textbox3.Text = App.F1T3;
            CheckBox1.IsChecked = App.C1;
            CheckBox2.IsChecked = App.C2;
            CheckBox3.IsChecked = App.C3;
            CheckBox4.IsChecked = App.C4;
            CheckBox5.IsChecked = App.C7;
            Textbox1.IsEnabled = !App.C1;
            Textbox2.IsEnabled = !App.C2;
            Textbox3.IsEnabled = !App.C3;
            B1.IsEnabled = App.C4;
            B2.IsEnabled = App.C4;
            B3.IsEnabled = App.C4;
            if (App.C8) R2.IsChecked = true;
            else R1.IsChecked = true;
            if (W1 != null) W1.Close();
            if (W2 != null) W2.Close();
            if (W3 != null) W3.Close();
        }

        private void CheckBox5_Checked(object sender, RoutedEventArgs e)
        {
            App.C7 = true;
        }

        private void CheckBox5_Unchecked(object sender, RoutedEventArgs e)
        {
            App.C7 = false;
        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            CheckBox2.IsEnabled = false;
            App.C8 = true;
            Textbox2.Text = App.F1T2_2;
            Textbox2.IsEnabled = true;
        }

        private void R2_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox2.IsEnabled = true;
            App.C8 = false;
            Textbox2.Text = App.F1T2_1;
            if ((bool)CheckBox2.IsChecked) Textbox2.IsEnabled = false;
        }

        private void Textbox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
