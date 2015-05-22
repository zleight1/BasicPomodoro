﻿using System;
using System.Windows.Media;

namespace WinPomodoro.Models
{
    /// <summary>
    /// A class that just encapsulates the application settings.  This looks
    /// like a lot of replication, but it does always give us the option of 
    /// switching out the settings backing store at a later date.
    /// </summary>
    internal class SettingsModel : ISettingsModel
    {
        #region Constructors

        /// <summary>
        /// default constructor.
        /// </summary>
        public SettingsModel()
        {
            //  upgrade settings from a previous application version, if any
            UpgradeSettings();

            //  load the settings into this class.
            LoadSettings();

        }
        #endregion

        #region Fields

        private bool _FirstRun;
        private bool _PlayExclamation;
        private bool _PlayBeep; 
        private bool _topMost;
        private bool _colours;

        private TimeSpan _duration;

        private double _fontSize = 10;
        private FontFamily _FontFamily;
        
        #endregion

        #region Properties


        public bool Colours
        {
            get
            {
                return _colours;
            }
            set
            {
                if (_colours == value)
                    return;
                _colours = value;
                Modified = true;
            }
        }

        public FontFamily FontFamily
        {
            get
            {
                return _FontFamily;
            }
            set
            {
                if (_FontFamily == value)
                    return;
                _FontFamily = value;
                Modified = true;
            }
        }
        /// <summary>
        /// Returns whether the settings have been modified in some way.
        /// </summary>
        public bool Modified { get; private set; }

        /// <summary>
        /// The (last) selected duration of our timer.
        /// </summary>
        public TimeSpan Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                if (_duration == value)
                    return;

                _duration = value;
                Modified = true;
            }
        }

        /// <summary>
        /// Whether or not to play a beep (when the timer starts).
        /// </summary>
        public bool PlayBeep
        {
            get
            {
                return _PlayBeep;
            }
            set
            {
                if (_PlayBeep == value)
                    return;
                _PlayBeep = value;
                Modified = true;
            }
        }

        /// <summary>
        /// Whether or not to play an exclamation when the timer ends.
        /// </summary>
        public bool PlayExclamation
        {
            get
            {
                return _PlayExclamation;
            }
            set
            {
                if (_PlayExclamation == value)
                    return;
                _PlayExclamation = value;
                Modified = true;
            }
        }

        public bool FirstRun
        {
            get
            {
                return _FirstRun;
            }
            set
            {
                if (_FirstRun == value)
                    return;
                _FirstRun = value;
                Modified = true;
            }
        }

        public bool TopMost
        {
            get
            {
                return _topMost;
            }
            set
            {
                if (_topMost == value)
                    return;

                _topMost = value;
                Modified = true;
            }
        }

        public double FontSize
        {
            get
            {
                return _fontSize;
            }

            set
            {
                if (_fontSize == value)
                    return;
                _fontSize = value;
                Modified = true;
            }
        }
       
        #endregion

        #region Methods

        /// <summary>
        /// Actually update and save/persist the application settings.
        /// </summary>
        private void SaveSettings()
        {
            //  save the selected duration
            Properties.Settings.Default.Duration = Duration;

            //  save the window properties.
            Properties.Settings.Default.TopMost = TopMost;
            Properties.Settings.Default.FontSize = FontSize;
            Properties.Settings.Default.FontFamily = FontFamily.Source;
            Properties.Settings.Default.PlayExclamation = PlayExclamation;
            Properties.Settings.Default.PlayBeep = PlayBeep;
            Properties.Settings.Default.FirstRun = FirstRun;
            Properties.Settings.Default.Colours = Colours;

            //  persist the settings.
            Properties.Settings.Default.Save();


            Modified = false;
        }

        /// <summary>
        /// Load the application settings into the class.
        /// </summary>
        private void LoadSettings()
        {
            //  Now 'load' existing properties.
            Duration = Properties.Settings.Default.Duration;
            TopMost = Properties.Settings.Default.TopMost;
            FontSize = Properties.Settings.Default.FontSize;
            FontFamily = new FontFamily(Properties.Settings.Default.FontFamily);
            PlayBeep = Properties.Settings.Default.PlayBeep;
            PlayExclamation = Properties.Settings.Default.PlayExclamation;
            FirstRun = Properties.Settings.Default.FirstRun;
            Colours = Properties.Settings.Default.Colours;
        }

        /// <summary>
        /// Reload the settings from the application properties if necessary.
        /// </summary>
        public void Reload()
        {
            LoadSettings();
            //  reset modified state to false
            Modified = false;
        }

        /// <summary>
        /// Save the settings if they have been modified, otherwise do nothing.
        /// </summary>
        public void Save()
        {
            if (!Modified)
                return;

            SaveSettings();
        }

        private static void UpgradeSettings()
        {
            //  This is simple 'trick' to persist settings over from a previous
            //  application to a newer version.
            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
            }
        }
        #endregion

    }
}
