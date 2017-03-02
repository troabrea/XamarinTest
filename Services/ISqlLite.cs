using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite.Net.Async;

namespace FormsTestApp
{

	public interface ISqlLite
	{
		SQLiteAsyncConnection GetConnection();
	}
	
}
