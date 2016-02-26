using System;
using MvvmCross.Binding.iOS.Views;
using Foundation;
using UIKit;
using MoviesExplorer.Core;

namespace MoviesExploerer.iOS
{
	public class MoviesTableViewSource : MvxTableViewSource
	{
		private static readonly NSString moviesCellIdentifier = new NSString("MoviesCell");

		public MoviesTableViewSource(UITableView tableView) : base(tableView)
		{
			tableView.RegisterNibForCellReuse (UINib.FromName ("MoviesTableViewCell", NSBundle.MainBundle), moviesCellIdentifier);
		}

		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 140;// MoviesTableViewCell.GetCellHeight();
		}

		protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
		{
			return (UITableViewCell) TableView.DequeueReusableCell(moviesCellIdentifier, indexPath);
		}
	}
}

