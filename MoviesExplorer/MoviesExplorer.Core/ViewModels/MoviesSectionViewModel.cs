using System;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;

namespace MoviesExplorer.Core
{
	public class MoviesSectionViewModel : BaseViewModel 
	{
		public MoviesSectionViewModel (string sectionName, List<Movie> movies, ILogger logger, IAppTracker tracker) : base(logger, tracker)
		{
			SectionName = sectionName;
			Movies = movies;
		}

		private string _sectionName;
		public string SectionName
		{
			get { return _sectionName; }
			set { _sectionName = value; RaisePropertyChanged(() => SectionName); }
		}

		private List<Movie> _movies;
		public List<Movie> Movies
		{ 
			get { return _movies; }
			set { _movies = value; RaisePropertyChanged(() => Movies); }
		}

		private MvxCommand<Movie> _showDetailViewCommand;
		public MvxCommand<Movie> ShowDetailViewCommand
		{
			get 
			{
				_showDetailViewCommand = _showDetailViewCommand ?? new MvxCommand<Movie> (ShowDetailView);
				return _showDetailViewCommand;
			}
		}

		void ShowDetailView(Movie movie)
		{
			ShowViewModel<MovieDetailViewModel>(movie);
		}
	}
}

