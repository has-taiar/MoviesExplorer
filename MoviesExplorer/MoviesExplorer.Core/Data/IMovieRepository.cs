using System.Collections.Generic;

namespace MoviesExplorer.Core
{
	public interface IMovieRepository
	{
		Movie GetMovie (int id);
		List<Movie> GetAllMovies();
		OperationResult Save (Movie movie);
		OperationResult Delete (int id);
	}
}

