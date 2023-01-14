using ProductDemo.Helper;
using ProductDemo.Interfaces;
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
    public partial class ProductList : ContentPage
    {
        ProductListViewModel productListViewModel;
        public ProductList()
        {
            InitializeComponent();
            productListViewModel = new ProductListViewModel(Navigation);
            BindingContext = productListViewModel;
        }

        protected override void OnAppearing()
        {
            Statusbar.SetStatusbarAndNavigationBarColor("#876e47", "#5c492b");
            base.OnAppearing();
        }
    }
}