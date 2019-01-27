#region USING
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.SqliteExample.DAL;
using Xamarin.SqliteExample.Models;
#endregion

namespace Xamarin.SqliteExample.ViewModels
{
    public class OrderPurchaseListViewModel : INotifyPropertyChanged
    {
        #region Variables

        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<OrderPurchaseModel> _orderPurchases;
        private bool _isBusy;
        private ICommand _refreshCommand;
        private Page _pageInstance;

        #endregion

        #region Constructor
        public OrderPurchaseListViewModel(Page pageInstance)
        {
            _pageInstance = pageInstance;
        }
        #endregion

        #region Methods

        public async void OrderListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            OrderPurchaseModel selectedModel = e.SelectedItem as OrderPurchaseModel;
            await _pageInstance.Navigation.PushAsync(new AddEditOrderPage(selectedModel));
        }

        public ICommand RefreshCommand => _refreshCommand ?? (_refreshCommand = new Command(async () =>
        {
            await GetTransactions();
        }));

        public async Task GetTransactions()
        {
            IsBusy = true;
            var model = await OrderPurchaseRepository.GetAll();
            OrderPurchases = new ObservableCollection<OrderPurchaseModel>(model);
            IsBusy = false;
        }

        #endregion

        #region Getters and Setters

        public ObservableCollection<OrderPurchaseModel> OrderPurchases
        {
            get { return _orderPurchases; }
            set
            {
                if (_orderPurchases == value)
                    return;

                _orderPurchases = value;
                OnPropertyChanged(nameof(OrderPurchases));
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy == value)
                    return;

                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

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
