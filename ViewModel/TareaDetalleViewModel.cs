using System;
using Xamarin.Forms;

namespace FormsTestApp
{
	public class TareaDetalleViewModel : ViewModelBase
	{
		public Tarea SelectedTarea { get; private set; }
		private IDataService db;
		public TareaDetalleViewModel( IDataService _db )
		{
			db = _db;
		}

		public override void Init(object initData)
		{
			base.Init(initData);
			SelectedTarea = (initData as Tarea);
		}


		public System.Windows.Input.ICommand SaveTareaCommand
		{
			get
			{
				return new Command(async () =>
				{
				await db.UpdateTarea(SelectedTarea);
				await CoreMethods.PopPageModel(null);
				}

				);
			}
		}

		public System.Windows.Input.ICommand DeleteTareaCommand
		{
			get
			{
				return new Xamarin.Forms.Command( async () =>
				{
					if (await CoreMethods.DisplayAlert("Confirme", "Seguro que desea borrar esta tarea?", "Si", "No"))
					{
						await db.DeleteTarea(SelectedTarea);
						await CoreMethods.PopPageModel(SelectedTarea);
					}
				}

				);
			}
		}
	}
}
