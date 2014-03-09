using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace WinAPIDemo.Phone
{
	public partial class MapPage : PhoneApplicationPage
	{
		public MapPage()
		{
			InitializeComponent();
		}
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			(Resources["mapVM"] as ViewModels.MapVM).PortalItem = MainPage.SelectedPortalItem;
		}
	}
}