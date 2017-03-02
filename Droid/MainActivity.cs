using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using FormsTestApp;
using SQLite.Net.Async;
using System.IO;
using SQLite.Net.Platform.XamarinAndroid;
using SQLite.Net;

using Xamarin.Forms;

[assembly:Dependency(typeof(FormsTestApp.Droid.SQLite_Droid))]

namespace FormsTestApp.Droid
{

	public class SQLite_Droid : ISqlLite
	{
		SQLiteAsyncConnection ISqlLite.GetConnection()
		{
			string dbLocation = "TodoApp.db3";

			var docsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			var libraryPath = docsPath;
			dbLocation = Path.Combine(libraryPath, dbLocation);
			var sqlConn = new SQLiteConnectionWithLock(new SQLitePlatformAndroid(), new SQLiteConnectionString(dbLocation, false));
			return new SQLiteAsyncConnection(() => sqlConn);
		}
	}

	[Activity(Label = "FormsTestApp.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App());
		}
	}
}
