using System;
using NUnit.Framework;
using MoviesExplorer.Core;
using MoviesExploerer.iOS;
using System.IO;

namespace MoviesExplorer.iOS.UnitTests
{
	[TestFixture]
	public class MovieRepositoryTest
	{
		private IMovieRepository _movieRepository;
		private readonly string  _testLocalSQLiteDbPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), "testdb.db3");
		private IDatabase _database;

		[SetUp]
		public void Setup()
		{
			_database = new Database (_testLocalSQLiteDbPath);
			_movieRepository = new MovieRepository (_database);
		}

		[TearDown]
		public void TearDown()
		{
			_database.Dispose ();
			_database = null;
			_movieRepository = null;

			if (File.Exists (_testLocalSQLiteDbPath))
				File.Delete (_testLocalSQLiteDbPath);
		}

		[Test]
		public void GetMovieById ()
		{
			var movie = new Movie{ Id = 1, Title = "Star Wars" };
			_movieRepository.Save (movie);

			var result = _movieRepository.GetMovie (1);

			Assert.AreEqual (movie.Id, result.Id);
			Assert.AreEqual (movie.Title, result.Title);
		}

		[Test]
		public void GetMovieAllMovies ()
		{
			var movie = new Movie{ Id = 2, Title = "Star Wars 2" };
			_movieRepository.Save (movie);

			var movies = _movieRepository.GetAllMovies ();

			Assert.IsNotNull (movies);
			Assert.IsTrue (movies.Count > 0);
		}

		[Test]
		public void DeleteMovie ()
		{
			var movie = new Movie{ Id = 3, Title = "Star Wars 3" };
			_movieRepository.Save (movie);

			var result = _movieRepository.Delete (movie.Id);

			Assert.IsTrue (result.IsSuccessful);

			var deleted = _movieRepository.GetMovie (movie.Id);
			Assert.IsNull (deleted);
		}
	}
}

