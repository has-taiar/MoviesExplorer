using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace MoviesExplorer.Core
{
	public class App : MvxApplication
	{
		public App ()
		{
			Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<HomeViewModel>());

			Mvx.RegisterType<IMovieRepository, MovieRepository> ();
			Mvx.RegisterType<IDataFetcher, DataFetcher>();
			Mvx.RegisterType<IMoviesApiService, MoviesApiService>();
			Mvx.RegisterType<ILocalDataService, LocalDataService>();
		}

	}
}

