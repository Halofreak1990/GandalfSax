using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
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

                    window.Background = new SolidColorBrush(Colors.Black);
                    window.WindowStartupLocation = WindowStartupLocation.Manual;
                    window.Left                  = s.WorkingArea.Left;
                    window.Top                   = s.WorkingArea.Top;
                    window.ShowInTaskbar         = false;

                    window.Show();

                    window.WindowState = WindowState.Maximized;
                }
            }
            else if (e.Args[0].ToLower().StartsWith("/p")) // preview screensaver
            {
                string secondArgument = null;

                if (e.Args.Length > 1)
                {
                    secondArgument = e.Args[1];
                }

                if (secondArgument == null)
                {
                    // We didn't get a parent window handle (maybe launched from debugger?)
                    return;
                }

                var window = new MainWindow(true);
                window.Background = new SolidColorBrush(Colors.Black);
                window.WindowStartupLocation = WindowStartupLocation.Manual;
                window.WindowStyle           = WindowStyle.None;
                window.WindowState           = WindowState.Normal;
                window.ResizeMode            = ResizeMode.NoResize;
                window.ShowInTaskbar         = false;

                var previewWndHandle = new IntPtr(long.Parse(secondArgument));

                var helper = new WindowInteropHelper(window) { Owner = previewWndHandle };

                // Get size on parent
                NativeMethods.Rect rect;
                NativeMethods.GetWindowRect(previewWndHandle, out rect);

                window.Top = 0;
                window.Left = 0;
                window.Width = rect.Width;
                window.Height = rect.Height;
                window.Show();

                // Set the preview window as the parent of this window
                NativeMethods.SetParent(helper.Handle, previewWndHandle);

                // Make this a child window so it will close when the parent dialog closes
                // GWL_STYLE = -16, WS_CHILD = 0x40000000
                NativeMethods.SetWindowLong(helper.Handle, -16, (long)NativeMethods.GetWindowLong(helper.Handle, -16) | 0x40000000);
            }
            else if (e.Args[0].ToLower().StartsWith("/c")) // configure screensaver
            {
            }
        }
    }
}
