using WinPomodoro.Models;

namespace WinPomodoro.Builders
{
    public class TimerModelBuilder
    {
        /// <summary>
        /// Get a new instance of a TimerModel
        /// </summary>
        /// <returns></returns>
        public static ITimerModel GetNewTimer()
        {
            return new TimerModel();
        }
    }
}
