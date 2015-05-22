﻿using System.Windows;
using System.Windows.Input;
using System.Windows.Shell;
using WinPomodoro.Builders;
using WinPomodoro.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WinPomodoro.Messaging;

namespace WinPomodoro.ViewModel
{
    /// <summary>
    /// This is the main view model for the main window.  Normally this would just
    /// contain the other view models, but we are also interacting with the main
    /// window itself, so there is a little bit more code in here than usual:
    /// we are persisting the window location, and interacting with the taskbar.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region Fields
        /// <summary>
        /// The application settings.
        /// </summary>
        private readonly ISettingsModel _Settings = SettingsModelBuilder.GetNewSettings();

        private readonly ViewModelLocator _locator = new ViewModelLocator();

        /// <summary>
        /// The original window title since we swap it out with the countdown
        /// value.
        /// </summary>
        private readonly string _originalWindowTitle = "Countdown Timer";

        #region Backing stores
        // The backing store for the various INPC properties on this view-model
        private string _WindowTitle;
        private double _ProgressValue;
        private TaskbarItemProgressState _ProgressState;
        private bool _TopMost;
        #endregion

        #region View Models presented in the Content Control
        private ViewModelBase _currentViewModel;

        #endregion

        #region Commands
        public ICommand TimerViewCommand { get; private set; }
        public ICommand SettingsViewCommand { get; private set; }
        public ICommand PlayCommand { get; private set; }
        public ICommand PauseCommand { get; private set; }
        #endregion
        #endregion

        #region Construction
        /// <summary>
        /// Use a static constructor as it is the easiest way to handle any
        /// exceptions that might be thrown when creating the view models.
        /// </summary>
        static MainViewModel()
        {

        }


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            //  Set the start-up view model.
            CurrentViewModel = _locator.Timer;

            //  Create the commands
            TimerViewCommand = new RelayCommand(() => ExecuteViewTimerCommand());
            SettingsViewCommand = new RelayCommand(() => ExecuteViewSettingsCommand());
            PlayCommand = new RelayCommand(() => ExecutePlayCommand());
            PauseCommand = new RelayCommand(() => ExecutePauseCommand());

            //  Set the window title.
            WindowTitle = _originalWindowTitle;
            
            //  Update anything else that is user-settings related.
            UpdatePropertiesFromSettings();

            //  Lastly, listen for messages from other view models.
            Messenger.Default.Register<SimpleMessage>(this, ConsumeMessage);
            Messenger.Default.Register<TaskbarItemMessage>(this, ConsumeTaskbarItemMessage);
        }
        #endregion

        #region Methods

        /// <summary>
        /// Update the TaskbarItemInfo values with whatever is specified in the
        /// message.
        /// </summary>
        /// <param name="message"></param>
        void ConsumeTaskbarItemMessage(TaskbarItemMessage message)
        {
            if (message == null)
                return;

            ProgressState = message.State;

            //  if the taskbar item message carried a (percentage) value,
            //  update the taskbar progress value with it.
            if (message.HasValue)
                ProgressValue = message.Value;
        }

        /// <summary>
        /// Consume the SimpleMessage class and perform actions based on its content.
        /// </summary>
        /// <param name="message"></param>
        private void ConsumeMessage(SimpleMessage message)
        {
            switch (message.Type)
            {
                case SimpleMessage.MessageType.TimerTick:
                    //  this happens the most so put it first
                    WindowTitle = message.Message;
                    break;
                case SimpleMessage.MessageType.SwitchToTimerView:
                    ExecuteViewTimerCommand();
                    break;
                case SimpleMessage.MessageType.SwitchToSettingsView:
                    ExecuteViewSettingsCommand();
                    break;
                case SimpleMessage.MessageType.SettingsChanged:
                    UpdatePropertiesFromSettings();
                    break;
                case SimpleMessage.MessageType.TimerStop:
                    WindowTitle = _originalWindowTitle;
                    break;
                case SimpleMessage.MessageType.TimerReset:
                    //  restore window title if we reset.
                    WindowTitle = _originalWindowTitle;
                    break;
            }
        }

        private void ExecuteViewTimerCommand()
        {
            CurrentViewModel = _locator.Timer;
        }

        private void ExecuteViewSettingsCommand()
        {
            CurrentViewModel = _locator.Settings;
        }

        private static void ExecutePlayCommand()
        {
            Messenger.Default.Send(new SimpleMessage { Type = SimpleMessage.MessageType.TimerStart });
        }

        private static void ExecutePauseCommand()
        {
            Messenger.Default.Send(new SimpleMessage { Type = SimpleMessage.MessageType.TimerStop });
        }

        private void UpdatePropertiesFromSettings()
        {
            _Settings.Reload();
            TopMost = _Settings.TopMost;
        }
        #endregion

        #region Properties
        /// <summary>
        /// The progress state of the timer (aimed at the taskbar).
        /// </summary>
        public TaskbarItemProgressState ProgressState
        {
            get
            {
                return _ProgressState;
            }
            set
            {
                if (_ProgressState == value)
                    return;
                _ProgressState = value;

                RaisePropertyChanged("ProgressState");
            }
        }

        /// <summary>
        /// The progress value of the timer.
        /// </summary>
        public double ProgressValue
        {
            get
            {
                return _ProgressValue;
            }
            set
            {
                if (_ProgressValue == value)
                    return;
                _ProgressValue = value;

                RaisePropertyChanged("ProgressValue");
            }
        }
        
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                if (_currentViewModel == value)
                    return;
                _currentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }

        public bool TopMost
        {
            get
            {
                return _TopMost;
            }
            set
            {
                if (_TopMost == value)
                    return;
                _TopMost = value;
                RaisePropertyChanged("TopMost");
            }
        }

        public string WindowTitle
        {
            get
            {
                return _WindowTitle;
            }
            set
            {
                if (_WindowTitle == value)
                    return;
                _WindowTitle = value;
                RaisePropertyChanged("WindowTitle");
            }
        }

        #endregion

    }
}