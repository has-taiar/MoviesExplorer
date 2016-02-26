using System;

namespace MoviesExplorer.Core
{
	public interface ITypeMapper 
	{
		T MapTo<T>(object from);
		T MapList<TFrom, T>(TFrom sourceList);
	}
}

