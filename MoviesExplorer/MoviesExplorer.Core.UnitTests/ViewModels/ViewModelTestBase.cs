using System;
using NUnit.Framework;
using MvvmCross.Plugins.Messenger;
using System.Collections.Generic;

namespace MoviesExplorer.Core.UnitTests
{
	[TestFixture]
	public class ViewModelTestBase
	{
		protected readonly IMvxMessenger Messenger = new MvxMessengerHub(); 
		protected readonly ILogger Logger = new DebugLogger();
		protected IAppTracker Tracker  {get { return Logger as IAppTracker;}}
		protected List<Movie> TestMoviesList;

		[SetUp]
		public void Setup ()
		{
			ResetTestMoviesList ();
				
		}

		void ResetTestMoviesList ()
		{
			TestMoviesList = new List<Movie> {
				new Movie {
					Id = 1,
					Title = "Lord Of The Rings"
				},
				new Movie {
					Id = 2,
					Title = "Star Wars"
				},
				new Movie {
					Id = 3,
					Title = "The Blind Side"
				},
				new Movie {
					Id = 4,
					Title = "Two Weeks Notice"
				}
			};
		}
	}
}

