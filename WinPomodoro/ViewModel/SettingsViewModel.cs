using System;
using System.Windows.Input;
using System.Windows.Media;
using WinPomodoro.Builders;
using WinPomodoro.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WinPomodoro.Messaging;


namespace WinPomodoro.ViewModel
{
    /// <summary>
    /// The view-model for the Settings view.
    /// </summary>
    public class SettingsViewModel : ViewModelBase
    {
        #region Fields

        readonly ISettingsModel _settings = SettingsModelBuilder.GetNewSettings();

        #endregion

        #region Construction
        public SettingsViewModel()
        {
            OK = new RelayCommand(() => OkExecute(), CanOkExecute);
            Cancel = new RelayCommand(() => CancelExecute());
        }
        #endregion

        #region Properties
        /// <summary>
        /// The timer duration
        /// </summary>
        public TimeSpan Duration
        {
            get
            {
                return _settings.Duration;
            }
            set
            {
                if (_settings.Duration == value)
                    return;
                _settings.Duration = value;
                RaisePropertyChanged("Duration");
            }
        }


        public bool Colours
        {
            get
            {
                return _settings.Colours;
            }

            set
            {
                if (_settings.Colours == value)
                    return;
                _settings.Colours = value;
                RaisePropertyChanged("Colours");
            }
        }

        /// <summary>
        /// Is this the first time the application has been run?
        /// </summary>
        public bool FirstRun
        {
            get
            {
                return _settings.FirstRun;
            }
            set
            {
                if (_settings.FirstRun == value)
                    return;
                _settings.FirstRun = value;
                RaisePropertyChanged("FirstRun");
            }
        }

        /// <summary>
        /// Do we want our window to be top-most?
        /// </summary>
        public bool TopMost
        {
            get
            {
                return _settings.TopMost;
            }
            set
            {
                if (_settings.TopMost == value)
                    return;
                _settings.TopMost = value;
                RaisePropertyChanged("TopMost");
            }
        }

        /// <summary>
        /// The clock font size.
        /// </summary>
        public double FontSize
        {
            get
            {
                return _settings.FontSize;
            }
            set
            {
                if (_settings.FontSize == value)
                    return;
                _settings.FontSize = value;
                RaisePropertyChanged("FontSize");
            }
        }

        /// <summary>
        /// The clock font family
        /// </summary>
        public FontFamily FontFamily
        {
            get
            {
                return _settings.FontFamily;
            }
            set
            {
                if (_settings.FontFamily == value)
                    return;
                _settings.FontFamily = value;
                RaisePropertyChanged("FontFamily");
            }
        }

        /// <summary>
        /// Play a beep when starting.
        /// </summary>
        public bool PlayBeep
        {
            get
            {
                return _settings.PlayBeep;
            }
            set
            {
                if (_settings.PlayBeep == value)
                    return;
                _settings.PlayBeep = value;
                RaisePropertyChanged("PlayBeep");
            }
        }

        /// <summary>
        /// Play an exclamation when complete.
        /// </summary>
        public bool PlayExclamation
        {
            get
            {
                return _settings.PlayExclamation;
            }
            set
            {
                if (_settings.PlayExclamation == value)
                    return;
                _settings.PlayExclamation = value;
                RaisePropertyChanged("PlayExclamation");
            }
        }
        #endregion

        #region Commands

        public ICommand OK { get; private set; }
        public ICommand Cancel { get; private set; }

        #endregion

        #region Methods
        private void OkExecute()
        {
            _settings.Save();

            Messenger.Default.Send(new SimpleMessage { Type = SimpleMessage.MessageType.SettingsChanged });
            Messenger.Default.Send(new SimpleMessage { Type = SimpleMessage.MessageType.SwitchToTimerView });
        }

        private bool CanOkExecute()
        {
            return _settings.Modified;
        }

        private void CancelExecute()
        {
            Messenger.Default.Send(new SimpleMessage { Type = SimpleMessage.MessageType.SwitchToTimerView });
        }
        #endregion

    }
}
