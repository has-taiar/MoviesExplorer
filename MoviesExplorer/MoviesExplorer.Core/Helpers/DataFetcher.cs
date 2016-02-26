using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace MoviesExplorer.Core
{
	public class DataFetcher : IDataFetcher
	{
		readonly INativeHttpMessageHandlerGenerator _nativeMessageHandlerCreator; 

		public DataFetcher (INativeHttpMessageHandlerGenerator messageHandlerCreator)
		{
			_nativeMessageHandlerCreator = messageHandlerCreator;
		}

		public async Task<T> Fetch<T>(string url, Dictionary<string,string> headers)
		{
			// setting up our native message handler for improved performance
			using(var httpClient = new HttpClient(_nativeMessageHandlerCreator.GetNativeHandler()))
			{
				headers = headers ?? new Dictionary<string, string>();

				foreach(var header in headers)
				{
					httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
				}

				var httpResult = await httpClient.GetStringAsync(url); 

				var result = JsonConvert.DeserializeObject<T>(httpResult);

				return result;
			}
		}
	}

}

