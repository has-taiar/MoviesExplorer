// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

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
			if (ReleaseDateValueLabel != null) {
				ReleaseDateValueLabel.Dispose ();
				ReleaseDateValueLabel = null;
			}

			if (MainMovieImage != null) {
				MainMovieImage.Dispose ();
				MainMovieImage = null;
			}

			if (MovieTitleLabel != null) {
				MovieTitleLabel.Dispose ();
				MovieTitleLabel = null;
			}

			if (PlayButton != null) {
				PlayButton.Dispose ();
				PlayButton = null;
			}

			if (RemoveButton != null) {
				RemoveButton.Dispose ();
				RemoveButton = null;
			}
		}
	}
}
