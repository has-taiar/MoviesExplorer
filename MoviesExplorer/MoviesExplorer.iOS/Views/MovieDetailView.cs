using System;

using UIKit;
using MoviesExplorer.Core;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using System.Drawing;
using PatridgeDev;

namespace MoviesExploerer.iOS
{
	public partial class MovieDetailView : BaseViewController
	{
		private readonly MvxImageViewLoader ImageLoader;
		private readonly MvxImageViewLoader BackgroundImageLoader;

		public MovieDetailView () : base ("MovieDetailView", null)
		{
			ImageLoader = new MvxImageViewLoader (() => MainMovieImage);
			BackgroundImageLoader = new MvxImageViewLoader (() => BackgroundImage);
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			SetupNavigationBar ();

			InitRatingView ();

			SetupBlurBackgroundImageEffect ();
		}
			
		void SetupBlurBackgroundImageEffect ()
		{
			this.MainScrollView.RemoveFromSuperview ();
			this.BlurBackgroundEffectView.Add (this.MainScrollView);
		}
			
		protected override void SetupBinding ()
		{
			this.SimilarMoviesCollectionView.RegisterNibForCell (MovieCollectionViewCell.Nib, MovieCollectionViewCell.Key);
			this.SimilarMoviesCollectionView.CollectionViewLayout = new MoviesCollectionViewFlowLayout(Config.SmallCollectionViewCellWidth, Config.SmallCollectionViewCellHeight, UICollectionViewScrollDirection.Horizontal);
			this.SimilarMoviesCollectionView.BackgroundColor = UIColor.Clear;
			var source = new MoviesCollectionDataSource (SimilarMoviesCollectionView, MovieCollectionViewCell.Key);
			SimilarMoviesCollectionView.Source = source;

			var bindingSet = this.CreateBindingSet<MovieDetailView, MovieDetailViewModel>();
			bindingSet.Bind(PlayVideoButton).To(vm => vm.PlayVideoCommand);
			bindingSet.Bind(SaveToFavoritesButton).To(vm => vm.SaveToFavoritesCommand);
			bindingSet.Bind (SaveToFavoritesButton).For ("Title").To (vm => vm.SaveToFavoritesButtonText);
			bindingSet.Bind(ImageLoader).To(vm => vm.ImageUrl);
			bindingSet.Bind(BackgroundImageLoader).To(vm => vm.ImageUrl);
			bindingSet.Bind(MovieTitleLabel).To(vm =>  vm.MovieTitle);
			bindingSet.Bind(ReleaseDateLabel).To(vm => vm.ReleaseDate);
			bindingSet.Bind(VotesCountLabel).To(vm => vm.VotesCount);
			bindingSet.Bind(MovieDescriptionTextView).To(vm => vm.MovieDescription);
			bindingSet.Bind (source).To (vm => vm.SimilarMovies);
			bindingSet.Bind (source).For (s => s.SelectionChangedCommand).To (vm => vm.ShowDetailViewCommand);
			bindingSet.Apply();


			SimilarMoviesCollectionView.ReloadData();
		}

		private void InitRatingView ()
		{
			var holderFrame = this.MovieRatingViewHolder.Frame;
			var frame = new RectangleF (0,0, (float)holderFrame.Width, (float)holderFrame.Height);
			var rating = new RatingView (frame, ViewModel.AverageRating);
			this.MovieRatingViewHolder.Add (rating);
		}

		private void SetupNavigationBar ()
		{
			NavBarHelper.SetAppTitle (this.NavigationItem, Config.AppTitle);
			NavBarHelper.SetRightNavButton (this.NavigationItem, Config.CloseButtonIconName, (sender, args) => {
				ViewModel.Close ();
			});
		}

		private new MovieDetailViewModel ViewModel 
		{
			get { return base.ViewModel as MovieDetailViewModel; }
		}
	}
}


