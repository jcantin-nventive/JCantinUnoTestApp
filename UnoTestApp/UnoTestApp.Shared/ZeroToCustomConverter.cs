using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace UnoTestApp
{
	public class ZeroToCustomConverter : IValueConverter
	{
		public object ZeroValue { get; set; }

		public object NonZeroValue { get; set; }

		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value != null
				&& (double)value > 0d)
			{
				return NonZeroValue;
			}

			return ZeroValue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
