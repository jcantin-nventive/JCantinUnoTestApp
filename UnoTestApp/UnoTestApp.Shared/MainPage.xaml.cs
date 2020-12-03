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
using Foundation;
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
			var configuration = CreateDefaultConfiguration();
			INSUrlSessionDelegate downloadDelegate = new SessionCallbacks();
			var session = NSUrlSession.FromConfiguration(configuration, downloadDelegate, null);
			var request = new NSMutableUrlRequest(new NSUrl("https://accp.api.ia.ca/groupinsurance/v1/membercontracts/0000029917-0001106772-00005/documents/travelletter/content"));
			request["Authorization"] = "Bearer a8988b21-0518-4d6b-a2f2-822bcbc067d8";
			var downloadRequest = session.CreateDownloadTask(request);
			downloadRequest.Resume();
			//			var webClient = new WebClient();
			//			webClient.Headers.Add("Authorization", "Bearer a8988b21-0518-4d6b-a2f2-822bcbc067d8");
			//			var fileName = Path.Combine(
			//				Environment.GetFolderPath(Environment.SpecialFolder.Personal),
			//				"form.pdf");
			//			webClient.DownloadFile(new Uri("https://accp.api.ia.ca/groupinsurance/v1/membercontracts/0000029917-0001106772-00005/documents/travelletter/content"), fileName);
			//#if __IOS__
			//			var urlToOpen = Foundation.NSUrl.FromFilename(fileName);
			//			var extension = urlToOpen.PathExtension;

			//			var openInWindow = new UIDocumentInteractionController()
			//			{
			//				Url = urlToOpen,
			//			};

			//			openInWindow.PresentOptionsMenu(new CGRect(0, 260, 320, 320), UIApplication.SharedApplication.KeyWindow.RootViewController.View, false);
			//#endif
		}

		private NSUrlSessionConfiguration CreateDefaultConfiguration()
		{
			// cf. https://developer.apple.com/library/ios/documentation/Foundation/Reference/NSURLSessionConfiguration_class/index.html

			// CreateBackgroundSessionConfiguration is only available since iOS 8.0
			var configuration = (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
				? NSUrlSessionConfiguration.CreateBackgroundSessionConfiguration("__default")
				: NSUrlSessionConfiguration.BackgroundSessionConfiguration("__default");

			// For BG transfer we need to register for launch events (Use static method on the BackgroundTransferService to handle it)
			configuration.SessionSendsLaunchEvents = true;

			// Mark the transfer as not Discretionary (default value) as transfer are usually launched by the end user. 
			// Anyway this is overritten when a transfer is launched from a background app :
			// "For transfers started while your app is in the background, the system always starts transfers at its discretion—in other words, 
			// the system assumes this property is YES and ignores any value you specified."
			// https://developer.apple.com/library/mac/documentation/Foundation/Reference/NSURLSessionConfiguration_class/#//apple_ref/occ/instp/NSURLSessionConfiguration/discretionary
			configuration.Discretionary = false;

			// Specifies type of traffic.
			// We use "Default" since the "Background" is intended to be used for downloads that were not requested by the user—for example, prefetching content
			// Usually the BackgroundTransferService is used to download/upload files requested by the user, not for prefetching.
			configuration.NetworkServiceType = NSUrlRequestNetworkServiceType.Default;

			// DOC NOT FOUND
			// configuration.ShouldUseExtendedBackgroundIdleMode = ???

			return configuration;
		}
	}
}
