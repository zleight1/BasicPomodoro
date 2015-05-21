using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPomodoro.Model
{
    /// <summary>
    /// Simple EventArgs class for the Pomodoro model.
    /// </summary>
    public class PomodoroModelEventArgs : EventArgs
    {
        public enum Status
        {
            NotSpecified,
            Stopped,
            Started,
            Running,
            Completed,
            Reset
        }

        private TimeSpan duration;
        private TimeSpan remaining;
        private Status state = Status.NotSpecified;

        public TimeSpan Duration
        {
            get
            {
                return duration;
            }
            set
            {
                if (duration == value)
                    return;
                duration = value;
            }
        }

        public TimeSpan Remaining
        {
            get
            {
                return remaining;
            }
            set
            {
                if (remaining == value)
                    return;
                remaining = value;
            }
        }

        public Status State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }

        public PomodoroModelEventArgs(TimeSpan duration, TimeSpan remaining, Status state)
        {
            Duration = duration;
            Remaining = remaining;
            State = state;
        }

    }
}
