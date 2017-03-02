using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace FormsTestApp
{
	public class ClientesViewModel : ViewModelBase
	{

		public ObservableCollection<Cliente> Clientes { get; set;}

		private IRemoteService srv;

		public ClientesViewModel(IRemoteService _srv)
		{
			srv = _srv;
		}

		public Boolean IsBusy { get; set; }

		protected override void ViewIsAppearing(object sender, EventArgs e)
		{
			base.ViewIsAppearing(sender, e);
			LoadData();
		}


		public async void LoadData()
		{
			try
			{
				IsBusy = true;
				Clientes = new ObservableCollection<Cliente>(await srv.GetClientes());
			}
			finally
			{
				IsBusy = false;
			}
		}

		public System.Windows.Input.ICommand RefreshCommand
		{
			get
			{
				return new Command(() =>
				{
					LoadData();
				}

				);
			}
		}
	}
}
