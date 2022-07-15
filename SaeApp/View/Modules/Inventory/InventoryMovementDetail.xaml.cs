using SaeApp.Model.Modules.System.Secutiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaeApp.View.Modules.Inventory
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InventoryMovementDetail : ContentPage
    {
        public InventoryMovementDetail()
        {
            InitializeComponent();
            this.BindingContext = this;
            ////page.Title = "Detalle de movimiento de inventario";
        }

        public InventoryMovementDetail(Resource objResource, object objSelected)
        {
            //PageLoad(objResource, objSelected);
            this.BindingContext = this;
            page.Title = "Detalle de movimiento de inventario";
        }

        private void btnEdit_Clicked(object sender, EventArgs e)
        {

        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {

        }

        private void btnClose_Clicked(object sender, EventArgs e)
        {

        }
    }
}