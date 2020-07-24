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
    /// Window3.xaml 的交互逻辑
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Textbox1.Text = App.F4T1;
            Textbox2.Text = App.F4T2;
            Textbox3.Text = App.F4T3;
            Textbox4.Text = App.F4T4;
            Textbox5.Text = App.F4T5;
            Textbox6.Text = App.F4T6;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Textbox1.Text != "" && !App.IsNumberic(Textbox1.Text))
            {
                MessageBox.Show("输入必须为合法的正整数", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                Textbox1.Focus();
                return;
            }
            if (Textbox2.Text != "" && !App.IsNumberic(Textbox2.Text))
            {
                MessageBox.Show("输入必须为合法的正整数", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                Textbox2.Focus();
                return;
            }
            if (Textbox3.Text != "" && !App.IsNumberic(Textbox3.Text))
            {
                MessageBox.Show("输入必须为合法的正整数", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                Textbox3.Focus();
                return;
            }
            if (Textbox5.Text != "" && !App.IsNumberic(Textbox5.Text))
            {
                MessageBox.Show("输入必须为合法的正整数", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                Textbox5.Focus();
                return;
            }
            if (Textbox6.Text != "" && !App.IsNumberic(Textbox6.Text))
            {
                MessageBox.Show("输入必须为合法的正整数", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                Textbox6.Focus();
                return;
            }
            App.F4T1 = Textbox1.Text;
            App.F4T2 = Textbox2.Text;
            App.F4T3 = Textbox3.Text;
            App.F4T4 = Textbox4.Text;
            App.F4T5 = Textbox5.Text;
            App.F4T6 = Textbox6.Text;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        private void Textbox4_LostFocus(object sender, RoutedEventArgs e)
        {
            Textbox4.Text = Textbox4.Text.Trim();
        }

        private void Textbox5_LostFocus(object sender, RoutedEventArgs e)
        {
            Textbox5.Text = Textbox5.Text.Trim();
        }

        private void Textbox5_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Textbox6_Loaded(object sender, RoutedEventArgs e)
        {
            Textbox6.Text = Textbox6.Text.Trim();
        }

        private void Textbox6_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
