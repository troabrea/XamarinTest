using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FormsTestApp;
using Foundation;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.XamarinIOS;
using UIKit;
using Xamarin.Forms;

[assembly:Dependency(typeof(FormsTestApp.iOS.SQLLite))]

namespace FormsTestApp.iOS
{
	public class SQLLite : ISqlLite
	{
		#region ISQLite implementation
		public SQLite.Net.Async.SQLiteAsyncConnection GetConnection()
		{
			string dbLocation = "TodoApp.db3";

			var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var libraryPath = Path.Combine(docsPath, "../Library/");
			dbLocation = Path.Combine(libraryPath, dbLocation);
			var sqlConn = new SQLiteConnectionWithLock(new SQLitePlatformIOS(), new SQLiteConnectionString(dbLocation, false));
			return new SQLiteAsyncConnection(() => sqlConn);
		}
		#endregion
	}

	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}
