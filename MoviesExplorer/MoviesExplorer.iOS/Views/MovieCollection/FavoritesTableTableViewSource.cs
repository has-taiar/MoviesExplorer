using System;
using MvvmCross.Binding.iOS.Views;
using System.Windows.Input;
using UIKit;
using Foundation;
using MoviesExplorer.Core;
using System.Collections.Generic;
using MvvmCross.Binding.Bindings;

namespace MoviesExploerer.iOS
{
	public class FavoritesTableTableViewSource : MvxSimpleTableViewSource
	{
		private IRemove _viewModel;

		public FavoritesTableTableViewSource (IRemove viewModel, UITableView tableView, string nibName, string cellIdentifier = null) : base(tableView, nibName, cellIdentifier)
		{
			_viewModel = viewModel;
		}

		public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
		{
			return true;
		}

		public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
		{
			switch (editingStyle)
			{
				case UITableViewCellEditingStyle.Delete:
					_viewModel.RemoveCommand.Execute(indexPath.Row);
					break;
				case UITableViewCellEditingStyle.None:
					break;
			}
		}

		public override UITableViewCellEditingStyle EditingStyleForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return UITableViewCellEditingStyle.Delete;
		}

		public override bool CanMoveRow(UITableView tableView, NSIndexPath indexPath)
		{
			return false;
		}


	}
}

