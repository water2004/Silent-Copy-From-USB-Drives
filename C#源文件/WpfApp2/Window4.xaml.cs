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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Window4.xaml 的交互逻辑
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            mlbox.Text = "前言：\n   此工具为本蒟蒻为特殊用途（搞笑？好玩？作死？请大神们自行脑补用途(提示：文件名))制作的。\n   此工具经测试可正确运行于Windows10(其他系统本蒟蒻就不知道了(懒得试。。。))。\n   使用C++编写主程序，wpf+C#.net实现图形化（本来用的是winform+VB.net，但嫌它做出来的东西丑...），使用命令行工具“ROBOCOPY”实现相关功能。\n   源代码也一并奉上,欢迎各位大神指导！如有雷同,纯属巧合！\n   最后，因使用此工具造成的损失本蒟蒻概不负责（甩锅）";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            mlbox.Text = "关于：\n\n重要！重要！重要！\n4.7的setting.txt和其他版本的不兼容！！！" +
                "\n\n程序集名称：静默拷文件\n版本：4.7.1\n作者：某不知名蒟蒻\n版权：开源？" +
                "\n\n新版本更新内容:\n微调主程序运行日志" +
                "\n\n使用方法：\n1、运行静默拷文件.exe，完成配置后，点击保存并启动按钮\n  （或者完成并保存配置后运行\"start.vbs\")\n2、u盘插入后，程序自动复制文件\n3、查看复制出来的文件，若有需要，支持查看程序运行日志";
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            mlbox.Text = "高级选项使用说明：" +
                "\n\n文件最大限制：\n即只复制大小不大于此限制的文件" +
                "\n\n文件最小限制：\n即只复制大小不小于此限制的文件" +
                "\n\n最长的文件存在时间：\n如填日期，意为只复制该天及以后复制进u盘的文件\n如填天数，意为只复制存在了不超过此天数的文件" +
                "\n\n最短的文件存在时间：\n如填日期，意为只复制该天及以前复制进u盘的文件\n如填天数，意为只复制存在了超过此天数的文件" +
                "\n\n最大的最后访问日期：\n意为只复制只在该天及以后使用过的文件" +
                "\n\n最小的最后访问日期：\n意为只复制只在该天及以前使用过的文件\n失败副本的重试次数：\n若复制失败，重新尝试复制该文件的次数" +
                "\n\n两次重试间的等待时间：\n若复制失败，过该段时间后再尝试复制该文件" +
                "\n\n仅复制源目录树的前 n 层：\n只复制文件源前n层文件夹中的文件" +
                "\n\n使用 n 个线程进行多线程复制：\nn越大复制速度越高，但可能导致磁盘无响应" +
                "\n\n日志文件：\n程序运行日志" +
                "\n\n等待时间：\n两次检测u盘插入间的等待时间" +
                "\n\n程序包间间隔：\n可以释放低速线路上的带宽，但复制速度会有所降低" +
                "\n\n自动建立文件夹：\n自动在目标目录下新建文件夹并将文件存入其中";
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            mlbox.Text = "更新日志：\n\n1.0 ——2018.11.23\n在指定盘符的U盘插入的瞬间拷贝根目录下指定名称的文件或文件夹到此文件夹" +
                "\n\n2.0——2018.11.24\n可复制u盘里任意文件并保留目录结构\n可指定输出文件夹" +
                "\n\n2.1——2018.11.24\n文件源可以为文件夹目录或盘符\n文件名，文件源，输出目录支持空格" +
                "\n\n3.0——2018.11.25\n新增：\n文件最大限制\n文件最小限制\n最长的文件存在时间 \n最短的文件存在时间 \n最大的最后访问日期 \n最小的最后访问日期 \n失败副本的重试次数\n两次重试间的等待时间\n选项" +
                "\n\n3.1——2018.12.6\n新增\n仅复制源目录树的前 n 层\n多线程复制\n日志文件\n选项" +
                "\n\n3.2——2019.7.10\n解决bitlocker to go磁盘不能成功复制的问题\n增加“等待时间”选项，设置后可降低系统资源消耗" +
                "\n\n3.3——2019.7.11\n文件源处留空可自动检测盘符" +
                "\n\n3.4——2019.7.22\n文目标目录处留空可自动建立文件夹\nbitlocker状态检测可能出现无限循环的问题，输入字符串前后有空格导致检测磁盘插入状态出现无限循环的问题" +
                "\n\n4.0——2019.7.29\n初步实现图形化" +
                "\n\n4.1——2019.7.30\n使用VB.net重写界面，使界面更友好" +
                "\n\n4.2——2019.7.31\n完善界面设计，实现多窗口，便于使用" +
                "\n\n4.3——2019.8.2\n修复由目录中引号导致的复制不成功而死循环的问题\n修复在取消勾选高级选项中的“启用”复选框时已打开的窗口仍可以继续编辑的漏洞\n使得窗口每次出现在屏幕正中央\n新增“数据包间距离”选项，可以解决复制期间u盘带宽占满以致访问无响应的问题" +
                "\n\n4.3.1——2019.8.7\n改善窗口启动动画" +
                "\n\n4.3.2——2019.8.7\n每一次打开都能保持上一次关闭时的状态" +
                "\n\n4.4.0——2019.8.8\n修改状态保存时机，只有在保存配置时保存\n新增还原配置按钮，便于还原配置，不用重启程序\n更换日期输入方式\n进行界面微调，以适应高分屏" +
                "\n\n4.4.1——2019.8.8\n移除了帮助按钮" +
                "\n\n4.5.0——2019.8.9\n改变了自动盘符检测的方式和bitlocker检测的方式\n修复了多线程复制选项可能引起的bug\n输入框自动去除两端空格\n可以判断部分输入数据的合法性" +
                "\n\n4.5.1——2019.8.11\n填补了高级选项的相关漏洞\n\n4.6.0——2019.8.12\n使用wpf+C#.net重写界面，改善兼容性" +
                "\n\n4.6.1——2019.8.12\n修复配置文件出现乱码及格式错位的问题" +
                "\n\n4.6.2——2019.8.13\n减少程序退出时间\n增加文件大小估算\n修复字符串合法性判断出错的问题" +
                "\n\n4.6.3——2019.8.22\n修复了同一个窗口可以打开多次的漏洞" +
                "\n\n4.6.4——2019.8.23\n新增\"关于\"窗口\n修复因日期填写错误导致的程序崩溃的问题" +
                "\n\n4.6.5——2019.8.30\n修复因等待时间填写错误导致的CPU高占用\n更改了错误提示" +
                "\n\n4.6.6——2019.9.7\n修复相关问题" +
                "\n\n4.7.0——2019.11.2\n增加主程序运行日志\n更改自动建立文件夹选项为可选" +
                "\n\n4.7.1——2019.11.3\n微调主程序运行日志" +
                "\n\n敬请期待...\n";
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            mlbox.Clear();
            StreamReader sr = new StreamReader("main_log.txt", Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                mlbox.AppendText("\n" + line);
            }
            sr.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.IO.File.WriteAllText(@"main_log.txt", string.Empty);
            if ((bool)R1.IsChecked) 
            mlbox.Clear();
        }
    }
}
