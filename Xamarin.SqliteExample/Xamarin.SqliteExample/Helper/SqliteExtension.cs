#region USING
using SQLite;
using Xamarin.Forms;
using Xamarin.SqliteExample.Interfaces;
using Xamarin.SqliteExample.Models;
#endregion

namespace Xamarin.SqliteExample.Helper
{
    public static class SqliteExtension
    {
        public static SQLiteConnection GetConnection()
        {
            var connection = DependencyService.Get<ISQLite>().GetConnection();
            connection.CreateTable<OrderModel>();
            connection.CreateTable<OrderPurchaseModel>();
            return connection;
        }
    }
}
