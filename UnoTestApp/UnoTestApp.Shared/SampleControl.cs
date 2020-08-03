using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UnoTestApp
{
	public class SampleControl : Control
	{
		public DataTemplate SampleTemplate
		{
			get { return (DataTemplate)GetValue(SampleTemplateProperty); }
			set { SetValue(SampleTemplateProperty, value); }
		}

		public static readonly DependencyProperty SampleTemplateProperty =
			DependencyProperty.Register("SampleTemplate", typeof(DataTemplate), typeof(SampleControl), new PropertyMetadata(null));
	}
}
