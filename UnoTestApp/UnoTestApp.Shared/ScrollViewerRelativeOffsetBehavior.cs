using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UnoTestApp.Behaviors
{
	/// <summary>
	/// This behavior keeps track of a ScrollViewer vertial scrolling position. It returns a relative offset which is calculated with the ScrollViewer height.
	/// To use this behavior, you must set IsEnabled attached property to true on the given ScrollViewer.
	/// You should also retrieve the RelativeOffset in a two-way binding with the RelativeOffset attached property.
	/// </summary>
	public static class ScrollViewerRelativeOffsetBehavior
	{
		public static double GetRelativeOffset(DependencyObject obj)
		{
			return (double)obj.GetValue(RelativeOffsetProperty);
		}

		public static void SetRelativeOffset(DependencyObject obj, double value)
		{
			obj.SetValue(RelativeOffsetProperty, value);
		}

		public static readonly DependencyProperty RelativeOffsetProperty =
			DependencyProperty.RegisterAttached("RelativeOffset", typeof(double), typeof(ScrollViewerRelativeOffsetBehavior), new PropertyMetadata(0d));

		public static bool GetIsEnabled(DependencyObject obj)
		{
			return (bool)obj.GetValue(IsEnabledProperty);
		}

		public static void SetIsEnabled(DependencyObject obj, bool value)
		{
			obj.SetValue(IsEnabledProperty, value);
		}

		public static readonly DependencyProperty IsEnabledProperty =
			DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(ScrollViewerRelativeOffsetBehavior), new PropertyMetadata(false, OnIsEnabledChanged));

		private static void OnIsEnabledChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
		{
			if (dependencyObject is ScrollViewer scrollViewer)
			{
				scrollViewer.ViewChanged -= OnScrollViewerViewChanged;

				if ((bool)args.NewValue)
				{
					scrollViewer.ViewChanged += OnScrollViewerViewChanged;
				}
			}
		}

		private static void OnScrollViewerViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
		{
			if (sender is ScrollViewer scrollViewer)
			{
				// Calculate the offset relative to the scrollview viewport height
				var relativeOffset = scrollViewer.VerticalOffset / scrollViewer.ViewportHeight;

				// Clamp the relative offset between 0 and 1
				relativeOffset = Math.Max(0, Math.Min(relativeOffset, 1));

				// Update the relative offset attached property
				SetRelativeOffset(scrollViewer, relativeOffset);
			}
		}
	}
}
