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
	[Register ("MovieCollectionViewCell")]
	partial class MovieCollectionViewCell
	{
		[Outlet]
		UIKit.UIImageView MovieImage { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (MovieImage != null) {
				MovieImage.Dispose ();
				MovieImage = null;
			}
		}
	}
}
