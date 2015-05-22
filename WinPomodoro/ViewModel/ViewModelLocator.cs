using System;


namespace WinPomodoro.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.  ViewModels 
    /// are only created when first called.
    /// </summary>
    public class ViewModelLocator
    {
        private static MainViewModel _main;
        private static TimerViewModel _timer;
        private static SettingsViewModel _settings;
        private static AboutViewModel _about;

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time services and viewmodels
            ////}
            ////else
            ////{
            ////    // Create run time services and view models
            ////}

        }

        /// <summary>
        /// Gets the Main property which defines the main viewmodel.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                if (_main == null)
                {
                    _main = new MainViewModel();
                }
                return _main;
            }
        }

        public SettingsViewModel Settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = new SettingsViewModel();
                }
                return _settings;
            }
        }

        public TimerViewModel Timer
        {
            get
            {
                if (_timer == null)
                {
                    _timer = new TimerViewModel();
                }

                return _timer;
            }
        }

        public AboutViewModel About
        {
            get
            {
                if (_about == null)
                {
                    _about = new AboutViewModel();
                }
                return _about;
            }
        }
    }
}