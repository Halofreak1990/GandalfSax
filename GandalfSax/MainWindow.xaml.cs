using Microsoft.Win32;
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
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);        
            registryKey.SetValue("GandalfSax", System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        private void me_MediaEnded(object sender, RoutedEventArgs e)
        {
            var mediaElement = sender as MediaElement;

            mediaElement.Position = TimeSpan.FromSeconds(0);
            mediaElement.Play();
        }
    }
}
