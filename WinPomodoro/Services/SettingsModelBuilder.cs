using WinPomodoro.Models;


namespace WinPomodoro.Builders
{
    /// <summary>
    /// A simple class with a factory method to return a settings model.
    /// </summary>
    class SettingsModelBuilder
    {
        public static ISettingsModel GetNewSettings()
        {
            return new SettingsModel();
        }
    }
}
