using System;

using Foundation;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using MoviesExplorer.Core;

namespace MoviesExploerer.iOS
{
	public partial class FavoriteTableViewCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString ("FavoriteTableViewCell");
		public static readonly UINib Nib;
		private readonly MvxImageViewLoader _loader; 

		static FavoriteTableViewCell ()
		{
			Nib = UINib.FromName ("FavoriteTableViewCell", NSBundle.MainBundle);
		}

		public FavoriteTableViewCell (IntPtr handle) : base (handle)
		{
			_loader = new MvxImageViewLoader (() => MainMovieImage);

			this.DelayBind (() => {
				var binding = this.CreateBindingSet<FavoriteTableViewCell, Movie>();
				binding.Bind(_loader).To( movie => movie.ImageUrl);
				binding.Bind(MovieTitleLabel).To( movie => movie.Title);
				binding.Bind(ReleaseDateValueLabel).To( movie => movie.ReleaseDate);
				binding.Apply();
			});
		}
	}
}
