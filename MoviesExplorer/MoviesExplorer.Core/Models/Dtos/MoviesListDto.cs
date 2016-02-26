using System;
using System.Collections.Generic;

namespace MoviesExplorer.Core
{
	public class MoviesListDto
	{
		public MoviesListDto ()
		{
			results = new List<MovieDto> ();
		}

		public int page { get; set; }
		public List<MovieDto> results { get; set; }
	}
}
