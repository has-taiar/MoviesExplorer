using System;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using MoviesExplorer.Core;

namespace MoviesExploerer.iOS
{
	public class DebugTrace : IMvxTrace
	{
		private readonly ILogger _logger = Mvx.Resolve<ILogger>();

		public void Trace(MvxTraceLevel level, string tag, Func<string> message)
		{
			_logger.LogInfo(tag + ":" + level + ":" + message());
		}

		public void Trace(MvxTraceLevel level, string tag, string message)
		{
			_logger.LogInfo(tag + ":" + level + ":" + message);
		}

		public void Trace(MvxTraceLevel level, string tag, string message, params object[] args)
		{
			try
			{
				_logger.LogInfo(string.Format(tag + ":" + level + ":" + message, args));
			}
			catch (FormatException e)
			{
				Console.WriteLine($"Exception during trace of {level}: {tag} - {message} \n {e}");
			}
		}
	}
}

