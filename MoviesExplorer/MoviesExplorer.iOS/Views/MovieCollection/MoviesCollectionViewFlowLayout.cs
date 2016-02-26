using System;
using UIKit;
using System.Drawing;

namespace MoviesExploerer.iOS
{
	public class MoviesCollectionViewFlowLayout : UICollectionViewFlowLayout
	{
		public MoviesCollectionViewFlowLayout (float width, float height, UICollectionViewScrollDirection direction)
		{
			ItemSize = new SizeF (width, height);
			ScrollDirection = direction;
		}
	}
}

