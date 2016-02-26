using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MvvmCross.Platform;

namespace MoviesExplorer.Core
{
	public class MoviesApiService : BaseDataService, IMoviesApiService
	{
		private readonly IDataFetcher _dataFetecher;
		private readonly ITypeMapper _typeMapper;

		public MoviesApiService (ILogger logger, IDataFetcher dataFetecher, ITypeMapper typeMapper) : base(logger)
		{
			_dataFetecher = dataFetecher;
			_typeMapper = typeMapper;
		}

		public async Task<List<Movie>> GetSimilarMovies (int movieId)
		{
			string resourceUrl = $"{Config.ApiBaseUrl}/{movieId}/{Config.ApiResourceAddressForSimilarMovies}?{Config.ApiKeyQueryStringParamName}={Config.ApiKey}";
			var moviesListDto = await _dataFetecher.Fetch<MoviesListDto>(resourceUrl, null);
			var movies = _typeMapper.MapList<List<MovieDto>, List<Movie>>(moviesListDto?.results);
			return movies ?? new List<Movie>();
		}

		public async Task<List<MoviesSectionViewModel>> GetMovies ()
		{
			var topRated = await GetTopRatedMovies();
			var popular = await GetPopularMovies();
			var nowPlaying = await GetNowPlayingMovies();

			var result = new List<MoviesSectionViewModel> {
				new MoviesSectionViewModel (Config.TopRatedSectionTitle, topRated, Mvx.Resolve<ILogger>(), Mvx.Resolve<IAppTracker>()),
				new MoviesSectionViewModel (Config.PopularSectionTitle, popular, Mvx.Resolve<ILogger>(), Mvx.Resolve<IAppTracker>()),
				new MoviesSectionViewModel (Config.NowPlayingSectionTitle, nowPlaying, Mvx.Resolve<ILogger>(), Mvx.Resolve<IAppTracker>())
			};

			return result;
		}

		#region IMoviesApiService implementation

		private async Task<List<Movie>> GetTopRatedMovies ()
		{
			var topRated = await RunOperationWithRetrialOnFailure <List<Movie>> (GetTopRatedMoviesInternal);
			return topRated;
		}

		private async Task<List<Movie>> GetPopularMovies ()
		{
			var popular = await RunOperationWithRetrialOnFailure<List<Movie>> (GetPopularMoviesInternal);
			return popular;
		}

		private async Task<List<Movie>> GetNowPlayingMovies ()
		{
			var nowPlaying = await  RunOperationWithRetrialOnFailure<List<Movie>> (GetNowPlayingMoviesInternal);
			return nowPlaying;
		}

		async Task<List<Movie>> GetTopRatedMoviesInternal ()
		{
			string resourceUrl = $"{Config.ApiBaseUrl}/{Config.ApiResourceAddressForTopRated}?{Config.ApiKeyQueryStringParamName}={Config.ApiKey}";
			var moviesListDto = await _dataFetecher.Fetch<MoviesListDto>(resourceUrl, null);
			var movies = _typeMapper.MapList<List<MovieDto>, List<Movie>>(moviesListDto?.results);
			return movies;
		}

		async Task<List<Movie>> GetPopularMoviesInternal ()
		{
			string resourceUrl = $"{Config.ApiBaseUrl}/{Config.ApiResourceAddressForPopularMovies}?{Config.ApiKeyQueryStringParamName}={Config.ApiKey}";
			var moviesListDto = await _dataFetecher.Fetch<MoviesListDto>(resourceUrl, null);
			var movies = _typeMapper.MapList<List<MovieDto>, List<Movie>>(moviesListDto?.results);
			return movies;
		}

		async Task<List<Movie>> GetNowPlayingMoviesInternal ()
		{
			string resourceUrl = $"{Config.ApiBaseUrl}/{Config.ApiResourceAddressForNowPlaying}?{Config.ApiKeyQueryStringParamName}={Config.ApiKey}";
			var moviesListDto = await _dataFetecher.Fetch<MoviesListDto>(resourceUrl, null);
			var movies = _typeMapper.MapList<List<MovieDto>, List<Movie>>(moviesListDto?.results);
			return movies;
		}

		#endregion
	}
}

