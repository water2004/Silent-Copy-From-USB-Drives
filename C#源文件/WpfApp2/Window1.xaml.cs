using System;
using System.Collections.Generic;
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
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (T1.Text != "" && !App.IsNumberic(T1.Text))
            {
                MessageBox.Show("输入必须为合法的正整数", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                T1.Focus();
                return;
            }
            if (T2.Text != "" && !App.IsNumberic(T2.Text))
            {
                MessageBox.Show("输入必须为合法正的整数", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                T2.Focus();
                return;
            }
            if (T3.Text != "" && !App.IsNumberic(T3.Text))
            {
                MessageBox.Show("输入必须为合法的正整数", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                T3.Focus();
                return;
            }
            if (T4.Text != "" && !App.IsNumberic(T4.Text))
            {
                MessageBox.Show("输入必须为合法的正整数", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                T4.Focus();
                return;
            }
            App.F2T1 = this.T1.Text;
            App.F2T2 = this.T2.Text;
            App.F2T3 = this.T3.Text;
            App.F2T4 = this.T4.Text;
            if (T5.Text != "")
                App.F2T5 = Convert.ToDateTime(T5.Text).ToString("yyyyMMdd");
            else
            {
                Checkbox1.IsChecked = false;
                App.F2T5 = "";
            }
            if (T6.Text != "")
                App.F2T6 = Convert.ToDateTime(T6.Text).ToString("yyyyMMdd");
            else
            {
                Checkbox2.IsChecked = false;
                App.F2T6 = "";
            }
            App.C5 = (bool)Checkbox1.IsChecked;
            App.C6 = (bool)Checkbox2.IsChecked;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.T1.Text = App.F2T1;
            this.T2.Text = App.F2T2;
            this.T3.Text = App.F2T3;
            this.T4.Text = App.F2T4;
            if (App.F2T5 != "")
                T5.SelectedDate = DateTime.ParseExact(App.F2T5, "yyyyMMdd", null);
            if (App.F2T6 != "")
                T6.SelectedDate = DateTime.ParseExact(App.F2T6, "yyyyMMdd", null);
            Checkbox1.IsChecked = App.C5;
            Checkbox2.IsChecked = App.C6;
            T5.IsEnabled = App.C5;
            T6.IsEnabled = App.C6;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Checkbox1_Checked(object sender, RoutedEventArgs e)
        {
            T5.IsEnabled = true;
        }

        private void Checkbox1_Unchecked(object sender, RoutedEventArgs e)
        {
            T5.IsEnabled = false;
        }

        private void Checkbox2_Checked(object sender, RoutedEventArgs e)
        {
            T6.IsEnabled = true;
        }

        private void Checkbox2_Unchecked(object sender, RoutedEventArgs e)
        {
            T6.IsEnabled = false;
        }

        private void T1_LostFocus(object sender, RoutedEventArgs e)
        {
            T1.Text = T1.Text.Trim();
        }

        private void T2_LostFocus(object sender, RoutedEventArgs e)
        {
            T2.Text = T2.Text.Trim();
        }

        private void T3_LostFocus(object sender, RoutedEventArgs e)
        {
            T3.Text = T3.Text.Trim();
        }

        private void T4_LostFocus(object sender, RoutedEventArgs e)
        {
            T4.Text = T4.Text.Trim();
        }

        private void T1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (T1 != null && L1 != null && T1.Text != "" && App.IsNumberic(T1.Text))
            {
                double MB, KB, GB, TB, PB, EB;
                double.TryParse(T1.Text, out KB);
                KB /= 1024;
                MB = KB / 1024;
                GB = MB / 1024;
                TB = GB / 1024;
                PB = TB / 1024;
                EB = PB / 1024;
                if (KB > 999)
                {
                    if (MB > 999)
                    {
                        if (GB > 999)
                        {
                            if (TB > (999))
                            {
                                if (PB > 999)
                                {
                                    L1.Content = "文件最大限制(约" + EB.ToString("f1") + "EB)";
                                }
                                else
                                {
                                    L1.Content = "文件最大限制(约" + PB.ToString("f1") + "PB)";
                                }
                            }
                            else
                            {
                                L1.Content = "文件最大限制(约" + TB.ToString("f1") + "TB)";
                            }
                        }
                        else
                        {
                            L1.Content = "文件最大限制(约" + GB.ToString("f1") + "GB)";
                        }
                    }
                    else
                    {
                        L1.Content = "文件最大限制(约" + MB.ToString("f1") + "MB)";
                    }
                }
                else
                {
                    L1.Content = "文件最大限制(约" + KB.ToString("f1") + "KB)";
                }
            }
            else if (L1 != null)
            {
                L1.Content = "文件最大限制";
            }
        }

        private void T2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (T2 != null && L2 != null && T2.Text != "" && App.IsNumberic(T2.Text))
            {
                double MB, KB, GB, TB, PB, EB;
                double.TryParse(T2.Text, out KB);
                KB /= 1024;
                MB = KB / 1024;
                GB = MB / 1024;
                TB = GB / 1024;
                PB = TB / 1024;
                EB = PB / 1024;
                if (KB > 999)
                {
                    if (MB > 999)
                    {
                        if (GB > 999)
                        {
                            if (TB > (999))
                            {
                                if (PB > 999)
                                {
                                    L2.Content = "文件最小限制(约" + EB.ToString("f1") + "EB)";
                                }
                                else
                                {
                                    L2.Content = "文件最小限制(约" + PB.ToString("f1") + "PB)";
                                }
                            }
                            else
                            {
                                L2.Content = "文件最小限制(约" + TB.ToString("f1") + "TB)";
                            }
                        }
                        else
                        {
                            L2.Content = "文件最小限制(约" + GB.ToString("f1") + "GB)";
                        }
                    }
                    else
                    {
                        L2.Content = "文件最小限制(约" + MB.ToString("f1") + "MB)";
                    }
                }
                else
                {
                    L2.Content = "文件最小限制(约" + KB.ToString("f1") + "KB)";
                }
            }
            else if (L2 != null)
            {
                L2.Content = "文件最小限制";
            }
        }
    }
}
