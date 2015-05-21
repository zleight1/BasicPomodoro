using WinPomodoro.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;


namespace WinPomodoro.Model
{
    class PomodoroModel : IDisposable
    {
        #region Fields
        /// <summary>
        /// The underlying timer
        /// </summary>
        readonly DispatcherTimer timer = new DispatcherTimer();

        /// <summary>
        /// The current Pomodoro State
        /// </summary>
        private PomodoroState _state;

        /// <summary>
        /// The next Pomodoro State
        /// </summary>
        private PomodoroState _nextState;

        private TimeSpan _workTime; 
        private TimeSpan _shortBreakTime;
        private TimeSpan _longBreakTime;

        private int _shortBreakCount;
        
        #endregion

        //The default pomodoro settings
        public PomodoroModel()
        {
            _workTime = new TimeSpan(0,25,0);
            _shortBreakTime = new TimeSpan(0,5,0);
            _longBreakTime = new TimeSpan(0,15,0);
            resetTimer();
        }

        //Custom pomodoro settings
        public PomodoroModel(int workTime, int shortBreakTime, int longBreakTime)
        {
            //some basic checks
            //are all arguments > 0
            if (workTime > 0)
            {
                _workTime = new TimeSpan(0,workTime,0);
            }
            else
            {
                throw new ArgumentOutOfRangeException("workTime must be greater than 0.");
            }

            if (shortBreakTime > 0)
            {
                _shortBreakTime = new TimeSpan(0,shortBreakTime,0);
            }
            else
            {
                throw new ArgumentOutOfRangeException("shortBreakTime must be greater than 0.");
            }

            if (longBreakTime > 0)
            {
                _longBreakTime = new TimeSpan(0,longBreakTime,0);
            }
            else
            {
                throw new ArgumentOutOfRangeException("longBreakTime must be greater than 0.");
            }
            //is break time >  worktime
            if (longBreakTime > workTime || shortBreakTime > workTime)
            {
                throw new ArgumentException("Break time(s) cannot be longer than work time.");
            }

            //is long break time > short break time
            if (longBreakTime < shortBreakTime)
            {
                throw new ArgumentException("Long break time needs to be greater than short break time.");
            }
            resetTimer();
        }
        
        //Initialize the timer
        private void resetTimer()
        {

            //Log for logging's sake!
            Debug.Print("workTime is : " + _workTime);
            Debug.Print("shortBreakTime is : " + _shortBreakTime);
            Debug.Print("longBreakTime is : " + _longBreakTime);

            //okay we're good, make the timer
            _timer = new TimerPlus();

            //use work time to start since this is state 0
            _timer.Interval = 60000 * _workTime;
            _timer.Elapsed += _timer_Elapsed;

            _state = PomodoroState.Idle;
            _nextState = PomodoroState.Work;
            _shortBreakCount = 0;
        }

        //start the timer
        public void Start()
        {
            _timer.Start();
        }

        //stop the timer
        public void Stop()
        {
            _timer.Stop();

        }

        //respond to event
        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }
        //change state?

        //buzz!

        //Cleanup
        public void Dispose()
        {
            _timer.Dispose();
        }

    }
}
