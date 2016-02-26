using System;
using SQLite;
using System.Collections.Generic;
using SQLite.Net;
using MoviesExplorer.Core;
using SQLite.Net.Platform.XamarinIOS;

namespace MoviesExploerer.iOS
{
	/// <summary>
	/// Generic class that helps our Repositories do all db-related tasks.
	/// </summary>
	public class Database : SQLiteConnection, IDatabase
	{
		public Database (string dbfile) : base(new SQLitePlatformIOS(), dbfile)
		{
			CreateTables ();
		}

		private void CreateTables ()
		{
			CreateTable<Movie> ();
		}

		public int ExecuteScalar (string query, params object[] args)
		{
			return ExecuteScalar<int> (query, args);
		}

		List<T> IDatabase.Query<T> (string query, params object[] args)
		{
			return Query<T> (query, args);
		}
	}
}
