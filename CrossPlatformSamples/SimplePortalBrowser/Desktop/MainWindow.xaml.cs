using System.Windows;

namespace WinAPIDemo.WPF
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Exit_Clicked(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
