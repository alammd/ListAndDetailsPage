using ProductDemo.Helper;
using ProductDemo.Interfaces;
using ProductDemo.Model;
using ProductDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProductDemo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetail : ContentPage
    {
        public ProductDetail(ProductModel selectedProduct)
        {
            InitializeComponent();
            BindingContext = new ProductDetailViewModel(Navigation, selectedProduct);
        }

        protected override void OnAppearing()
        {
            Statusbar.SetStatusbarAndNavigationBarColor("#29283a", "#29283a");
            base.OnAppearing();
        }
    }
}