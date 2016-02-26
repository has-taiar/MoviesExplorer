using AI.Xamarin.Abstractions;

namespace MoviesExploerer.iOS
{
	/// <summary>
	/// Manage Azure App Insights start/update
	/// </summary>
	public static class AzureAiManager
	{
		public static void Setup(string appKey)
		{
			Insights = new AI.Xamarin.iOS.ApplicationInsights ();
			ApplicationInsights.Init (Insights);

			TelemetryManager.Init(new AI.Xamarin.iOS.TelemetryManager());
			ApplicationInsights.SetAutoPageViewTrackingDisabled (true);
			ApplicationInsights.Setup(appKey);
		}

		public static void Start()
		{
			ApplicationInsights.Start();
		}

		public static void Configure(string userId = "" )
		{
			ApplicationInsights.SetAutoPageViewTrackingDisabled(true);

			if (!string.IsNullOrEmpty(userId))
				ApplicationInsights.SetUserId(userId);
		}

		public static void RenewSession()
		{
			ApplicationInsights.StartNewSession();
		}

		public static IApplicationInsights Insights;

	}
}

