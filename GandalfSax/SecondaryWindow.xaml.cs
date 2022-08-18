using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace GandalfSax
{
	/// <summary>
	/// Interaction logic for SecondaryWindow.xaml
	/// </summary>
	public partial class SecondaryWindow : Window
	{
		private Point _lastMousePosition = default(Point);

		public SecondaryWindow(VisualBrush visualBrush)
		{
			InitializeComponent();

			Display.Fill = visualBrush;
		}

		private void OnSecondaryWindowKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.VolumeDown || e.Key == Key.VolumeUp)
			{
				return;
			}

			Application.Current.Shutdown();
		}

		private void OnSecondaryWindowMouseDown(object sender, MouseButtonEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void OnSecondaryWindowMouseMove(object sender, MouseEventArgs e)
		{
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
