using SaeApp.Business.Modules.Inventory;
using SaeApp.Model.Modules.Inventory;
using SaeApp.Model.Modules.System.Secutiry;
using SaeApp.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaeApp.View.Modules.Sell
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InvoicePA : ContentPage
    {
        public Resource ResourceSelected { get; set; }
        public InvoicePA()
        {
            InitializeComponent();
        }

        public InvoicePA(Resource objResource)
        {
            InitializeComponent();
            PageLoad();
            this.ResourceSelected = objResource;
            //itemList.ItemSelected += ItemList_ItemSelected;
        }

        async void PageLoad()
        {
            List<Item> objItemList = new List<Item>();

            try
            {
                //objItemList.Add(new Item() 
                //{
                //    IdItem = 1,
                //    IdCompany = 1,
                //    Internalcode = "Ab12",
                //    Name = "Labial mate rojo",
                //    Description = "Labial mate rojo con pinticas azules",
                //    IdBrand = 1,
                //    Amount = 5,
                //    CostPrice = 0.5m,
                //    ProfitPercentage = 30m,
                //    ProfitAmount = 0.2m,
                //    UnitPrice = 0.7m,
                //    SellPrice = 0.7m,

                //});

                //objItemList.Add(new Item()
                //{
                //    IdItem = 2,
                //    IdCompany = 1,
                //    Internalcode = "Ab13",
                //    Name = "base mate",
                //    Description = "base mate rojo con pinticas azules",
                //    IdBrand = 2,
                //    Amount = 10,
                //    CostPrice = 0.7m,
                //    ProfitPercentage = 30m,
                //    ProfitAmount = 0.3m,
                //    UnitPrice = 1m,
                //    SellPrice = 1m,

                //});

                ItemB objItemB = new ItemB();

                objItemList = await objItemB.GetItemsAsync().ConfigureAwait(false);

                itemList.ItemsSource = objItemList;
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