using System;
using System.Collections.Generic;
using AI.Xamarin.Abstractions;

using Plugin.DeviceInfo;
using Foundation;
using MoviesExplorer.Core;

namespace MoviesExploerer.iOS
{
	public class AzureAiLogger: DebugLogger, ILogger, IAppTracker
	{
		public AzureAiLogger (string azureAiKey )
		{
			AzureAiManager.Setup(azureAiKey);
			AzureAiManager.Start();

			_DeviceInfo = LoadDeviceInfo();
		}

		private Dictionary<string, string> LoadDeviceInfo()
		{
			var info = new Dictionary<string, string>
			{
				{"Id", CrossDeviceInfo.Current.Id},
				{"Model", CrossDeviceInfo.Current.Model},
				{"Version", CrossDeviceInfo.Current.Version},
				{"Platform", CrossDeviceInfo.Current.Platform.ToString()}, 
				{"AppVersion", NSBundle.MainBundle.InfoDictionary["CFBundleVersion"].ToString()}
			};

			return info;
		}

		#region IAppTracker implementation

		public void TrackScreen (string screenName)
		{
			TelemetryManager.TrackPageView(screenName, 1, _DeviceInfo);
		}

		public void TrackEvent (string eventName)
		{
			TelemetryManager.TrackEvent(eventName, _DeviceInfo);
		}

		#endregion

		#region ILogger Implementation

		public override void Log (Exception e)
		{
			if (e == null)
				return;
			
			base.Log (e);
			foreach(var pair in _DeviceInfo)
				e.Data[pair.Key] = pair.Value;

			TelemetryManager.TrackManagedException(e, true);
		}

		public override void LogError (string message)
		{
			if (string.IsNullOrEmpty (message))
				return;

			base.LogError (message);
			var errorProps = new Dictionary<string, string>();
			foreach(var pair in _DeviceInfo)
				errorProps.Add(pair.Key, pair.Value);

			errorProps.Add("Error", "Error");	
			TelemetryManager.TrackTrace(message, errorProps);
		}

		public override void LogInfo (string message)
		{
			if (string.IsNullOrEmpty (message))
				return;

			base.LogInfo (message);
			TelemetryManager.TrackTrace(message, _DeviceInfo);
		}

		public override void LogWarn (string message)
		{
			if (string.IsNullOrEmpty (message))
				return;

			base.LogWarn (message);

			TelemetryManager.TrackTrace(message, _DeviceInfo);
		}

		private Dictionary<string, string> _DeviceInfo;

		#endregion
	}
}

