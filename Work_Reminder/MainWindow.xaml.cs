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

namespace Work_Reminder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitApp();
        }

        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private bool _isExit;

        private void InitApp()
        {
            _notifyIcon = new System.Windows.Forms.NotifyIcon
            {
                Icon = Properties.Resources._3553339,
                Visible = true
            };
            _notifyIcon.DoubleClick += Notify_ShowClick;

            _notifyIcon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("Show").Click += Notify_ShowClick;
            _notifyIcon.ContextMenuStrip.Items.Add("Exit").Click += Notify_ExitClick;
        }

        private void Notify_ExitClick(object sender, EventArgs e)
        {
            _notifyIcon.Dispose();
            Close();
            Application.Current.Shutdown();
        }

        private void Notify_ShowClick(object sender, EventArgs e)
        {
            ShowInTaskbar = true;
            WindowState = WindowState.Normal;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            WindowState = WindowState.Minimized;
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            var win = (MainWindow)sender;
            if (win.WindowState != WindowState.Normal)
                ShowInTaskbar = false;
        }
    }
}
