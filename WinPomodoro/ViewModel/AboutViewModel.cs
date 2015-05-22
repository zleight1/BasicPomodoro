using System.Windows;
using System.Windows.Input;
using WinPomodoro.Messaging;
using WinPomodoro.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace WinPomodoro.ViewModel
{
    /// <summary>
    /// The view model for the about window.  It doesn't do anything apart 
    /// from accept the ok/dismiss command, which sends a message to switch
    /// back to the timer view.
    /// </summary>
    public class AboutViewModel : ViewModelBase
    {
        #region Fields

        private readonly string _homepage = "http://www.lapthorn.net";

        #endregion

        #region Construction

        public AboutViewModel()
        {
            OK = new RelayCommand(() => OkExecute());
            HomePage = new RelayCommand(() => HomePageExecute());
        }

        #endregion

        #region Commands

        public ICommand OK { get; private set; }
        public ICommand HomePage { get; private set; }

        #endregion

        #region Methods

        void OkExecute()
        {
            Messenger.Default.Send(new SimpleMessage { Type = SimpleMessage.MessageType.SwitchToTimerView });
        }

        private void HomePageExecute()
        {
            try
            {
                System.Diagnostics.Process.Start(_homepage);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        #endregion

        #region Properties

        public string Version
        {
            get
            {
                return string.Format("Version: {0}", ApplicationVersionService.Version);
            }
        }

        #endregion
    }
}
