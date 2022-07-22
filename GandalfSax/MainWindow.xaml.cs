using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GandalfSax
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly bool _isPreviewWindow;
        private Point _lastMousePosition = default(Point);

        public MainWindow(bool isPreviewWindow = false)
        {
            InitializeComponent();

            _isPreviewWindow = isPreviewWindow;
        }

        private void me_MediaEnded(object sender, RoutedEventArgs e)
        {
            var mediaElement = sender as MediaElement;

            mediaElement.Position = TimeSpan.FromMilliseconds(1);
        }

        private void OnMainWindowKeyDown(object sender, KeyEventArgs e)
        {
            if (_isPreviewWindow)
            {
                return;
            }

            Application.Current.Shutdown();
        }

        private void OnMainWindowMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_isPreviewWindow)
            {
                return;
            }

            Application.Current.Shutdown();
        }

        private void OnMainWindowMouseMove(object sender, MouseEventArgs e)
        {
            if (_isPreviewWindow)
            {
                return;
            }

            var pos = e.GetPosition(this);

            if (_lastMousePosition != default(Point))
            {
                if ((_lastMousePosition - pos).Length > 3)
                {
                    Application.Current.Shutdown();
                }
            }

            _lastMousePosition = pos;
        }
    }
}
