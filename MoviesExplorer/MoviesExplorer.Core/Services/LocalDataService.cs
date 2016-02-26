using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MoviesExplorer.Core
{
	public class LocalDataService : BaseDataService, ILocalDataService
	{
		private readonly IMovieRepository _movieRepository; 

		public LocalDataService (ILogger logger, IMovieRepository movieRepository) : base(logger)
		{
			_movieRepository = movieRepository;
		}

		#region ILocalDataService implementation

		public async Task<Movie> GetMovie (int id)
		{
			Movie movie = await RunOperationWithRetrialOnFailure<Movie> (() =>  Task.Run (() => {
				return _movieRepository.GetMovie (id);
			}));

			return movie;
		}

		public async Task<List<Movie>> GetAllMovies ()
		{
			var movies = await RunOperationWithRetrialOnFailure<List<Movie>> (() =>  Task.Run (() => {
				return _movieRepository.GetAllMovies();
			}));

			return movies;
		}

		public async Task<OperationResult> Save (Movie movie)
		{
			var result = await RunOperationWithRetrialOnFailure<OperationResult> (() =>  Task.Run (() => {
				return _movieRepository.Save(movie);
			}));

			return result;
		}

		public async Task<OperationResult> Delete (int id)
		{
			var result = await RunOperationWithRetrialOnFailure<OperationResult> (() =>  Task.Run (() => {
				return _movieRepository.Delete(id);
			}));

			return result;
		}

		public async Task<bool> IsInFavorites (int id)
		{
			var result = await RunOperationWithRetrialOnFailure<Movie> (() =>  Task.Run (() => {
				return _movieRepository.GetMovie(id);
			}));

			return result != null; // if we have it local then it is favorite
		}

		#endregion
	}
}

