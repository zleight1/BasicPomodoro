using System;

namespace WinPomodoro.Models
{
    internal interface ISettingsModel
    {
        /// <summary>
        /// Get/set whether to highlight the clock using built-in colours.
        /// </summary>
        bool Colours { get; set; }
        /// <summary>
        /// Returns whether this is the first ever run of the application.
        /// </summary>
        bool FirstRun { get; set; }
        /// <summary>
        /// The font-family of the clock
        /// </summary>
        System.Windows.Media.FontFamily FontFamily { get; set; }
        /// <summary>
        /// Returns whether the settings have been modified in some way.
        /// </summary>
        bool Modified { get; }
        /// <summary>
        /// The (last) selected duration of our timer.
        /// </summary>
        TimeSpan Duration { get; set; }
        /// <summary>
        /// Play the system beep on start
        /// </summary>
        bool PlayBeep { get; set; }
        /// <summary>
        /// Play the system exclamation on stop
        /// </summary>
        bool PlayExclamation { get; set; }
        /// <summary>
        /// is the window top-most?
        /// </summary>
        bool TopMost { get; set; }
        /// <summary>
        /// the font size of the clock
        /// </summary>
        double FontSize { get; set; }
        /// <summary>
        /// Reload the settings from the application properties if necessary.
        /// </summary>
        void Reload();
        /// <summary>
        /// Save the settings if they have been modified, otherwise do nothing.
        /// </summary>
        void Save();
    }
}
