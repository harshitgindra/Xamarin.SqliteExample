using System.IO;
using SQLite;
using Xamarin.Forms;
using Xamarin.SqliteExample.Droid.Implementations;
using Xamarin.SqliteExample.Interfaces;

[assembly: Dependency(typeof(SQLite_Android))]
namespace Xamarin.SqliteExample.Droid.Implementations
{
    public class SQLite_Android : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "SqliteExample.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);

            // Create the connection
            var conn = new SQLiteConnection(path);

            // Return the database connection
            return conn;
        }
    }

}
