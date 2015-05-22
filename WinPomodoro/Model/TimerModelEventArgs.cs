using System;

namespace WinPomodoro.Models
{
    /// <summary>
    /// Simple EventArgs class for the timer model.
    /// </summary>
    public class TimerModelEventArgs : EventArgs
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

        public TimerModelEventArgs(TimeSpan duration, TimeSpan remaining, Status state)
        {
            Duration = duration;
            Remaining = remaining;
            State = state;
        }

    }
}
