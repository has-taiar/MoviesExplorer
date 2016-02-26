using System;
using UIKit;

namespace MoviesExploerer.iOS
{
	public static class ViewCellDimensionCalculator
	{
		public static float GetFavoritesCellWidth()
		{
			var width = UIScreen.MainScreen.Bounds.Width / 3.8;
			return (float) width;
		}

		public static float GetFavoritesCellHeight()
		{
			return 165;
		}
	}
}

