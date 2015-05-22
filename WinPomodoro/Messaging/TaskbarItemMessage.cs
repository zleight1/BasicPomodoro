using System.Windows.Shell;

namespace WinPomodoro.Messaging
{
    /// <summary>
    /// Trivial container for a message for the taskbaritem progress info.
    /// </summary>
    public class TaskbarItemMessage
    {
        public TaskbarItemMessage()
        {
            State = TaskbarItemProgressState.None;
            Value = -1.0;
        }
        public TaskbarItemProgressState State { get; set; }

        public double Value { get; set; }

        public bool HasValue { get { return ! (Value < 0.0); } }
    }
}
