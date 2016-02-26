namespace MoviesExplorer.Core
{
	/// <summary>
	/// Use this class to indicate the completion (failure/success) of operation instead of throwing exceptions around. 
	/// </summary>
	public class OperationResult
	{
		public OperationResult (bool successful, string message)
		{
			IsSuccessful = successful;
			Message = message;
		}

		public bool IsSuccessful {get;set;}
		public string Message {get;set;}

	}
}

