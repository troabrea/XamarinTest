using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite.Net.Async;

namespace FormsTestApp
{

	public interface IDataService
	{
		Task<IEnumerable<Tarea>> GetTareas();
		Task InsertTarea(Tarea tarea);
		Task UpdateTarea(Tarea tarea);
		Task DeleteTarea(Tarea tarea);
	}
	
}
