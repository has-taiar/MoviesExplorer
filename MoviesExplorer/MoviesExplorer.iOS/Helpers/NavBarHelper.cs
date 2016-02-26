using System;
using UIKit;
using MoviesExplorer.Core;

namespace MoviesExploerer.iOS
{
	public class NavBarHelper
	{
		public static void InitAppearance()
		{
			UINavigationBar.Appearance.BarTintColor = UIColor.Black;
			UINavigationBar.Appearance.TintColor = UIColor.White;
			var font = UIFont.FromName (Config.AppTitleCustomFontName, 32);
			UINavigationBar.Appearance.TitleTextAttributes  = new UIStringAttributes()
			{
				ForegroundColor = UIColor.Orange,
				Font = font
			};

			UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;
		}

		public static void SetAppTitle(UINavigationItem navItem, string title)
		{
			if (navItem != null) 
			{
				navItem.HidesBackButton = true;
				navItem.Title = LocalisationHelper.Localise(title);
			}
		}

		public static void SetRightNavButton (UINavigationItem navItem, string iconFileName, EventHandler handler)
		{
			if (navItem == null)
				return;	
			

			navItem.SetRightBarButtonItem( new UIBarButtonItem(UIImage.FromFile(iconFileName) , UIBarButtonItemStyle.Plain , handler), true);
		}
	}
}

