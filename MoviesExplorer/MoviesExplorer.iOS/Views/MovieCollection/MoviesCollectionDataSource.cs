using System;
using MvvmCross.Binding.iOS.Views;
using MoviesExplorer.Core;
using UIKit;
using Foundation;
using System.Collections.Generic;

namespace MoviesExploerer.iOS
{
	public class MoviesCollectionDataSource : MvxCollectionViewSource
	{
		public MoviesCollectionDataSource (UICollectionView collectionView, NSString cellIdentifier)  : base (collectionView, cellIdentifier)
		{
		}

		public override nint GetItemsCount (UICollectionView collectionView, nint section)
		{
			return (nint) Movies?.Count;
		}

		public override nint NumberOfSections (UICollectionView collectionView)
		{
			return 1;
		}

		protected override UICollectionViewCell GetOrCreateCellFor (UICollectionView collectionView, NSIndexPath indexPath, object item)
		{
			return collectionView.DequeueReusableCell (DefaultCellIdentifier, indexPath) as MovieCollectionViewCell;
		}

		protected override object GetItemAt(NSIndexPath indexPath)
		{
			return Movies[indexPath.Row];
		}

		protected List<Movie> Movies 
		{ 
			get 
			{ 
				return base.ItemsSource as List<Movie> ?? new List<Movie>(); 
			} 
		}
	}
}

