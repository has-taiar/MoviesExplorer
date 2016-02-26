using System;

using Foundation;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using MoviesExplorer.Core;
using System.Collections.Generic;

namespace MoviesExploerer.iOS
{
	public partial class MoviesTableViewCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString ("MoviesTableViewCell");
		public static readonly UINib Nib;

		static MoviesTableViewCell ()
		{
			Nib = UINib.FromName ("MoviesTableViewCell", NSBundle.MainBundle);
		}

		public MoviesTableViewCell (IntPtr handle) : base (handle)
		{

			this.DelayBind (() => {

				MoviesCollectionView.RegisterNibForCell (MovieCollectionViewCell.Nib, MovieCollectionViewCell.Key);
				var source = new MoviesCollectionDataSource (MoviesCollectionView, MovieCollectionViewCell.Key);
				MoviesCollectionView.Source = source;
				MoviesCollectionView.CollectionViewLayout = new MoviesCollectionViewFlowLayout(Config.LargeCollectionViewCellWidth, Config.LargeCollectionViewCellHeight,  UICollectionViewScrollDirection.Horizontal);
	
				this.CreateBinding(source).To<MoviesSectionViewModel>(vm => vm.Movies).Apply();
				this.CreateBinding(HeaderLabel).To<MoviesSectionViewModel>(vm => vm.SectionName).Apply();
				this.CreateBinding(source).For(s => s.SelectionChangedCommand).To<MoviesSectionViewModel>(vm => vm.ShowDetailViewCommand).Apply();
	
				MoviesCollectionView.ReloadData();
			});
		}
	}
}



































