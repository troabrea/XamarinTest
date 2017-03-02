using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite.Net.Async;
using System.Net.Http;
using Newtonsoft.Json;

namespace FormsTestApp
{
	

	public interface IRemoteService
	{
		Task<IEnumerable<Cliente>> GetClientes();
	}
	
}
