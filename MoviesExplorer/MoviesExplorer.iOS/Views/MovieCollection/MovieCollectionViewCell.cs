using System;

using Foundation;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using MoviesExplorer.Core;

namespace MoviesExploerer.iOS
{
	public partial class MovieCollectionViewCell : MvxCollectionViewCell
	{
		public static readonly NSString Key = new NSString ("MovieCollectionViewCell");
		public static readonly UINib Nib;
		private readonly MvxImageViewLoader _loader; 

		static MovieCollectionViewCell ()
		{
			Nib = UINib.FromName ("MovieCollectionViewCell", NSBundle.MainBundle);
		}

		public MovieCollectionViewCell (IntPtr handle) : base(string.Empty, handle)
		{
			_loader = new MvxImageViewLoader (() => MovieImage);

			this.DelayBind (() => {
				var binding = this.CreateBindingSet<MovieCollectionViewCell, Movie>();
				binding.Bind(_loader).To( movie => movie.ImageUrl);
				binding.Apply();
			});
		}
	}
}
