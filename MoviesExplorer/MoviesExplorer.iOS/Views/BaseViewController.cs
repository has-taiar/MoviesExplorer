using System;
using MvvmCross.iOS.Views;
using Foundation;
using MoviesExplorer.Core;

namespace MoviesExploerer.iOS
{
	public abstract class BaseViewController : MvxViewController 
	{
		public BaseViewController (string nibName, NSBundle handle) : base(nibName, handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			SetupBinding ();
		}
			
		protected abstract void SetupBinding ();

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			BaseViewModel.AppTracker.TrackScreen (this.GetType().Name);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();

			BaseViewModel.Logger.LogWarn ($"{this.GetType()} Page Received Memory Warning");
		}

		private BaseViewModel BaseViewModel
		{
			get { return (BaseViewModel)base.ViewModel; }
		}
	}
}

