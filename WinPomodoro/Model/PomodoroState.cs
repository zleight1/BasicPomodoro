using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPomodoro.Model
{
    public enum PomodoroState
    {
        Idle = 0,
        Work = 1,
        Buzzing = 2,
        ShortBreak = 3,
        LongBreak = 4,
        Completed = 5
    }
}
