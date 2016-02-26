using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace MoviesExplorer.Core
{
	public interface INativeHttpMessageHandlerGenerator
	{
		HttpMessageHandler GetNativeHandler();
	}


	
}

