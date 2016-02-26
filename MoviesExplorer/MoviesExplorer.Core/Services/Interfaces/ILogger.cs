using System;
using System.Collections.Generic;

namespace MoviesExplorer.Core
{
	public interface ILogger
	{
		void Log (Exception e);
		void Log (Exception e, string message);
		void LogError (string message);
		void LogWarn(string message);
		void LogInfo(string message);
	}
}

