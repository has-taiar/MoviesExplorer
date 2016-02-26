using System;
using System.Collections.Generic;

using static System.Diagnostics.Debug;

namespace MoviesExplorer.Core
{
	
    public class DebugLogger : ILogger
    {
        public virtual void Log(Exception e)
        {
            WriteLine(e);
        }

        public virtual void Log(Exception e, string message)
        {
            WriteLine($"Error: {message}. {e}");
        }

        public virtual void LogError(string message)
        {
            WriteLine(message);
        }

        public virtual void LogInfo(string message)
        {
            WriteLine(message);
        }

        public virtual void LogWarn(string message)
        {
            WriteLine(message);
        }
    }
}
