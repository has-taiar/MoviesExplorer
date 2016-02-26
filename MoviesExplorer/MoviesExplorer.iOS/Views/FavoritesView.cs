using System;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using MoviesExplorer.Core;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using Foundation;

namespace MoviesExploerer.iOS
{
	public class FavoritesView : MvxTableViewController
	{
		public FavoritesView () : base (UITableViewStyle.Plain)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			SetBindings ();

			SetupNavBar ();
		}

		private void SetBindings ()
		{
			RefreshControl = new MvxUIRefreshControl();
			this.View.BackgroundColor = RefreshControl.BackgroundColor = UIColor.DarkGray;
			RefreshControl.TintColor = UIColor.White;
			TableView.Add (RefreshControl);

			var source = new FavoritesTableTableViewSource(ViewModel, TableView, "FavoriteTableViewCell");
			TableView.Source = source;
			TableView.RowHeight = 100; // (nfloat) Config.FavoritesTableRowHeight; // TODO: calc this value dynamically based on screen bounds
			TableView.SeparatorColor = UIColor.Orange;

			var set = this.CreateBindingSet<FavoritesView, FavoritesViewModel>();
			set.Bind(source).For(s => s.ItemsSource).To(vm => vm.Movies);
			set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.ShowDetailViewCommand);
			set.Bind (RefreshControl).For (r => r.IsRefreshing).To (vm => vm.IsLoading);
			set.Bind (RefreshControl).For (r => r.Message).To (vm => vm.BusyMessage);
			set.Bind (RefreshControl).For (r => r.RefreshCommand).To (vm => vm.PullToRefreshCommand);
			set.Apply();

			TableView.ReloadData ();
		}

		private void SetupNavBar ()
		{
			NavBarHelper.SetAppTitle (this.NavigationItem, Config.FavoritesScreenTitle);
			NavBarHelper.SetRightNavButton (this.NavigationItem, Config.CloseButtonIconName, (sender, args) => {
				ViewModel.Close ();
			});
		}

		public new FavoritesViewModel ViewModel 
		{
			get { return base.ViewModel as FavoritesViewModel; }
		}

		MvxUIRefreshControl RefreshControl;
	}
}

