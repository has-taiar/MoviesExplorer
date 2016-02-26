using System;
using Newtonsoft.Json;
using SQLite.Net.Attributes;

namespace MoviesExplorer.Core
{
	public class BaseModel : IModel
	{
	    [PrimaryKey]
        public virtual int Id { get; set; }
	}
}

