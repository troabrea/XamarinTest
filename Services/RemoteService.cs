using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite.Net.Async;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace FormsTestApp
{
	public class RemoteService : IRemoteService
	{
		private HttpClient httpClient;
		public RemoteService()
		{
			httpClient = new HttpClient();
		}

		public async Task<IEnumerable<Cliente>> GetClientes()
		{
			var jsonText = await httpClient.GetStringAsync("http://70.35.197.123/LogiTrackApi/api/Customers");
			var result = JsonConvert.DeserializeObject<IEnumerable<Cliente>>(jsonText);
			return result;
		}
	}
	
}
