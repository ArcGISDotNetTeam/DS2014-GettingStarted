using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WinAPIDemo.Phone.Resources;
using Esri.ArcGISRuntime.Portal;

namespace WinAPIDemo.Phone
{
	public partial class MainPage : PhoneApplicationPage
	{
		public static ArcGISPortalItem SelectedPortalItem { get; private set; }

		public MainPage()
		{
			InitializeComponent();
		}

		private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
		{
			SelectedPortalItem = (sender as FrameworkElement).DataContext as ArcGISPortalItem;
			NavigationService.Navigate(new Uri("/MapPage.xaml", UriKind.Relative));
		}
	}
}