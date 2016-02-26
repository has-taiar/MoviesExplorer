using System;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesExplorer.Core
{
	public class HomeViewModel : BaseViewModel 
	{
		private readonly IMoviesApiService _movieApiService;

		public HomeViewModel (ILogger logger, IAppTracker appTracker, IMoviesApiService moviesApiService) : base (logger, appTracker)
		{
			_movieApiService = moviesApiService;

			Movies = new List<MoviesSectionViewModel> {
				new MoviesSectionViewModel("Popular", new List<Movie>(), Logger, appTracker),
				new MoviesSectionViewModel("Top Rated", new List<Movie>(), Logger, appTracker),
				new MoviesSectionViewModel("Now Playing", new List<Movie>(), Logger, appTracker)
			};
		}

		public async override void Start()
		{
			await LoadData ();
		}

		public void ShowFavorites ()
		{
			this.ShowViewModel<FavoritesViewModel> ();
		}

		public async Task LoadData ()
		{
			try 
			{
				SetLoadingFlag (true);
				Movies = await _movieApiService.GetMovies ();
				SetLoadingFlag (false);
			}
			catch(Exception e) 
			{
				Logger.Log (e);
			}
		}

		private List<MoviesSectionViewModel> _movies;
		public List<MoviesSectionViewModel> Movies 
		{
			get{ return _movies; }
			set { _movies = value; RaisePropertyChanged(() => Movies);}
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
	}
}

