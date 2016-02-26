using System;
using UIKit;
using CoreGraphics;
using Foundation;

namespace MoviesExploerer.iOS
{
	public class HeaderView : UICollectionReusableView
	{
		UILabel HeaderLabel; 

		[Export ("initWithFrame:")]
		public HeaderView (CGRect frame) : base (frame)
		{
			HeaderLabel = new UILabel (frame);

			HeaderLabel.TextColor = UIColor.White;
			HeaderLabel.Font = UIFont.BoldSystemFontOfSize (22);

			AddSubview (HeaderLabel);
		}

		public void SetHeaderText(string title)
		{
			HeaderLabel.Text = title;
			SetNeedsDisplay ();
		}
	}
}

