using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesExplorer.Core
{
	public interface ILocalDataService
	{
		Task<Movie> GetMovie (int id);
		Task<List<Movie>> GetAllMovies();
		Task<OperationResult> Save (Movie movie);
		Task<OperationResult> Delete (int id);
		Task<bool> IsInFavorites (int id);
	}
}

