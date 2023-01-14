using Newtonsoft.Json;
using ProductDemo.Interfaces;
using ProductDemo.Model;
using ProductDemo.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProductDemo.ViewModel
{
    public class ProductListViewModel : BaseViewModel
    {
        #region Properties

        private ObservableCollection<ProductModel> productCollection;

        public ObservableCollection<ProductModel> ProductCollection
        {
            get { return productCollection; }
            set 
            {
                productCollection = value;
                NotifyPropertyChanged(nameof(ProductCollection));
            }
        }

        private ProductModel selectedProduct;

        public ProductModel SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                NotifyPropertyChanged(nameof(SelectedProduct));
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

        private double rotationY = 0.0;

        public double RotationY
        {
            get { return rotationY; }
            set
            {
                rotationY = value;
                NotifyPropertyChanged(nameof(RotationY));
            }
        }

        #endregion

        #region Commands

        public ICommand SelectedProductCommand { get; }
        public ICommand RTLCommand { get; }

        #endregion

        #region Constructors
        public ProductListViewModel(INavigation navigation) : base(navigation)
        {
            GetProductList();
            SelectedProductCommand = new Command(() => SelectedProductCommandExecute());
            RTLCommand = new Command(() => RTLCommandExecute());
        }
        #endregion

        #region Command handlers

        private async void SelectedProductCommandExecute()
        {
            if (selectedProduct != null)
            {
                await Navigation.PushAsync(new ProductDetail(selectedProduct));
                SelectedProduct = null;
            }
        }

        #endregion

        #region Methods

        private async void GetProductList()
        {
            try
            {
                string fileContent = string.Empty;
                var assembly = typeof(ProductListViewModel).GetTypeInfo().Assembly;
                var stream = assembly.GetManifestResourceStream("ProductDemo.Helper.Products.json");

                using (var reader = new StreamReader(stream))
                {
                    fileContent = await reader.ReadToEndAsync();
                }

                ProductCollection = JsonConvert.DeserializeObject<ObservableCollection<ProductModel>>(fileContent);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            
        }

        private void RTLCommandExecute()
        {
            RotationY = RotationY == 180 ? 0.0 : 180;
            foreach (var item in ProductCollection)
            {
                item.RotationY = item.RotationY == 180 ? 0.0 : 180;
            }
            RTLText = RTLText == "RTL" ? "LTR" : "RTL";
        }
        #endregion
    }
}
