#region USING
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLiteNetExtensions.Extensions;
using Xamarin.SqliteExample.Helper;
using Xamarin.SqliteExample.Models;
#endregion

namespace Xamarin.SqliteExample.DAL
{
    public static class OrderPurchaseRepository
    {
        public static Task<List<OrderPurchaseModel>> GetAll()
        {
            List<OrderPurchaseModel> data = null;
            using (var connection = SqliteExtension.GetConnection())
            {
                data =  connection.GetAllWithChildren<OrderPurchaseModel>();
            }

            return Task.FromResult(data);
        }

        public static Task<bool> Add(OrderPurchaseModel order)
        {
            using (var connection = SqliteExtension.GetConnection())
            {
                connection.Insert(order);
            }
            return Task.FromResult(true);
        }

        public static Task<bool> Edit(OrderPurchaseModel model)
        {
            using (var connection = SqliteExtension.GetConnection())
            {
                string sqlQuery = $"Update OrderPurchase set OrderId = ?, Count = ? where OrderPurchaseId = ?";
                var ret = connection.Execute(sqlQuery, model.OrderId, model.Count, model.OrderPurchaseId);
            }
            return Task.FromResult(true);
        }

        public static Task<bool> Delete(int orderPurchaseId)
        {
            using (var connection = SqliteExtension.GetConnection())
            {
                var data = connection.Get<OrderPurchaseModel>(orderPurchaseId);
                connection.Delete(data);
            }
            return Task.FromResult(true);
        }
    }
}
