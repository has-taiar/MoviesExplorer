using System;
using NUnit.Framework;

namespace MoviesExplorer.Core.UnitTests
{
	[TestFixture]
	public class MovieDetailsViewModelTest
	{
		[Test]
		public void UpdateSaveToFavoritesButtonTextTest_WhenAMovieIsSavedToFavorites_TextShouldBeChangedToRemove ()
		{
			var viewModel = new MovieDetailViewModel (null, null, null, null, null, null);

			var buttonText = viewModel.SaveToFavoritesButtonText;
			Assert.AreEqual (Config.SaveToFavoriteButtonText, buttonText);

			viewModel.IsSavedToLocalDb = true;
			buttonText = viewModel.SaveToFavoritesButtonText;

			Assert.AreEqual (Config.RemoveFromFavoriteButtonText, buttonText);
		}

		[Test]
		public void UpdateSaveToFavoritesButtonTextTest_WhenAMovieIsRemovedFromFavorites_TextShouldBeChangedToAdd ()
		{
			var viewModel = new MovieDetailViewModel (null, null, null, null, null, null);

			var buttonText = viewModel.SaveToFavoritesButtonText;
			Assert.AreEqual (Config.SaveToFavoriteButtonText, buttonText); 

			viewModel.IsSavedToLocalDb = false;
			buttonText = viewModel.SaveToFavoritesButtonText;

			Assert.AreEqual (Config.SaveToFavoriteButtonText, buttonText);
		}
	}
}

