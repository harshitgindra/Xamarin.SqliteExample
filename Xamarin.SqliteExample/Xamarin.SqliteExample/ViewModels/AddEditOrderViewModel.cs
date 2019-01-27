#region USING
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.SqliteExample.DAL;
using Xamarin.SqliteExample.Models;
#endregion

namespace Xamarin.SqliteExample.ViewModels
{
    public class AddEditOrderViewModel : INotifyPropertyChanged
    {
        #region Variables

        public event PropertyChangedEventHandler PropertyChanged;
        public int _count;
        private OrderPurchaseModel _orderPurchase;
        private IList<OrderModel> _orders;
        private int _orderId;
        private Page _pageInstance;

        #endregion

        #region Constructor
        public AddEditOrderViewModel(Page pageInstance, OrderPurchaseModel orderPurchase)
        {
            _pageInstance = pageInstance;
            if (orderPurchase == null)
            {
                _orderPurchase = new OrderPurchaseModel();
                Count = 0;
                PageTitle = "New Purchase";
            }
            else
            {
                _orderPurchase = orderPurchase;
                Count = orderPurchase.Count;
                OrderId = orderPurchase.OrderId;
                PageTitle = orderPurchase.OrderName;
            }
            Orders = (OrderRepository.GetAll().Result);
        }
        #endregion

        #region Methods
        public void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                OrderId = Orders[selectedIndex].OrderId;
            }
        }

        public async Task SaveChanges()
        {
            bool returnValue = true;
            _orderPurchase.Count = Count;
            _orderPurchase.OrderId = OrderId;

            if (OrderId != 0)
            {
                if (_orderPurchase.OrderPurchaseId == 0)
                {
                    returnValue = await OrderPurchaseRepository.Add(_orderPurchase);
                }
                else
                {
                    returnValue = await OrderPurchaseRepository.Edit(_orderPurchase);
                }
            }

            if (returnValue)
            {
                await _pageInstance.Navigation.PopAsync();
            }
        }

        public async Task Delete()
        {
            bool returnValue = false;
            if (_orderPurchase.OrderPurchaseId != 0)
            {
                returnValue = await OrderPurchaseRepository.Delete(_orderPurchase.OrderPurchaseId);
            }

            if (returnValue)
            {
                await _pageInstance.Navigation.PopAsync();
            }
        }
        #endregion

        #region Getters and Setters
        public int Count
        {
            get { return _count; }
            set
            {
                if (_count == value)
                    return;

                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        public int OrderId
        {
            get { return _orderId; }
            set
            {
                if (_orderId == value)
                    return;

                _orderId = value;
                OnPropertyChanged(nameof(OrderId));
            }
        }

        public IList<OrderModel> Orders
        {
            get { return _orders; }
            set
            {
                if (_orders == value)
                    return;

                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        public string PageTitle { get; set; }

        #endregion

        #region Property change implementation

        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion Property change implementation
    }
}
