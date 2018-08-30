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

        private TimeTracker _timeTracker = new TimeTracker();
        private int _breakTimeInMinute;
        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private bool _doNotMinimize;

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

            LblTime.DataContext = _timeTracker;
            _timeTracker.WorkTimeTillBreak = _breakTimeInMinute = 30;
            LblMessage.Visibility = Visibility.Hidden;
        }

        private void ShowMain()
        {
            ShowInTaskbar = true;
            WindowState = WindowState.Normal;
        }


        private void Notify_ExitClick(object sender, EventArgs e)
        {
            _notifyIcon.Dispose();
            Close();
            Application.Current.Shutdown();
        }

        private void Notify_ShowClick(object sender, EventArgs e)
        {
            ShowMain();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            if(!_doNotMinimize)
                WindowState = WindowState.Minimized;
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (_doNotMinimize)
            {
                if (WindowState != WindowState.Normal)
                    WindowState = WindowState.Normal;
                return;
            }

            var win = (MainWindow)sender;
            if (win.WindowState != WindowState.Normal)
                ShowInTaskbar = false;
        }

        private async void BtnStartWork_Click(object sender, RoutedEventArgs e)
        {
            BtnStartWork.IsEnabled = false;
            WindowState = WindowState.Minimized;
            await _timeTracker.StartWork(_breakTimeInMinute);
            ShowMain();
            _doNotMinimize = true;
            LblTime.Visibility = Visibility.Hidden;
            LblMessage.Visibility = Visibility.Visible;
            await Task.Delay(5*60* 1000);
            _doNotMinimize = false;
            _timeTracker.Reset();
            LblTime.Visibility = Visibility.Visible;
            LblMessage.Visibility = Visibility.Hidden;
            BtnStartWork.IsEnabled = true;
        }


    }
}
