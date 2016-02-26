using System;
using MoviesExplorer.Core;
using System.Net.Http;
using ModernHttpClient;

namespace MoviesExploerer.iOS
{
	public class NativeHttpMessageHandlerGenerator : INativeHttpMessageHandlerGenerator
	{
		#region  implementation

		/// <summary>
		/// Generate a native HttpMessageHandler
		/// </summary>
		/// <returns>The native handler.</returns>
		public HttpMessageHandler GetNativeHandler ()
		{
			return new NativeMessageHandler ();
		}

		#endregion
	}
}

