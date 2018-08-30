using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Work_Reminder
{
    public class TimeTracker:INotifyPropertyChanged
    {
        public TimeTracker()
        {
            
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int WorkTimeTillBreak { get; set; }

        private string _currentTime;

        public string CurrentTime { get => _currentTime; set { _currentTime = value; OnPropertyChanged(); } }

        public async Task StartWork(int timeInMinute)
        {
            for(int i=timeInMinute-1;i>=0; i--)
            {
                for(int j=59;j>=0;j--)
                {
                    await Task.Delay(1000);
                    CurrentTime = $"{i}:{j}";
                }
            }
        }

        public void Reset()
        {
            CurrentTime = $"{WorkTimeTillBreak}:00";
        }
    }
}
