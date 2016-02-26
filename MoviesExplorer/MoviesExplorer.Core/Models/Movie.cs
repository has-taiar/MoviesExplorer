using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace MoviesExplorer.Core
{
	public class Movie : BaseModel
	{
		public Movie ()
		{
			SimilarMovies = new List<Movie> ();
		}

		public string Title { get; set;}
		public string Description { get; set;}
		public int VotesCount { get; set;}
		public double VotesAverage {get;set;}
		public string ReleaseDate { get; set;}
		public string ImageUrl {get;set;}

		[Ignore] // will not be saved to db
		public List<Movie> SimilarMovies {get;set;}
	}
}

