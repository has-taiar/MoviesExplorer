using System;
using System.Collections.Generic;

namespace MoviesExplorer.Core
{
	public class MovieDto
	{
		public MovieDto ()
		{
		}

		public string poster_path {get;set;}
		public string overview {get;set;}
		public string release_date {get;set;}
		public int id {get;set;}
		public string title {get;set;}
		public int vote_count {get;set;}
		public double vote_average {get;set;}
	}

}

