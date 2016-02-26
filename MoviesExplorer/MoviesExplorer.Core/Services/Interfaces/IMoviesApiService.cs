using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesExplorer.Core
{
	public interface IMoviesApiService
	{
		Task<List<MoviesSectionViewModel>> GetMovies ();
		Task<List<Movie>> GetSimilarMovies (int movieId);
	}
}

