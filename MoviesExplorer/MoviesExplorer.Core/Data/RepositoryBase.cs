using System;

namespace MoviesExplorer.Core
{
	public class RepositoryBase 
	{
		protected IDatabase LocalDbConnection;

		/// <summary>
		/// All repos take instance of IDatabase to separate the repo code from the internal 
		/// implementation of the SQLite (we can switch between SQLite.Net-PCL, SQLiteCipher, or SQLite.Net.Cipher)
		/// </summary>
		/// <param name="db">Db.</param>
		public RepositoryBase(IDatabase db)
		{
			LocalDbConnection = db;
		}
	}
}

