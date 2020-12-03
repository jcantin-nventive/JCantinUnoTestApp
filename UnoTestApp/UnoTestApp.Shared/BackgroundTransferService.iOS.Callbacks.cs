#if __IOS__
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Foundation;

namespace UnoTestApp
{
	public class SessionCallbacks : NSUrlSessionDownloadDelegate
	{
		public SessionCallbacks()
		{
		}

		public override void DidCompleteWithError(NSUrlSession session, NSUrlSessionTask task, NSError error)
		{
		}

		public override void DidSendBodyData(NSUrlSession session, NSUrlSessionTask task, long bytesSent, long totalBytesSent, long totalBytesExpectedToSend)
		{
		}

		public override void DidWriteData(NSUrlSession session, NSUrlSessionDownloadTask downloadTask, long bytesWritten, long totalBytesWritten, long totalBytesExpectedToWrite)
		{
		}

		public override void DidFinishDownloading(NSUrlSession session, NSUrlSessionDownloadTask downloadTask, NSUrl tempLocation)
		{
		}
	}
}
#endif