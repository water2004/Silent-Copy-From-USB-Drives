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
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Textbox1.Text = App.F3T1;
            Textbox2.Text = App.F3T2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Textbox1.Text!=""&&!App.IsNumberic(Textbox1.Text))
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
            App.F3T1 = Textbox1.Text;
            App.F3T2 = Textbox2.Text;
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
    }
}
