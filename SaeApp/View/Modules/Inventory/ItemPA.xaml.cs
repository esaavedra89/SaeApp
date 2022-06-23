using SaeApp.Model.Modules.Inventory;
using SaeApp.Model.Modules.System.Secutiry;
using SaeApp.Resources;
using SaeApp.View.Modules.SAE;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaeApp.View.Modules.Inventory
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemPA : ContentPage
    {
        public Resource ResourceSelected { get; set; }
        public ItemPA(Resource objResource)
        {
            InitializeComponent();
            PageLoad();
            this.ResourceSelected = objResource;
            itemList.ItemSelected += ItemList_ItemSelected;
        }

        private void PageLoad()
        {
            List<Item> objItemList = new List<Item>();

            try
            {
                objItemList.Add(new Item() 
                {
                    IdItem = 1,
                    IdCompany = 1,
                    Internalcode = "Ab12",
                    Name = "Labial mate rojo",
                    Description = "Labial mate rojo con pinticas azules",
                    IdBrand = 1,
                    Amount = 5,
                    CostPrice = 0.5m,
                    ProfitPercentage = 30m,
                    ProfitAmount = 0.2m,
                    UnitPrice = 0.7m,
                    SellPrice = 0.7m,

                });

                objItemList.Add(new Item()
                {
                    IdItem = 2,
                    IdCompany = 1,
                    Internalcode = "Ab13",
                    Name = "base mate",
                    Description = "base mate rojo con pinticas azules",
                    IdBrand = 2,
                    Amount = 10,
                    CostPrice = 0.7m,
                    ProfitPercentage = 30m,
                    ProfitAmount = 0.3m,
                    UnitPrice = 1m,
                    SellPrice = 1m,

                });

                itemList.ItemsSource = objItemList;
            }
            catch (Exception exc)
            {
                Tools.DisplayAlert(exc.Message);
            }
        }

        private void ItemList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                Item objItemSelected = e.SelectedItem as Item;

                Device.BeginInvokeOnMainThread(async ()=> 
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new MasterDetailDetail(this.ResourceSelected, objItemSelected));
                });
            }
            catch (Exception exc)
            {
                Tools.DisplayAlert(exc.Message);
            }
        }

        private void btnSearch_Clicked(object sender, EventArgs e)
        {

        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {

        }
    }
}