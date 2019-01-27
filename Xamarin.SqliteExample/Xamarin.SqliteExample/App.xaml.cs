#region USING
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.SqliteExample.DAL;
using Xamarin.SqliteExample.Models;
#endregion

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Xamarin.SqliteExample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Task.Run(async () => { await Init(); }).Wait();
            MainPage = new NavigationPage(new OrderPurchaseListPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public async Task Init()
        {
            List<OrderModel> orders = new List<OrderModel>
            {
                new OrderModel() { OrderId = 1, OrderName = "Cell Phones" },
                new OrderModel() { OrderId = 2, OrderName = "Smart Watches" },
                new OrderModel() { OrderId = 3, OrderName = "Router" }
            };

            var dataset = (await OrderRepository.GetAll()).Select(x => x.OrderId);

            foreach (var order in orders)
            {
                if (!dataset.Contains(order.OrderId))
                {
                    await OrderRepository.Add(order);
                }
            }
        }
    }
}
