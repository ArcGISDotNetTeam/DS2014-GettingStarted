using System;
#if NETFX_CORE
using Windows.UI.Xaml;
#else
using System.Windows;
#endif

namespace WinAPIDemo.Converters
{
	public class BoolToVisibility : BaseValueConverter
	{
		protected override object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value is bool)
			{
				bool val = (bool)value;
				return val ? Visibility.Visible : Visibility.Collapsed;
			}
			return value;
		}

		protected override object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
