using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Chinook.StackNavigation;

namespace UnoTestApp
{
	public class ChildPageViewModel : INotifyPropertyChanged, INavigableViewModel
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void Dispose()
		{
		}

		public void SetView(object view)
		{
		}
	}
}
