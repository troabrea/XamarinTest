using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SQLite.Net.Async;
using System.Threading.Tasks;

                     
namespace FormsTestApp
{

	public class SqlDataService : IDataService
	{
		private SQLiteAsyncConnection db;
		public SqlDataService()
		{
			db = DependencyService.Get<ISqlLite>().GetConnection();
			db.CreateTableAsync<Tarea>();
		}

		public Task DeleteTarea(Tarea tarea)
		{
			return db.DeleteAsync(tarea);
		}

		public async Task<IEnumerable<Tarea>> GetTareas()
		{
			var tareas = await db.Table<Tarea>().ToListAsync();
			if (tareas.Count == 0)
			{
				var nuevasTaras = new Tarea[] {
					new Tarea { Descripcion = "Conocer Xamarin", Completada = true},
					new Tarea { Descripcion = "Aprender Xamarin", Completada = false},
					new Tarea { Descripcion = "Desarrollar en Xamarin", Completada = false}
				};
				await db.InsertAllAsync(nuevasTaras);
				tareas = await db.Table<Tarea>().ToListAsync();
			}
			return tareas;
		}

		public Task InsertTarea(Tarea tarea)
		{
			return db.InsertAsync(tarea);
		}

		public Task UpdateTarea(Tarea tarea)
		{
			return db.UpdateAsync(tarea);
		}
	}

	public class DataService : IDataService
	{
		public DataService()
		{
		}

		public Task DeleteTarea(Tarea tarea)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Tarea>> GetTareas()
		{
			return await Task.Run(() =>
		   {
			   var tareas = new Tarea[] {
				new Tarea { Descripcion = "Conocer Xamarin", Completada = true},
				new Tarea { Descripcion = "Aprender Xamarin", Completada = false},
				new Tarea { Descripcion = "Desarrollar en Xamarin", Completada = false}
		  	 };
			   return tareas;
		   });
		}

		public Task InsertTarea(Tarea tarea)
		{
			throw new NotImplementedException();
		}

		public Task UpdateTarea(Tarea tarea)
		{
			throw new NotImplementedException();
		}
	}
}
