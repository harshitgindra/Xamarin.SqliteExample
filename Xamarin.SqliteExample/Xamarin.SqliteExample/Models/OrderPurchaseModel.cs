#region USING
using SQLite;
using SQLiteNetExtensions.Attributes;
#endregion

namespace Xamarin.SqliteExample.Models
{
    [Table("OrderPurchase")]
    public class OrderPurchaseModel
    {
        [PrimaryKey, Column("OrderPurchaseId"), AutoIncrement]
        public int OrderPurchaseId { get; set; }

        [Column("OrderId")]
        [ForeignKey(typeof(OrderModel))]
        public int OrderId { get; set; }

        [Column("Count"), NotNull]
        public int Count { get; set; }

        [ManyToOne]
        public OrderModel Order { get; set; }

        public string OrderName
        {
            get
            {
                if (Order != null)
                {

                    return Order.OrderName;
                }
                return "";
            }
        }
    }
}
