using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace UnoTestApp
{
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();
			Loaded += MainPage_Loaded;
			Unloaded += MainPage_Unloaded;
		}

		private void MainPage_Unloaded(object sender, RoutedEventArgs e)
		{
			ListButton.Click -= ListButton_Click;
			CloseButton.Click -= CloseButton_Click;
		}

		private void MainPage_Loaded(object sender, RoutedEventArgs e)
		{
			VisualStateManager.GoToState(this, "Map", useTransitions: false);

			ListButton.Click += ListButton_Click;
			CloseButton.Click += CloseButton_Click;
		}

		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			VisualStateManager.GoToState(this, "Map", useTransitions: true);
		}

		private void ListButton_Click(object sender, RoutedEventArgs e)
		{
			VisualStateManager.GoToState(this, "Search", useTransitions: true);
		}

	}
}
