using System.Windows;
using System.Windows.Media;

namespace GandalfSax
{
	/// <summary>
	/// Interaction logic for SecondaryWindow.xaml
	/// </summary>
	public partial class SecondaryWindow : Window
	{
		public SecondaryWindow(VisualBrush visualBrush)
		{
			InitializeComponent();

			Display.Fill = visualBrush;
		}
	}
}
