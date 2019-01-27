using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using Xamarin.SqliteExample.Interfaces;
using Xamarin.SqliteExample.iOS.Implementations;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace Xamarin.SqliteExample.iOS.Implementations
{
    public class SQLite_iOS : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "SqliteExample.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);

            // Create the connection
            var conn = new SQLiteConnection(path);

            // Return the database connection
            return conn;
        }
    }

}
