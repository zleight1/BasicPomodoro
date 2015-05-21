using System;
using System.Collections.Generic;
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
    class Pomodoro
    {
        private Timer _timer;
        private pomodoroState _state;
        private int _workTime;
        //private int _buzzTime;
        private int _shortBreakTime;
        private int _longBreakTime;

        //The default pomodoro settings
        public Pomodoro()
        {

        }

        //Custom pomodoro settings
        public Pomodoro(int workTime, int shortBreakTime, int longBreakTime)
        {
            //some basic checks
            //are all arguments > 0

            //is break time >  worktime

            //is long break time > short break time

            //okay we're good, make the timer
        }

        //start the timer

        //stop the timer

        //respond to event

        //change state?

        //buzz!
        
    }
}
