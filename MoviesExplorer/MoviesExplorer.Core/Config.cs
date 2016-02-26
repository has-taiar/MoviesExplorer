
using System;

namespace MoviesExplorer.Core
{
	public static class Config
	{
		public static class ErrorMessages 
		{
			public const string SavingToDbFailed = "Oops! sorry could not save your changes.";
			public const string ConnectionProblem = "Oops! seems that we have internet connection problem.";
			public const string ErrorMessageForPlayButton = "Sorry, we do not have the video file for the movie. Try Netflix -:)";
			public const string ErrorMessageHeading = "Oops!";
		}

		public const string SaveToFavoriteButtonText = "Save to Favorites";
		public const string RemoveFromFavoriteButtonText = "Remove from Favorites";
		public const string CloseButtonIconName = "close.png";
		public const string FavoritesScreenTitle = "Favorites";
		public const string AppTitle = "Movie Explorer";

		//TODO: calc these values dyanmically based on screen bounds
		public const float SmallCollectionViewCellWidth = 100;
		public const float SmallCollectionViewCellHeight = 130;
		public const float LargeCollectionViewCellWidth = 120;
		public const float LargeCollectionViewCellHeight = 165;
		public const float FavoritesTableRowHeight  = 120;

		public const string ApiResourceAddressForNowPlaying = "now_playing";
		public const string ApiResourceAddressForPopularMovies = "popular";
		public const string ApiResourceAddressForTopRated = "top_rated";
		public const string ApiResourceAddressForSimilarMovies = "similar";
		public const int MaxNoOfRetrialAllowed = 3;
		public const string MoviePosterBaseUrl = "https://image.tmdb.org/t/p/w500";
		public const string ApiKeyQueryStringParamName = "api_key";
		public const string TopRatedSectionTitle = "Top Rated";
		public const string PopularSectionTitle = "Popular";
		public const string NowPlayingSectionTitle = "Now Playing";
		public const string LoadingMessageText  = "Loading...";
		public const string SQLiteDbFileName = "movies.db3";
		public const string AppTitleCustomFontName = "Stackyard PERSONAL USE";

		#if DEBUG

		// TODO: update this key to your azure app insights to get all crash reports and analytics
		public const string AzureAppInsightsKey = "d9e8cfc1-88b6-46f4-a494-e2301a00f7c8";
		public const string ApiKey = "ab41356b33d100ec61e6c098ecc92140";
		public const string ApiBaseUrl = "https://api.themoviedb.org/3/movie";

		#else

		public const string AzureAppInsightsKey = "d9e8cfc1-88b6-46f4-a494-e2301a00f7c8";
		public const string ApiKey = "ab41356b33d100ec61e6c098ecc92140";
		public const string ApiBaseUrl = "https://api.themoviedb.org/3/movie";

		#endif


	}
}

