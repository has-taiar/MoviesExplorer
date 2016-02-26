using System;
using MvvmCross.Core.ViewModels;

namespace MoviesExplorer.Core
{
	public class BaseViewModel : MvxViewModel
	{
		public readonly ILogger Logger;
		public readonly IAppTracker AppTracker; 

		public BaseViewModel (ILogger logger, IAppTracker appTracker)
		{
			Logger = logger;
			AppTracker = appTracker;
		}

		public void Close() 
		{
			Close (this);
		}

		private bool _isLoading;
		public bool IsLoading
		{
			get { return _isLoading; }
			set { _isLoading = value; RaisePropertyChanged(() => IsLoading); }
		}

		private string _busyMessage;
		public string BusyMessage {
			get { return _busyMessage; }
			set {
				_busyMessage = value;
				RaisePropertyChanged (() => BusyMessage);
			}
		}

		protected void SetLoadingFlag (bool isLoading)
		{
			IsLoading = isLoading;
			BusyMessage = isLoading ? Config.LoadingMessageText : string.Empty;
		}
	}
}

