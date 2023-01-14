using ProductDemo.Interfaces;
using ProductDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProductDemo.ViewModel
{
    public class ProductDetailViewModel : BaseViewModel
    {
        #region Fields
        private static string cost;
        #endregion

        #region Properties

        private ObservableCollection<Feedback> feedbackCollection = new ObservableCollection<Feedback>();

        public ObservableCollection<Feedback> FeedbackCollection
        {
            get { return feedbackCollection; }
            set
            {
                feedbackCollection = value;
                NotifyPropertyChanged(nameof(FeedbackCollection));
            }
        }

        private ProductModel productDetail;

        public ProductModel ProductDetail
        {
            get { return productDetail; }
            set
            {
                productDetail = value;
                NotifyPropertyChanged(nameof(ProductDetail));
            }
        }

        private FlowDirection rTL = FlowDirection.LeftToRight;

        public FlowDirection RTL
        {
            get { return rTL; }
            set
            {
                rTL = value;
                NotifyPropertyChanged(nameof(RTL));
            }
        }

        private string count = "1";

        public string Count
        {
            get { return count; }
            set
            {
                count = value;
                CalculatePrice();
                NotifyPropertyChanged(nameof(Count));
            }
        }

        private string price;

        public string Price
        {
            get { return price; }
            set
            {
                price = value;
                NotifyPropertyChanged(nameof(Price));
            }
        }

        private string rTLText = "RTL";

        public string RTLText
        {
            get { return rTLText; }
            set 
            {
                rTLText = value;
                NotifyPropertyChanged(nameof(RTLText));
            }
        }


        #endregion

        #region Command
        public ICommand GoBackCommad { get; }
        public ICommand BuyItCommand { get; }
        public ICommand RTLCommand { get; }
        #endregion

        #region Constructors
        public ProductDetailViewModel(INavigation navigation, ProductModel selectedProduct) : base(navigation)
        {
            ProductDetail = selectedProduct;
            cost = productDetail.Price;
            FeedbackCollection = new ObservableCollection<Feedback>(productDetail?.Feedback);
            GoBackCommad = new Command(() => GoBackCommadExecute());
            BuyItCommand = new Command(() => BuyItCommandExecute());
            RTLCommand = new Command(() => RTLCommandExecute());
        }

        #endregion

        #region Command handlers

        private void RTLCommandExecute()
        {
            RTL = RTL == FlowDirection.LeftToRight ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            RTLText = RTLText == "RTL" ? "LTR" : "RTL";
        }

        private void BuyItCommandExecute()
        {
            App.Current.MainPage.DisplayAlert("Message", "Order Successfull!!", "OK");
        }

        private void GoBackCommadExecute()
        {
            Navigation.PopAsync();
        }

        #endregion

        #region Methods

        private void CalculatePrice()
        {
            try
            {
                if (!string.IsNullOrEmpty(count))
                {
                    var tempCost = cost.Substring(1);
                    var finalCost = double.Parse(tempCost) * int.Parse(count);
                    Price = string.Format($"${finalCost}");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            
        }

        #endregion
    }
}
