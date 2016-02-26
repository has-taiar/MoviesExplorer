using System;
using MoviesExplorer.Core;
using System.Net.Http;
using ModernHttpClient;

namespace MoviesExploerer.iOS
{
	public class NativeHttpMessageHandlerGenerator : INativeHttpMessageHandlerGenerator
	{
		#region  implementation

		public HttpMessageHandler GetNativeHandler ()
		{
			return new NativeMessageHandler ();
		}

		#endregion
	}
}

