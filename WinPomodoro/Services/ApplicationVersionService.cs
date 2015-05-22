using System.Reflection;


namespace WinPomodoro.Services
{
    class ApplicationVersionService
    {
        public static string Version
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
    }
}
