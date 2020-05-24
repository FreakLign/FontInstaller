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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;

namespace OneKeyInput
{

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        const int WM_SYSCOMMAND = 0x0112;
        const int SC_MOVE = 0xF010;
        const int HTCAPTION = 0x0002;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IntPtr hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            ReleaseCapture();
            SendMessage(hwnd, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PathField.Text = FileMove.ReadAllFontsFile();
            if(PathField.Text.Length > 0)
            {
                NextBtn.IsEnabled = true;
                this.Dispatcher.Invoke(() =>
                {
                    int Count = FileMove.CheckDirectories(PathField.Text);
                    var MessageQueue = SnackbarThree.MessageQueue;
                    Task.Factory.StartNew(() => MessageQueue.Enqueue("该目录一共有" + Count + "个字体文件"));
                });
            }
            else
            {
                NextBtn.IsEnabled = false;
            }
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                int Count = FileMove.MoveFile(PathField.Text);
                var MessageQueue = SnackbarThree.MessageQueue;
                Task.Factory.StartNew(() => MessageQueue.Enqueue("一共安装" + Count + "个字体文件"));
            });
        }
    }
}
