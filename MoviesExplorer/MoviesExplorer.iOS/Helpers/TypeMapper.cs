using System;
using MoviesExplorer.Core;
using AutoMapper;

namespace MoviesExploerer.iOS
{
	public class TypeMapper : ITypeMapper
	{
		private readonly IMapper _mapper;

		public TypeMapper ()
		{
			var config = RegisterMapping ();
			_mapper = config.CreateMapper ();
		}

		#region implementation

		public T MapList<TFrom, T> (TFrom sourceList)
		{
			if (sourceList == null)
				return default(T);
			
			var result = _mapper.Map<TFrom, T> (sourceList);
			return result;
		}

		public T MapTo<T>(object source)
		{
			if (source == null) 
				return default(T);

			var result = _mapper.Map<T> (source);	
			return result;
		}


		private MapperConfiguration RegisterMapping ()
		{
			var config = new MapperConfiguration (cfg => 
				cfg.CreateMap<MovieDto, Movie> ()
				.ForMember (dest => dest.Title, opt => opt.MapFrom (src => src.title))
				.ForMember (dest => dest.Description, opt => opt.MapFrom (src => src.overview))
				.ForMember (dest => dest.ReleaseDate, opt => opt.MapFrom (src => src.release_date))
				.ForMember (dest => dest.VotesCount, opt => opt.MapFrom (src => src.vote_count))
				.ForMember (dest => dest.VotesAverage, opt => opt.MapFrom (src => src.vote_average))
				.ForMember (dest => dest.ImageUrl, opt => opt.MapFrom (src => $"{Config.MoviePosterBaseUrl}{src.poster_path}"))
				.ForMember (dest => dest.Id, opt => opt.MapFrom (src => src.id))
				.ForMember (dest => dest.SimilarMovies, opt => opt.Ignore()) );
			
			
			config.AssertConfigurationIsValid();

			return config;
		}
		#endregion
	}
}

