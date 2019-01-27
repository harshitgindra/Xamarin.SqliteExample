#region USING
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.SqliteExample.Helper;
using Xamarin.SqliteExample.Models;
#endregion

namespace Xamarin.SqliteExample.DAL
{
    public static class OrderRepository
    {
        public static Task<List<OrderModel>> GetAll()
        {
            List<OrderModel> data = null;
            using (var _connection = SqliteExtension.GetConnection())
            {
                data = _connection.Table<OrderModel>()
                           .ToList();
            }

            return Task.FromResult(data);
        }

        public static Task<bool> Add(OrderModel order)
        {
            using (var _connection = SqliteExtension.GetConnection())
            {
                _connection.Insert(order);
            }
            return Task.FromResult(true);
        }
    }
}
