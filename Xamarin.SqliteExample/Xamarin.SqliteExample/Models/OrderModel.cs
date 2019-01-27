#region USING
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;
#endregion

namespace Xamarin.SqliteExample.Models
{
    [Table("Order")]
    public class OrderModel
    {
        [PrimaryKey, Column("OrderId")]
        public int OrderId { get; set; }

        [Column("OrderName"), NotNull]
        [Indexed]
        public string OrderName { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<OrderPurchaseModel> OrderPurchases { get; set; }

    }
}
