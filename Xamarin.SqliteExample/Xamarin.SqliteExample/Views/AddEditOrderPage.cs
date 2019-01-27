#region USING
using Xamarin.Forms;
using Xamarin.SqliteExample.Models;
using Xamarin.SqliteExample.ViewModels;
#endregion

namespace Xamarin.SqliteExample
{
    public class AddEditOrderPage : ContentPage
    {
        #region Variables
        private readonly AddEditOrderViewModel _vm;
        #endregion

        #region Constructor
        public AddEditOrderPage(OrderPurchaseModel orderPurchase)
        {
            _vm = new AddEditOrderViewModel(this, orderPurchase);
            BindingContext = _vm;
            SetupView();
            SetupNavigationBar();
            this.SetBinding(TitleProperty, nameof(_vm.PageTitle));
        }
        #endregion

        #region Views Setup
        private void SetupView()
        {
            Label orderLabel = new Label() { Text = "Select Order" };
            Picker orderPicker = new Picker
            {
                Title = "Orders",
                Margin = new Thickness(10, 0)
            };
            orderPicker.SetBinding(Picker.ItemsSourceProperty, nameof(AddEditOrderViewModel.Orders));
            orderPicker.ItemDisplayBinding = new Binding(nameof(OrderModel.OrderName));
            orderPicker.SelectedIndexChanged += _vm.OnPickerSelectedIndexChanged;

            Label countLabel = new Label() { Text = "Enter Count" };
            Entry countEntry = new Entry()
            {
                Keyboard = Keyboard.Numeric,
                Placeholder = "Count"
            };
            countEntry.SetBinding(Entry.TextProperty, nameof(AddEditOrderViewModel.Count));

            Button saveButton = new Button()
            {
                Text = "Save",
                Command = new Command(async () =>
                {
                    await _vm.SaveChanges();
                }),
            };

            StackLayout layout = new StackLayout()
            {
                Children = { orderLabel, orderPicker, countLabel, countEntry, saveButton },
                Margin = 10,
                Padding = 10,
            };

            this.Content = layout;
        }

        private void SetupNavigationBar()
        {
            var share = new ToolbarItem
            {
                Text = "Delete",
                Command = new Command(async () =>
                {
                    await _vm.Delete();
                }),
                Priority = 1
            };

            ToolbarItems.Add(share);
        }
        #endregion
    }
}

