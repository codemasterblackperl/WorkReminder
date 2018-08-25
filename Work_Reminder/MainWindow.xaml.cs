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
            _notifyIcon.DoubleClick += _notifyIcon_DoubleClick;
        }

        private void _notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            
        }
    }
}
