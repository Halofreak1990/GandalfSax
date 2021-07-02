using System.Windows.Forms;
using System.Windows;
using System.Windows.Media;

using Application = System.Windows.Application;

namespace GandalfSax
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            if (e.Args.Length == 0 || e.Args[0].ToLower().StartsWith("/s"))
            {
                var mainWindow = new MainWindow();
                var brush = mainWindow.Resources["Media"] as VisualBrush;

                foreach (var s in Screen.AllScreens)
                {
                    Window window;

                    if (!s.Primary)
                    {
                        window = new SecondaryWindow(brush);
                    }
                    else
                    {
                        window = mainWindow;
                    }

                    window.WindowStartupLocation = WindowStartupLocation.Manual;
                    window.Left                  = s.WorkingArea.Left;
                    window.Top                   = s.WorkingArea.Top;
                    window.Show();
                    window.WindowState = WindowState.Maximized;
                }
            }
            else if (e.Args[0].ToLower().StartsWith("/p")) // preview screensaver
            {
            }
            else if (e.Args[0].ToLower().StartsWith("/c")) // configure screensaver
            {
            }
        }
    }
}
