using System;
using System.Collections.Generic;
using ICT13580026A2.Models;

using Xamarin.Forms;

namespace ICT13580026A2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            newButton.Clicked += NewButton_Clicked;
        }
        protected override void OnAppearing()
        {
            LoadData();
        }


        void LoadData()
        {
            productListview.ItemsSource = App.DbHelper.GetProduct();
        }

        void NewButton_Clicked(object sender, EventArgs e)

        {
            Navigation.PushModalAsync(new ProductnewPage());
        }

        void Edit_Clicked(object sender, System.EventArgs e)
        {
            var button = sender as MenuItem;
            var product = button.CommandParameter as Product;
            Navigation.PushModalAsync(new ProductnewPage(product));
        }

        async void Delete_Clicked(object sender, System.EventArgs e)
        {
            var button = sender as MenuItem;
            var product = button.CommandParameter as Product;

            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการลบใช่หรือไม่", "ใช่", "ไม่ใช่");

            if (isOk)
            {
                App.DbHelper.DeleteProduct(product);
                LoadData();
            }

        }
    }
}
