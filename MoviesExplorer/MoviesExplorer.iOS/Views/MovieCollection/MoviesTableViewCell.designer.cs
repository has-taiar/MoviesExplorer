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
	[Register ("MoviesTableViewCell")]
	partial class MoviesTableViewCell
	{
		[Outlet]
		UIKit.UILabel HeaderLabel { get; set; }

		[Outlet]
		UIKit.UICollectionView MoviesCollectionView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (HeaderLabel != null) {
				HeaderLabel.Dispose ();
				HeaderLabel = null;
			}
			if (MoviesCollectionView != null) {
				MoviesCollectionView.Dispose ();
				MoviesCollectionView = null;
			}
		}
	}
}
