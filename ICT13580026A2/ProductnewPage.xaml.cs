using System;
using System.Collections.Generic;
using ICT13580026A2.Models;

using Xamarin.Forms;

namespace ICT13580026A2
{
    public partial class ProductnewPage : ContentPage
    {

        Product product;

        public ProductnewPage(Product product = null)
        {
            InitializeComponent();
            this.product = product;

            addProduct.Clicked += AddProduct_Clicked;
            cancelProduct.Clicked += CancelProduct_Clicked;

            catgoryProduct.Items.Add("เสื้อ");
            catgoryProduct.Items.Add("กางเกง");
            catgoryProduct.Items.Add("ถุงเท้า");

            if (product != null)
            {
                titleLabel.Text = "แก้ไขข้อมูลสินค้า";
                nameProduct.Text = product.Name;
                detillProduct.Text = product.Description;
                catgoryProduct.SelectedItem = product.Cateory;
                costProduct.Text = product.ProductPrice.ToString();
                priceProduct.Text = product.SellPrice.ToString();
                numberProduct.Text = product.Stock.ToString();


            }
        }


        async void AddProduct_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกใช่หรือไม่", "ใช่", "ไม่ใช่");
            if (isOk)
            {
                if (product == null)
                {

                    product = new Product();
                    product.Name = nameProduct.Text;
                    product.Description = detillProduct.Text;
                    product.Cateory = catgoryProduct.SelectedItem.ToString();
                    product.ProductPrice = decimal.Parse(costProduct.Text);
                    product.SellPrice = decimal.Parse(priceProduct.Text);
                    product.Stock = int.Parse(numberProduct.Text);
                    var id = App.DbHelper.AddProduct(product);
                    await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าขอท่านคือ #" + id, "ตกลง");


                }
                else
                {

                    product.Name = nameProduct.Text;
                    product.Description = detillProduct.Text;
                    product.Cateory = catgoryProduct.SelectedItem.ToString();
                    product.ProductPrice = decimal.Parse(costProduct.Text);
                    product.SellPrice = decimal.Parse(priceProduct.Text);
                    product.Stock = int.Parse(numberProduct.Text);
                    var id = App.DbHelper.UpdateProduct(product);
                    await DisplayAlert("บันทึกสำเร็จ", "แก้ไขข้อมูลเรียบร้อย#" + id, "ตกลง");

                }
                await Navigation.PopModalAsync();
            }
        }

        void CancelProduct_Clicked(object sender, EventArgs e)
        {

        }
    }
}
