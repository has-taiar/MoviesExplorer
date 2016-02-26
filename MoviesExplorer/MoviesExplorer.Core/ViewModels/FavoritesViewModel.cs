using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using System.Linq;
using System.Collections.ObjectModel;
using MvvmCross.Platform.Core;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoviesExplorer.Core
{
	public class FavoritesViewModel : BaseViewModel, IRemove
	{
		private readonly ILocalDataService _localDataService;
		private readonly IMvxMessenger _messenger;
		private readonly MvxSubscriptionToken _token;

		public FavoritesViewModel (ILogger logger, IAppTracker tracker, ILocalDataService localDataService, IMvxMessenger messenger) : base(logger, tracker)
		{
			_messenger = messenger;
			_localDataService = localDataService;
			_token = _messenger.Subscribe<MovieMessage> (OnFavoritesListUpdated);
		}

		public async void Init()
		{
			await LoadData();
		}

		private  void OnFavoritesListUpdated (MovieMessage message)
		{
			if (Movies != null && Movies.Any (m => m.Id == message.Movie.Id) && !message.IsAdded) 
			{
				RemoveMovieFromList (message.Movie.Id);
			} 
			else 
			{
				if (Movies != null && message.IsAdded) 
				{
					Movies.Add (message.Movie);
					Movies = Movies.ToList ();
				}
				else if (message.IsAdded) 
					Movies = new List<Movie>{message.Movie};
			}
		}

		void RemoveMovieFromList (int movieId)
		{
			Movies.RemoveAll (m => m.Id == movieId);
			Movies = Movies.ToList (); // todo: change this list to ObservableList so that Mvvmcross picks up the collection change
		}

		private ICommand _removeCommand;
		public ICommand RemoveCommand {
			get 
			{
				_removeCommand = _removeCommand ?? new MvxCommand<int> (async (id) => await DeleteMovie(id));
				return _removeCommand;
			}
		}

		private async Task DeleteMovie (int index)
		{
			if (this.Movies.Count <= index)
				return;
			
			var movie = this.Movies [index];
			await _localDataService.Delete (movie.Id);
			RemoveMovieFromList (movie.Id);
		}

		public void ShowMovie (Movie movie)
		{
			this.ShowViewModel<MovieDetailViewModel> (movie);
		}

		private IMvxCommand _showDetailViewCommand;
		public IMvxCommand ShowDetailViewCommand {
			get 
			{ 
				_showDetailViewCommand = _showDetailViewCommand ?? new MvxCommand<Movie> (ShowMovie);
				return _showDetailViewCommand;
			}
		}

		public List<Movie> _movies;
		public List<Movie> Movies
		{
			get { return _movies; }
			set {
				_movies = value;
				RaisePropertyChanged (() => Movies);
			}
		}

		private MvxCommand _pullToRefreshCommand;

		public MvxCommand PullToRefreshCommand {
			get{ _pullToRefreshCommand = _pullToRefreshCommand ?? new MvxCommand (async () => await PullToRefresh());
				return _pullToRefreshCommand;
			}
		}

		private async Task PullToRefresh ()
		{
			await LoadData ();
		}

		async Task LoadData ()
		{
			try 
			{
				SetLoadingFlag (true);
				Movies = await _localDataService.GetAllMovies();
				SetLoadingFlag (false);
			}
			catch(Exception e) 
			{
				Logger.Log (e);
			}
		}
	}

	public interface IRemove
	{
		ICommand RemoveCommand { get; }
	}
}

