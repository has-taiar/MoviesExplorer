using System;

using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using System.Drawing;
using System.Windows.Input;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoviesExplorer.Core;

namespace MoviesExploerer.iOS
{
	public class HomeView : MvxTableViewController
	{
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			SetupBinding ();

			SetupNavBar ();
		}

		private void SetupNavBar ()
		{
			NavBarHelper.SetAppTitle (this.NavigationItem, Config.AppTitle);
			NavBarHelper.SetRightNavButton (this.NavigationItem, "favorite", (sender, args) => {
				ViewModel.ShowFavorites();
			});
		}
				
		protected void SetupBinding ()
		{
			RefreshControl = new MvxUIRefreshControl();
			this.View.BackgroundColor = RefreshControl.BackgroundColor = UIColor.DarkGray;
			RefreshControl.TintColor = UIColor.Orange;
			TableView.Add (RefreshControl);

			var source = new MvxSimpleTableViewSource(TableView, "MoviesTableViewCell");
			TableView.Source = source;
			TableView.RowHeight = 198; // TODO: make the row height in the table dynamic 
			TableView.SeparatorColor = UIColor.Clear;

			var set = this.CreateBindingSet<HomeView, HomeViewModel>();
			set.Bind(source).For(s => s.ItemsSource).To(vm => vm.Movies);
			set.Bind (RefreshControl).For (r => r.IsRefreshing).To (vm => vm.IsLoading);
			set.Bind (RefreshControl).For (r => r.Message).To (vm => vm.BusyMessage);
			set.Bind (RefreshControl).For (r => r.RefreshCommand).To (vm => vm.PullToRefreshCommand);
			set.Apply();

			TableView.ReloadData ();
		}
			
		private new HomeViewModel ViewModel
		{
			get { return base.ViewModel as HomeViewModel; }
		}

		MvxUIRefreshControl RefreshControl;
	}


}


