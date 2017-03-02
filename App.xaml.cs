using Xamarin.Forms;
using FreshMvvm;

namespace FormsTestApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			FreshIOC.Container.Register<IDataService, SqlDataService>();
			FreshIOC.Container.Register<IRemoteService, RemoteService>();

			var tabs = new FreshTabbedNavigationContainer();
			tabs.AddTab<TareasViewModel>("Tareas", "tarea");
			tabs.AddTab<ClientesViewModel>("Clientes", "cliente");

			MainPage = tabs;
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
