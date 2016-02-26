using System;
using MvvmCross.iOS.Platform;
using UIKit;
using MoviesExplorer.Core;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using System.IO;
using Chance.MvvmCross.Plugins.UserInteraction;
using Chance.MvvmCross.Plugins.UserInteraction.Touch;

namespace MoviesExploerer.iOS
{
	public class Setup : MvxIosSetup
	{

		public Setup(MvxApplicationDelegate appDelegate, IMvxIosViewPresenter presenter) : base(appDelegate, presenter)
		{
		}

		#region implemention

		protected override MvvmCross.Core.ViewModels.IMvxApplication CreateApp ()
		{
			return new App ();
		}

		protected override MvvmCross.Platform.Platform.IMvxTrace CreateDebugTrace ()
		{
			return base.CreateDebugTrace ();
		}

		protected override void InitializeFirstChance ()
		{
			NavBarHelper.InitAppearance ();

			var azureAiLogger = new AzureAiLogger (Config.AzureAppInsightsKey);
			Mvx.RegisterSingleton<ILogger>(azureAiLogger);
			Mvx.RegisterSingleton<IAppTracker> (azureAiLogger);

			Mvx.RegisterSingleton<ITypeMapper> (new TypeMapper ());
			Mvx.RegisterSingleton<IDatabase> (new Database (this.LocalSQLiteDbPath));
			Mvx.RegisterType<INativeHttpMessageHandlerGenerator,NativeHttpMessageHandlerGenerator> (); 
			Mvx.RegisterType<IUserInteraction, UserInteraction> ();

			base.InitializeFirstChance ();
		}

		private readonly string  LocalSQLiteDbPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), Config.SQLiteDbFileName);

		#endregion
	}
}

