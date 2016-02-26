// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MoviesExploerer.iOS
{
	[Register ("MovieDetailView")]
	partial class MovieDetailView
	{
		[Outlet]
		UIKit.UIImageView BackgroundImage { get; set; }

		[Outlet]
		UIKit.UIVisualEffectView BlurBackgroundEffectView { get; set; }

		[Outlet]
		UIKit.UIImageView MainMovieImage { get; set; }

		[Outlet]
		UIKit.UIScrollView MainScrollView { get; set; }

		[Outlet]
		UIKit.UITextView MovieDescriptionTextView { get; set; }

		[Outlet]
		UIKit.UIView MovieRatingViewHolder { get; set; }

		[Outlet]
		UIKit.UILabel MovieTitleLabel { get; set; }

		[Outlet]
		UIKit.UIButton PlayVideoButton { get; set; }

		[Outlet]
		UIKit.UILabel ReleaseDateLabel { get; set; }

		[Outlet]
		UIKit.UIButton SaveToFavoritesButton { get; set; }

		[Outlet]
		UIKit.UICollectionView SimilarMoviesCollectionView { get; set; }

		[Outlet]
		UIKit.UILabel SimilarMoviesHeaderLabel { get; set; }

		[Outlet]
		UIKit.UILabel VotesCountLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (BackgroundImage != null) {
				BackgroundImage.Dispose ();
				BackgroundImage = null;
			}
			if (BlurBackgroundEffectView != null) {
				BlurBackgroundEffectView.Dispose ();
				BlurBackgroundEffectView = null;
			}
			if (MainMovieImage != null) {
				MainMovieImage.Dispose ();
				MainMovieImage = null;
			}
			if (MainScrollView != null) {
				MainScrollView.Dispose ();
				MainScrollView = null;
			}
			if (MovieDescriptionTextView != null) {
				MovieDescriptionTextView.Dispose ();
				MovieDescriptionTextView = null;
			}
			if (MovieRatingViewHolder != null) {
				MovieRatingViewHolder.Dispose ();
				MovieRatingViewHolder = null;
			}
			if (MovieTitleLabel != null) {
				MovieTitleLabel.Dispose ();
				MovieTitleLabel = null;
			}
			if (PlayVideoButton != null) {
				PlayVideoButton.Dispose ();
				PlayVideoButton = null;
			}
			if (ReleaseDateLabel != null) {
				ReleaseDateLabel.Dispose ();
				ReleaseDateLabel = null;
			}
			if (SaveToFavoritesButton != null) {
				SaveToFavoritesButton.Dispose ();
				SaveToFavoritesButton = null;
			}
			if (SimilarMoviesCollectionView != null) {
				SimilarMoviesCollectionView.Dispose ();
				SimilarMoviesCollectionView = null;
			}
			if (SimilarMoviesHeaderLabel != null) {
				SimilarMoviesHeaderLabel.Dispose ();
				SimilarMoviesHeaderLabel = null;
			}
			if (VotesCountLabel != null) {
				VotesCountLabel.Dispose ();
				VotesCountLabel = null;
			}
		}
	}
}
