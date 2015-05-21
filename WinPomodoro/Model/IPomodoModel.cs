using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPomodoro.Model
{
    public interface IPomodoModel
    {
        /// <summary>
        /// Return the timer interval that we're using.
        /// </summary>
        TimeSpan Interval { get; }

        /// <summary>
        /// Return the time remaining.
        /// </summary>
        TimeSpan Remaining { get; }

        /// <summary>
        /// Has the time completed?
        /// </summary>
        bool Complete { get; }

        /// <summary>
        /// Set or get the duration.
        /// </summary>
        TimeSpan Duration { get; set; }


        /// <summary>
        /// The state of the model
        /// </summary>
        PomodoroState Status { get; set; }

        /// <summary>
        /// Start the countdown.
        /// </summary>
        void Start();

        /// <summary>
        /// Stop the countdown.
        /// </summary>
        void Stop();

        /// <summary>
        /// Stop the current countdown and reset.
        /// </summary>
        void Reset();

        /// <summary>
        /// Tick event
        /// </summary>
        event EventHandler<PomodoroModelEventArgs> Tick;

        /// <summary>
        /// Timer started event
        /// </summary>
        event EventHandler<PomodoroModelEventArgs> Started;

        /// <summary>
        /// Timer stopped event
        /// </summary>
        event EventHandler<PomodoroModelEventArgs> Stopped;

        /// <summary>
        /// Timer reset event
        /// </summary>
        event EventHandler<PomodoroModelEventArgs> TimerReset;

        /// <summary>
        /// Timer completed event
        /// </summary>
        event EventHandler<PomodoroModelEventArgs> Completed;
    }
}
