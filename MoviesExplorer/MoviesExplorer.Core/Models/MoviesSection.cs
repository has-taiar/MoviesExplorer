using System;
using System.Collections.Generic;

namespace MoviesExplorer.Core
{
	public class MoviesSection
	{
		public MoviesSection (string title, List<Movie> movies)
		{
			Title = title; 
			Movies = movies ?? new List<Movie> ();
		}

		public string Title { get; set; }
		public List<Movie> Movies {get;set;}
	}
}

