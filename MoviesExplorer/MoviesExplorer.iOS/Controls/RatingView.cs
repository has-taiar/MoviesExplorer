using System;
using PatridgeDev;
using System.Drawing;
using UIKit;

namespace MoviesExploerer.iOS
{
	public class RatingView : PDRatingView
	{
		public RatingView (RectangleF frame, decimal averageRating) : base (frame, ratingConfig, averageRating/2)
		{
			this.UserInteractionEnabled = false;
		}

		private static RatingConfig ratingConfig = new RatingConfig (UIImage.FromBundle ("Stars/empty"), UIImage.FromBundle ("Stars/chosen"), UIImage.FromBundle ("Stars/filled"));
	}
}