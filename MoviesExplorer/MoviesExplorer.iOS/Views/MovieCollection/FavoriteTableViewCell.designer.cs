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
	[Register ("FavoriteTableViewCell")]
	partial class FavoriteTableViewCell
	{
		[Outlet]
		UIKit.UIImageView MainMovieImage { get; set; }

		[Outlet]
		UIKit.UILabel MovieTitleLabel { get; set; }

		[Outlet]
		UIKit.UIButton PlayButton { get; set; }

		[Outlet]
		UIKit.UILabel ReleaseDateValueLabel { get; set; }

		[Outlet]
		UIKit.UIButton RemoveButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (MainMovieImage != null) {
				MainMovieImage.Dispose ();
				MainMovieImage = null;
			}
			if (MovieTitleLabel != null) {
				MovieTitleLabel.Dispose ();
				MovieTitleLabel = null;
			}
			if (ReleaseDateValueLabel != null) {
				ReleaseDateValueLabel.Dispose ();
				ReleaseDateValueLabel = null;
			}
		}
	}
}
