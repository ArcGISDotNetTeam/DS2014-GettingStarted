﻿using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if NETFX_CORE
using Windows.UI.Xaml;
#else
using System.Windows;
#endif

namespace RoutingSample
{
	/// <summary>
	/// Binding helpers
	/// </summary>
	public class CommandBinder
	{
		/// <summary>
		/// This command binding allows you to set the extent on a mapView from your view-model through binding
		/// </summary>
		public static Envelope GetRequestView(DependencyObject obj)
		{
			return (Envelope)obj.GetValue(RequestViewProperty);
		}

		/// <summary>
		/// This command binding allows you to set the extent on a mapView from your view-model through binding
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="extent"></param>
		public static void SetRequestView(DependencyObject obj, Envelope extent)
		{
			obj.SetValue(RequestViewProperty, extent);
		}

		/// <summary>
		/// Identifies the ZoomTo Attached Property.
		/// </summary>
		public static readonly DependencyProperty RequestViewProperty =
			DependencyProperty.RegisterAttached("RequestView", typeof(Envelope), typeof(CommandBinder), new PropertyMetadata(null, RequestViewPropertyChanged));

		private static void RequestViewPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is MapView)
			{
				MapView mapView = d as MapView;
				if (e.NewValue is Geometry)
				{
					if (mapView.Extent != null)
					{
						var _ = mapView.SetViewAsync((Geometry)e.NewValue);
					}
					else //Map not ready, wait till we have an extent and try again
					{
						//We could just set the InitialExtent instead, but this gives a cool zoom in effect.
						System.ComponentModel.PropertyChangedEventHandler handler = null;
						handler = async (s, e2) =>
							{
								if(e2.PropertyName == "Extent")
								{
									mapView.PropertyChanged -= handler;
									await Task.Delay(500); //Wait a little so map loads before zooming first time (better experience)
									var __ = mapView.SetViewAsync((Geometry)e.NewValue); 
								}
							};
						mapView.PropertyChanged += handler;
					}
				}
			}
		}

		static void mapView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}
