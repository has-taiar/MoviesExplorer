using UIKit;
using System;
using MvvmCross.Platform;
using MoviesExplorer.Core;

namespace MoviesExploerer.iOS
{
	public class Application
	{
		static void Main (string[] args)
		{
			try 
			{
				UIApplication.Main (args, null, "AppDelegate");
			}
			catch(Exception e) 
			{
				Mvx.Resolve<ILogger> ().Log (e);
			}
		}
	}
}
