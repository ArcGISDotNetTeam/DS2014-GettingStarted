﻿using Esri.ArcGISRuntime.Portal;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace WinAPIDemo.WinStore
{
	/// <summary>
	/// A basic page that provides characteristics common to most applications.
	/// </summary>
	public sealed partial class MapPage : Page
	{
		public MapPage()
		{
			this.InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			var item = e.Parameter as ArcGISPortalItem;
			var vm = Resources["mapVM"] as WinAPIDemo.ViewModels.MapVM;
			vm.PortalItem = item;
		}
		private void GoBack(object sender, RoutedEventArgs e)
		{
			if (this.Frame != null && this.Frame.CanGoBack) this.Frame.GoBack();
		}
		
	}
}
