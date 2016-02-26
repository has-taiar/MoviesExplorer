using System;
using NUnit.Framework;
using Moq;

namespace MoviesExplorer.Core.UnitTests
{
	[TestFixture]
	public class LocalApiServicesTest
	{
		[Test]
		public void GetMovie_IfItFails_ShouldRetryInternally ()
		{
			var mockRepository = new Mock<IMovieRepository>();

			mockRepository.Setup(framework => framework.GetMovie(1)).Throws(new Exception("forced to fail"));

			var service = new LocalDataService (new DebugLogger (), mockRepository.Object);

			var movie = service.GetMovie (1).Result;

			// Verify that our local data service retried for 3 times
			mockRepository.Verify(framework => framework.GetMovie(1), Times.Exactly(Config.MaxNoOfRetrialAllowed));
		}
			
		[Test]
		public void GetMovies_WhenExceptionsOccure_TheyShouldBeLogged ()
		{
			var mockRepository = new Mock<IMovieRepository>();
			var mockLogger = new Mock<ILogger> ();
			var exception = new Exception ("forced to fail");

			mockLogger.Setup(framework => framework.Log(exception));
			mockRepository.Setup(framework => framework.GetAllMovies()).Throws(exception);

			var service = new LocalDataService (mockLogger.Object, mockRepository.Object);

			var movie = service.GetAllMovies().Result;

			// Verify that our local data service retried for 3 times
			mockLogger.Verify(framework => framework.Log(exception), Times.Exactly(Config.MaxNoOfRetrialAllowed));
		}
			
		[Test]
		public void IsFavorite_WhenMovieIsSavedInFavorites_ShouldReturnTrue ()
		{
			var mockRepository = new Mock<IMovieRepository>();

			mockRepository.Setup(framework => framework.GetMovie(1)).Returns(new Movie{Id=1});

			var service = new LocalDataService (new DebugLogger (), mockRepository.Object);

			var isFirstMovieFavorite = service.IsInFavorites (1).Result;

			Assert.IsTrue (isFirstMovieFavorite);

		}

		[Test]
		public void IsFavorite_WhenMovieIsNotSavedInFavorites_ShouldReturnFalse ()
		{
			var mockRepository = new Mock<IMovieRepository>();

			mockRepository.Setup(framework => framework.GetMovie(1)).Returns(new Movie{Id=1});

			var service = new LocalDataService (new DebugLogger (), mockRepository.Object);

			var isSecondMovieFavorite = service.IsInFavorites (2).Result;

			Assert.IsFalse (isSecondMovieFavorite);
		}
	}
}

