using System;
using System.Collections.Generic;

namespace MoviesExplorer.Core
{
	/// <summary>
	/// track app navigation events (possibly send them to Xamarin.Insights or Azure App Insights)
	/// </summary>
	public interface IAppTracker
	{
		void TrackScreen(string screenName);
		void TrackEvent(string eventName);
	}
}

