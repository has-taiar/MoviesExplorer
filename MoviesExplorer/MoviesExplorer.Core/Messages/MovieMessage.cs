using System;
using MvvmCross.Plugins.Messenger;

namespace MoviesExplorer.Core
{
	public class MovieMessage : MvxMessage
	{
		public MovieMessage (object sender, Movie movie, bool added) : base(sender)
		{
			Movie= movie;
			IsAdded = added;
		}

		public Movie Movie {get;set;}
		public bool IsAdded { get; set; }
	}
}

