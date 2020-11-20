using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;

namespace UnoTestApp
{
	public static partial class FrameworkElementActualSizeBehavior
	{
		public static readonly DependencyProperty EnableActualSizeBindingProperty = DependencyProperty.RegisterAttached("EnableActualSizeBinding", typeof(bool), typeof(FrameworkElementActualSizeBehavior), new PropertyMetadata(false, OnEnableActualSizeBindingtPropertyChanged));

		public static readonly DependencyProperty ActualHeightProperty = DependencyProperty.RegisterAttached("ActualHeight", typeof(double), typeof(FrameworkElementActualSizeBehavior), new PropertyMetadata(double.NaN));

		public static readonly DependencyProperty ActualWidthProperty = DependencyProperty.RegisterAttached("ActualWidth", typeof(double), typeof(FrameworkElementActualSizeBehavior), new PropertyMetadata(double.NaN));

		public static bool GetEnableActualSizeBinding(FrameworkElement obj)
		{
			return (bool)obj.GetValue(EnableActualSizeBindingProperty);
		}

		public static void SetEnableActualSizeBinding(FrameworkElement obj, bool value)
		{
			obj.SetValue(EnableActualSizeBindingProperty, value);
		}

		public static double GetActualHeight(FrameworkElement obj)
		{
			return (double)obj.GetValue(ActualHeightProperty);
		}

		public static void SetActualHeight(FrameworkElement obj, double value)
		{
			obj.SetValue(ActualHeightProperty, value);
		}

		public static double GetActualWidth(FrameworkElement obj)
		{
			return (double)obj.GetValue(ActualWidthProperty);
		}

		public static void SetActualWidth(FrameworkElement obj, double value)
		{
			obj.SetValue(ActualWidthProperty, value);
		}

		private static void OnEnableActualSizeBindingtPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
		{
			if (sender is FrameworkElement baseElement)
			{
				if ((bool)args.NewValue)
				{
					// Size may have changed while this was disabled, so we force an updated once user enables it
					UpdateActualSizeProperties(baseElement, null);

					// Subscribe to event
					baseElement.SizeChanged += UpdateActualSizeProperties;
				}
				else
				{
					// Unsubscribe from event
					baseElement.SizeChanged -= UpdateActualSizeProperties;
				}
			}
		}

		private static void UpdateActualSizeProperties(object sender, RoutedEventArgs routedEventArgs)
		{
			if (sender is FrameworkElement baseElement)
			{
				// Update only if needed
				var currentHeight = GetActualHeight(baseElement);
				if (currentHeight != baseElement.ActualHeight)
				{
					SetActualHeight(baseElement, baseElement.ActualHeight);
				}

				// Update only if needed
				var currentWidth = GetActualWidth(baseElement);
				if (currentWidth != baseElement.ActualWidth)
				{
					SetActualWidth(baseElement, baseElement.ActualWidth);
				}
			}
		}
	}
}
