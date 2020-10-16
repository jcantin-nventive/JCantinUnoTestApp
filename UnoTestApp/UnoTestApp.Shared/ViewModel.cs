using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace UnoTestApp
{
	[Bindable]
	public class ViewModel : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		private double _relativeOffset;
		public double RelativeOffset
		{
			get => _relativeOffset;
			set
			{
				_relativeOffset = value;
				PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(RelativeOffset)));
			}
		}
	}
}
