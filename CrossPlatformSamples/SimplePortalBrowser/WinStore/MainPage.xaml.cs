using Esri.ArcGISRuntime.Portal;
using Windows.UI.Xaml.Controls;

namespace WinAPIDemo.WinStore
{
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();
		}

		private void GridView_ItemClick(object sender, ItemClickEventArgs e)
		{
			var item = (e.ClickedItem as ArcGISPortalItem);
			base.Frame.Navigate(typeof(MapPage), item);
		}

	}
}
