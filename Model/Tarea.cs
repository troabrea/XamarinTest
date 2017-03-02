using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite.Net.Attributes;

namespace FormsTestApp
{

	public class Tarea : ObservableObject
	{
		public Tarea()
		{
		}

		[PrimaryKey, AutoIncrement]
		public Int64 Id { get; set; }

		public string Descripcion { get; set;}

		public Boolean Completada { get; set; }
	}
}
