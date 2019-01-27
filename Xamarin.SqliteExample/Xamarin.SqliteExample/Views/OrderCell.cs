using System;
using Xamarin.Forms;
using Xamarin.SqliteExample.Models;

namespace Xamarin.SqliteExample
{
    public class OrderCell : TextCell
    {
        public OrderCell()
        {
            this.SetBinding(TextProperty, nameof(OrderPurchaseModel.OrderName));
            this.SetBinding(TextCell.DetailProperty, nameof(OrderPurchaseModel.Count), stringFormat: "Count: {0}");
        }
    }
}
