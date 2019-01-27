#region USING
using SQLite;
#endregion
namespace Xamarin.SqliteExample.Interfaces
{
    public interface ISQLite
    {
        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns>The connection.</returns>
        SQLiteConnection GetConnection();
    }
}
