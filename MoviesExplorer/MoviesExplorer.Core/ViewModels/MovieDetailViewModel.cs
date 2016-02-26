using System;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Plugins.Messenger;
using Chance.MvvmCross.Plugins.UserInteraction;

namespace MoviesExplorer.Core
{
	public class MovieDetailViewModel : BaseViewModel
	{
		private Movie Movie { get; set;}
		private readonly IMoviesApiService _movieApiService;
		private readonly ILocalDataService _localDataService;
		private readonly IMvxMessenger _messenger;
		private readonly IUserInteraction _alertService;


		public MovieDetailViewModel (ILogger logger, IAppTracker appTracker, IMoviesApiService movieApiService, 
			ILocalDataService localDataService, IMvxMessenger messenger, IUserInteraction alertService)  : base(logger, appTracker)
		{
			_movieApiService = movieApiService;
			_localDataService = localDataService;
			_messenger = messenger;
			_alertService = alertService;
		}

		public async void Init(Movie movie)
		{
			Movie = movie;
			VotesCount = $"(of {movie?.VotesCount} votes)";
			ReleaseDate = $"Release Date: {Movie?.ReleaseDate}";
			AverageRating = (decimal) movie.VotesAverage; // todo: fix type difference (MvvmCross is not passing decimal
			SimilarMovies = await _movieApiService.GetSimilarMovies (movie.Id);
			IsSavedToLocalDb = await _localDataService.IsInFavorites (movie.Id);
		}

		public string MovieTitle {
			get { return Movie.Title; }
			set {
				Movie.Title = value;
				RaisePropertyChanged (() => MovieTitle);
			} 
		}

		public string MovieDescription {
			get { return Movie?.Description; }
			set {
				Movie.Description = value;
				RaisePropertyChanged (() => MovieDescription);
			}
		}

		private string _votesCount; 
		public string VotesCount {
			get { return _votesCount;}
			set {
				_votesCount = value;
				RaisePropertyChanged (() => VotesCount);
			}
		}

		public decimal _averageRating;
		public decimal AverageRating 
		{
			get { return _averageRating; }
			set { _averageRating = value; RaisePropertyChanged(() => AverageRating);}
		}

		private string _releaseDate;
		public string ReleaseDate {
			get { return _releaseDate; }
			set 
			{
				_releaseDate = value;
				RaisePropertyChanged (() => ReleaseDate);
			}
		}

		public string ImageUrl {
			get { return Movie?.ImageUrl;}
			set {
				Movie.ImageUrl = value;
				RaisePropertyChanged (() => ImageUrl);
			}
		}

		public List<Movie> _similarMovies; 
		public List<Movie> SimilarMovies {
			get { return _similarMovies; }
			set {
				_similarMovies = value;
				RaisePropertyChanged (() => SimilarMovies);
			}
		}

		private IMvxCommand _playVideoCommand;
		public IMvxCommand PlayVideoCommand 
		{
			get {
				_playVideoCommand = _playVideoCommand ?? new MvxCommand (PlayVideo);
				return _playVideoCommand;
			}
		}

		private void PlayVideo ()
		{
			// todo: change this to play video 
			_alertService.AlertAsync(Config.ErrorMessages.ErrorMessageForPlayButton, Config.ErrorMessages.ErrorMessageHeading);
		}

		private MvxCommand<Movie> _showDetailViewCommand;
		public MvxCommand<Movie> ShowDetailViewCommand
		{
			get 
			{
				_showDetailViewCommand = _showDetailViewCommand ?? new MvxCommand<Movie> (ShowDetailView);
				return _showDetailViewCommand;
			}
		}

		void ShowDetailView(Movie movie)
		{
			ShowViewModel<MovieDetailViewModel>(movie);
		}

		private IMvxCommand _saveToFavoritesCommand;
		public IMvxCommand SaveToFavoritesCommand 
		{
			get {
				_saveToFavoritesCommand = _saveToFavoritesCommand ?? new MvxCommand (async () => await SaveToFavorites());
				return _saveToFavoritesCommand;
			}
		}

		private async Task SaveToFavorites ()
		{
			var movieMessage = new MovieMessage (this, Movie, !IsSavedToLocalDb);
			_messenger.Publish (movieMessage);

			// todo: save to db here and show a message to the user (animate and update button text)
			if (IsSavedToLocalDb) 
			{
				await _localDataService.Delete (this.Movie.Id);
				IsSavedToLocalDb = false;
			} 
			else 
			{
				await _localDataService.Save (this.Movie);
				IsSavedToLocalDb = true;
			}
		}

		public bool _isSavedToLocalDb = false;
		public bool IsSavedToLocalDb {
			get { return _isSavedToLocalDb; }
			set {
				_isSavedToLocalDb = value;
				RaisePropertyChanged (() => IsSavedToLocalDb);
				UpdateSaveToFavoritesButtonText ();
			}
		}

		public string _saveToFavoritesButtonText = Config.SaveToFavoriteButtonText;
		public string SaveToFavoritesButtonText
		{
			get { return _saveToFavoritesButtonText; }
			set {
				_saveToFavoritesButtonText = value;
				RaisePropertyChanged (() => SaveToFavoritesButtonText);
			}
		}

		void UpdateSaveToFavoritesButtonText ()
		{
			SaveToFavoritesButtonText = IsSavedToLocalDb ? Config.RemoveFromFavoriteButtonText : Config.SaveToFavoriteButtonText;
		}
	}
}
	