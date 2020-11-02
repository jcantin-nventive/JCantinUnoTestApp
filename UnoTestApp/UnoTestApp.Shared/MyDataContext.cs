using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UnoTestApp
{
	[Windows.UI.Xaml.Data.Bindable]
	public class MyDataContext : INotifyPropertyChanged
	{
		private bool _isTextBoxEnabled = true;

		public MyDataContext()
		{
			var a = new BackgroundWorker();
			a.DoWork += A_DoWork;
			a.RunWorkerAsync();
		}

		private void A_DoWork(object sender, DoWorkEventArgs e)
		{
			_isTextBoxEnabled = false;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsTextBoxEnabled)));
		}

		public bool IsTextBoxEnabled => _isTextBoxEnabled;

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
