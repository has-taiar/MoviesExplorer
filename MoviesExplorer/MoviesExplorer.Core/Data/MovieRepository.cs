using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MoviesExplorer.Core
{
	public class MovieRepository : RepositoryBase, IMovieRepository
	{
		public MovieRepository (IDatabase db) : base(db)
		{
		}

		#region IMovieRepository implementation

		public Movie GetMovie (int id)
		{
			lock (LocalDbConnection) 
			{
				string query = $"SELECT * from {typeof(Movie).Name} WHERE Id = ? ";
				var results = LocalDbConnection.Query<Movie> (query, id);
				return results.FirstOrDefault ();
			}

		}

		public List<Movie> GetAllMovies ()
		{
			lock (LocalDbConnection) {
				string query = $"SELECT * from {typeof(Movie).Name}";
				var results = LocalDbConnection.Query<Movie> (query);
				return results;
			}
		}

		public OperationResult Save (Movie movie)
		{
			lock (LocalDbConnection) {
				
				var exists = GetMovie (movie.Id);
				if (exists != null) {
					LocalDbConnection.Update (movie);
				} else {
					LocalDbConnection.Insert (movie);
				}

				return new OperationResult (true, string.Empty);
			}
		}

		public OperationResult Delete (int id)
		{
			lock (LocalDbConnection) {
				string query = $"DELETE from {typeof(Movie).Name} WHERE Id = ? ";
				LocalDbConnection.ExecuteScalar (query, id);
				return new OperationResult(true, string.Empty);
			}
		}

		#endregion
	}
}

