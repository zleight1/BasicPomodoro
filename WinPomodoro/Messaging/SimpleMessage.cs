namespace WinPomodoro.Messaging
{
    /// <summary>
    /// A simple message class that we use to pass messages around the application
    /// via the Messenger singleton, but keep the parts sufficiently decoupled
    /// for the MVVM style of work.
    /// </summary>
    public class SimpleMessage
    {
        public SimpleMessage() : this(MessageType.SwitchToTimerView)
        {
        }

        public SimpleMessage(MessageType type)
            : this(type, string.Empty)
        {
        }

        public SimpleMessage(MessageType type, string message)
        {
            Type = type;
            Message = message;
        }

        public enum MessageType
        {
            SwitchToTimerView,
            SwitchToSettingsView,
            SwitchToAboutView,
            SettingsChanged,
            TimerStop,
            TimerStart,
            TimerTick,
            TimerReset
        }

        public MessageType Type { get; set; }

        public string Message { get; set; }

    }
}
