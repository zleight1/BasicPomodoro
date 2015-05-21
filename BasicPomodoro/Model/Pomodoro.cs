using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BasicPomodoro
{
    enum pomodoroState {
        idle = 0,
        work = 1,
        buzzing = 2,
        shortBreak = 3,
        longBreak = 4
    }
    class Pomodoro : IDisposable
    {
        private Timer _timer;
        private pomodoroState _state;
        private int _workTime; //minutes
        //private int _buzzTime;
        private int _shortBreakTime; //minutes
        private int _longBreakTime; //minutes

        //The default pomodoro settings
        public Pomodoro()
        {
            _workTime = 25;
            _shortBreakTime = 5;
            _longBreakTime = 15;
            initializeTimer();
        }

        //Custom pomodoro settings
        public Pomodoro(int workTime, int shortBreakTime, int longBreakTime)
        {
            //some basic checks
            //are all arguments > 0
            if (workTime > 0)
            {
                _workTime = workTime;
            }
            else
            {
                throw new ArgumentOutOfRangeException("workTime must be greater than 0.");
            }

            if (shortBreakTime > 0)
            {
                _shortBreakTime = shortBreakTime;
            }
            else
            {
                throw new ArgumentOutOfRangeException("shortBreakTime must be greater than 0.");
            }

            if (longBreakTime > 0)
            {
                _longBreakTime = longBreakTime;
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
            initializeTimer();
        }

        public readonly Timer Timer() {
            return _timer;
        }

        //Initialize the timer
        private void initializeTimer()
        {

            //Log for logging's sake!
            Debug.Print("workTime is : " + _workTime);
            Debug.Print("shortBreakTime is : " + _shortBreakTime);
            Debug.Print("longBreakTime is : " + _longBreakTime);

            //okay we're good, make the timer
            _timer = new Timer();

            //use work time to start since this is state 0
            _timer.Interval = 60000 * _workTime;
            _timer.Elapsed += _timer_Elapsed;
        }

        //start the timer
        public void startTimer()
        {

            throw new NotImplementedException();
        }

        //stop the timer
        public void stopTimer()
        {

            throw new NotImplementedException();
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
