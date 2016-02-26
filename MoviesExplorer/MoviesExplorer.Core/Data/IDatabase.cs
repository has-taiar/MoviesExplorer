using System;
using System.Collections.Generic;

namespace MoviesExplorer.Core
{
	public interface IDatabase : IDisposable
	{
		int ExecuteScalar (string query, params object[] args);
		List<T> Query<T> (string query, params object[] args) where T : class, new();
		int Update (object obj);
		int Insert (object obj);
	}
}

