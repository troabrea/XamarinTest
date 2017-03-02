using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FormsTestApp
{
	public class TareasViewModel : ViewModelBase
	{
		public ObservableCollection<Tarea> Tareas { get; set; }

		private IDataService db;
		public TareasViewModel( IDataService _db )
		{
			db = _db;
			Tareas = new ObservableCollection<Tarea>();
		}
		private Boolean NeedsRefresh = true;
		protected override void ViewIsAppearing(object sender, EventArgs e)
		{
			base.ViewIsAppearing(sender, e);
			if (NeedsRefresh)
			{
				LoadData();
				NeedsRefresh = false;
			}
		}

		public override void ReverseInit(object returnedData)
		{
			base.ReverseInit(returnedData);
			var tareaToDelete = (returnedData as Tarea);
			if (tareaToDelete != null)
			{
				Tareas.Remove(tareaToDelete);
			}
		}

		public async void LoadData()
		{
			Tareas.Clear();
			var tareas = new ObservableCollection<Tarea>(await db.GetTareas());
			foreach (var tarea in tareas)
			{
				Tareas.Add(tarea);
			}
		}

		private object _selectedTarea;
		public object SelectedTarea
		{
			get
			{
				return _selectedTarea;
			}

			set
			{
				_selectedTarea = value;
				if (_selectedTarea != null)
				{
					CoreMethods.PushPageModel<TareaDetalleViewModel>(_selectedTarea);
					SelectedTarea = null;
				}
			}
		}

		public System.Windows.Input.ICommand ToggleCompletedCommand
		{
			get
			{
				return new Command(async () =>
				{
					foreach (var tarea in Tareas)
					{
						tarea.Completada = !tarea.Completada;
						await db.UpdateTarea(tarea);
					}	
				}

				);
			}
		}

		public System.Windows.Input.ICommand AddTaskCommand
		{
			get
			{
				return new Command( async () =>
				{
					var text = $"Tarea - {Tareas.Count + 1}";
					var tarea = new Tarea { Descripcion = text, Completada = false };
					await db.InsertTarea(tarea);
					Tareas.Add(tarea);
					//
				}

				);
			}
		}

	}
}
