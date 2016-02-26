using System;
using System.Threading.Tasks;

namespace MoviesExplorer.Core
{
	public class BaseDataService
	{
		protected readonly ILogger Logger;

		public BaseDataService (ILogger logger)
		{
			Logger = logger;
		}

		protected async Task<T> RunOperationWithRetrialOnFailure<T> (Func<Task<T>> operation)
		{
			var result = default(T);
			var attempt = 1;
			while(attempt <= Config.MaxNoOfRetrialAllowed)
			{
				try 
				{
					result = await operation();
				}
				catch(Exception e) 
				{
					Logger.Log(e);
				}

				++attempt;
			}

			return result;
		}
	}
}

