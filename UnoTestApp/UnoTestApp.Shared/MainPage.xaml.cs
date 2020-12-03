using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Chinook.StackNavigation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
#if __IOS__
using CoreGraphics;
using UIKit;
#endif

namespace UnoTestApp
{
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();
		}

		private async void Button_Click(object sender, RoutedEventArgs e)
		{
			var webClient = new WebClient();
			webClient.Headers.Add("Authorization", "Bearer 60f8a441-311f-4aa7-982f-62d4a6a6603e");
			webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
			var fileName = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.Personal),
				"form.pdf");
			webClient.DownloadFile(new Uri("https://accp.api.ia.ca/groupinsurance/v1/membercontracts/0000029917-0001106772-00005/documents/travelletter/content"), fileName);
#if __IOS__
			var urlToOpen = Foundation.NSUrl.FromFilename(fileName);
			var extension = urlToOpen.PathExtension;

			var openInWindow = new UIDocumentInteractionController()
			{
				Url = urlToOpen,
			};

			openInWindow.PresentOptionsMenu(new CGRect(0, 260, 320, 320), UIApplication.SharedApplication.KeyWindow.RootViewController.View, false);
#endif
		}

		private void WebClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
		{
		}
	}
}
