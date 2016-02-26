using System;
using NUnit.Framework;
using MvvmCross.Plugins.Messenger;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace MoviesExplorer.Core.UnitTests
{
	[TestFixture]
	public class FavoriteMoviesViewModelTest : ViewModelTestBase
	{
		[Test]
		public void OnFavoritesListUpdated_WhenAMovieIsRemovedFromFavorites_MoviesListShouldBeUpdated ()
		{
			var viewModel = new FavoritesViewModel (Logger, Tracker, null, Messenger) { Movies = TestMoviesList.ToList() }; 

			// fire a message via messenger
			Messenger.Publish(new MovieMessage(this, TestMoviesList[1], false));

			var movie = viewModel.Movies.FirstOrDefault (m => m.Id == 2);
			Assert.IsNull (movie, "Movie should be removed from the list when it's not longer favorite");
		}

		[Test]
		public void OnFavoritesListUpdated_WhenAMovieIsAddedToFavorites_MoviesListShouldBeUpdated ()
		{
			var viewModel = new FavoritesViewModel (Logger, Tracker, null, Messenger) { Movies = TestMoviesList.ToList() }; 

			// fire a message via messenger
			Messenger.Publish(new MovieMessage(this, new Movie{Id=5, Title="Pursuit of Happyness"}, true));

			var movie = viewModel.Movies.FirstOrDefault (m => m.Id == 5);
			Assert.IsNotNull (movie, "Movie should be add to the list when it's saved to favorite");
		}

		[Test]
		public void OnFavoritesListUpdated_WhenAMovieIsAddedToFavorites__AndMoviesListIsEmpty_MoviesListShouldBeUpdated ()
		{
			var viewModel = new FavoritesViewModel (Logger, Tracker, null, Messenger) { Movies = new List<Movie>() }; 

			// fire a message via messenger
			Messenger.Publish(new MovieMessage(this, new Movie{Id=5, Title="Pursuit of Happyness"}, true));

			var movie = viewModel.Movies.FirstOrDefault ();
			Assert.IsNotNull (movie, "Movie should be add to the list when it's saved to favorite");
			Assert.AreEqual (5, movie.Id);
		}

		[Test]
		public void OnFavoritesListUpdated_WhenAMovieIsAddedToFavorites__AndMoviesListIsNull_MoviesListShouldBeUpdated ()
		{
			var viewModel = new FavoritesViewModel (Logger, Tracker, null, Messenger) { Movies = null }; 

			// fire a message via messenger
			Messenger.Publish(new MovieMessage(this, new Movie{Id=5, Title="Pursuit of Happyness"}, true));

			var movie = viewModel.Movies.FirstOrDefault ();
			Assert.IsNotNull (movie, "Movie should be add to the list when it's saved to favorite");
			Assert.AreEqual (5, movie.Id);
		}
	}
}

