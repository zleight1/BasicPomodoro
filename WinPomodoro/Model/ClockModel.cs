using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinPomodoro.Model
{
    public class ClockModel
    {
        private const int TIMER_INTERVAL = 50;

        private DateTime _time;

        public event Action<DateTime> TimeArrived;

        public ClockModel()
        {
            Thread thread = new Thread(new ThreadStart(GenerateTimes));
            thread.IsBackground = true;
            thread.Priority = ThreadPriority.Normal;
            thread.Start();
        }

        public DateTime DateTime
        {
            get
            {
                return _time;
            }
            set
            {
                this._time = value;
                if (TimeArrived != null)
                {
                    TimeArrived(DateTime);
                }
            }
        }

        private void GenerateTimes()
        {
            while (true)
            {
                DateTime = DateTime.Now;
                Thread.Sleep(TIMER_INTERVAL);
            }
        }
    }
}
