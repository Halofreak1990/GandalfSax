using System;
using System.Windows;
using System.Windows.Controls;

namespace GandalfSax
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void me_MediaEnded(object sender, RoutedEventArgs e)
        {
            var mediaElement = sender as MediaElement;

            mediaElement.Position = TimeSpan.FromMilliseconds(1);
        }
    }
}
