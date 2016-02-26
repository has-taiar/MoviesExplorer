using System;
using NUnit.Framework;
using MoviesExploerer.iOS;
using MoviesExplorer.Core;
using System.Collections.Generic;

namespace MoviesExplorer.iOS.UnitTests
{
	[TestFixture]
	public class TypeMapperTest
	{
		private readonly ITypeMapper _typeMapper = new TypeMapper();

		[Test]
		public void Map_WhenPassingValidDto_ShouldBeMappedToDomainObjects ()
		{
			var dtos = GetDtosForTest ();
			MovieDto dto = dtos [0];
				
			var movie = _typeMapper.MapTo<Movie> (dto);

			AssertThatMovieWasMappedCorrectly (dto, movie);
		}

		[Test]
		public void Map_WhenPassingNull_ShouldBeReturnNull ()
		{
			var movie = _typeMapper.MapTo<Movie> (null);

			Assert.IsNull (movie, "The returned object should be null but it should not throw any exception.");
		}

		[Test]
		public void Map_WhenPassingListOfDtos_ShouldBeReturnListOfDomainObjects ()
		{
			var dtos = GetDtosForTest ();

			var movies = _typeMapper.MapList<List<MovieDto>, List<Movie>> (dtos);

			Assert.IsNotNull (movies);
			AssertThatMovieWasMappedCorrectly (dtos [0], movies [0]);
			AssertThatMovieWasMappedCorrectly (dtos [1], movies [1]);
		}

		static void AssertThatMovieWasMappedCorrectly (MovieDto dto, Movie movie)
		{
			Assert.IsNotNull (movie);
			Assert.AreEqual (dto.id, movie.Id);
			Assert.AreEqual (dto.title, movie.Title);
			Assert.AreEqual (dto.overview, movie.Description);
			Assert.AreEqual (dto.poster_path, movie.ImageUrl);
			Assert.AreEqual (dto.release_date, movie.ReleaseDate);
			Assert.AreEqual (dto.vote_count, movie.VotesCount);
			Assert.AreEqual (dto.vote_average, movie.VotesAverage);
		}

		private List<MovieDto> GetDtosForTest ()
		{
			var dto1 = new MovieDto {
				id = 1,
				title = "The Blind Side",
				overview = "some overview will go here",
				release_date = "01/01/2015",
				vote_count = 233,
				vote_average = 7.8, 
				poster_path = "/abc.jpg"
			};

			var dto2 = new MovieDto {
				id = 2,
				title = "Star War",
				overview = "some overview of Star War",
				release_date = "01/01/2014",
				vote_count = 2334,
				vote_average = 9.8, 
				poster_path = "/abcsdfsf.jpg"
			};

			return new List<MovieDto>{ dto1, dto2 };
		}
	}
}

