#region USING
using Xamarin.Forms;
using Xamarin.SqliteExample.ViewModels;
#endregion

namespace Xamarin.SqliteExample
{
    public class OrderPurchaseListPage : ContentPage
    {
        #region Variables
        private readonly OrderPurchaseListViewModel _vm;
        #endregion

        #region Constructor
        public OrderPurchaseListPage()
        {
            _vm = new OrderPurchaseListViewModel(this);
            BindingContext = _vm;
            SetupView();
            SetupNavigationBar();
            this.Title = "Purchases";
        }
        #endregion

        #region Overriding Methods

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _vm.GetTransactions();
        }

        #endregion

        #region Views Setup
        private void SetupView()
        {
            var orderListView = new ListView(ListViewCachingStrategy.RecycleElement)
            {
                HasUnevenRows = true,
                ItemTemplate = new DataTemplate(typeof(OrderCell)),
                SeparatorColor = Color.Black,
                SeparatorVisibility = SeparatorVisibility.Default,
                RefreshCommand = _vm.RefreshCommand,
                IsPullToRefreshEnabled = true,
                Margin = 10,
            };
            orderListView.ItemSelected += _vm.OrderListView_ItemSelected;
            orderListView.SetBinding(ItemsView<Cell>.ItemsSourceProperty, nameof(OrderPurchaseListViewModel.OrderPurchases), BindingMode.OneWay);
            orderListView.SetBinding(ListView.IsRefreshingProperty, nameof(OrderPurchaseListViewModel.IsBusy));

            this.Content = orderListView;
        }

        private void SetupNavigationBar()
        {
            var share = new ToolbarItem
            {
                Text = "Add",
                Command = new Command(async () =>
                {
                    await Navigation.PushAsync(new AddEditOrderPage(null));
                }),
                Priority = 1
            };

            ToolbarItems.Add(share);
        }
        #endregion
    }
}
