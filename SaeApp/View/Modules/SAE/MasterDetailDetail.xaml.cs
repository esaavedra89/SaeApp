using SaeApp.Model.Modules.System.Secutiry;
using SaeApp.Resources;
using SaeApp.View.Modules.Inventory;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaeApp.View.Modules.SAE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailDetail : MasterDetailPage
    {
        public MasterDetailDetail(Resource objResource, object objSelected)
        {
            InitializeComponent();
            // Ocultamos barra de navegación.
            NavigationPage.SetHasNavigationBar(this, false);

            // Asignar página maestro detalle.
            App.MasterD = this;

            // Menu lateral.
            this.Master = new LateralMenu();

            SetDetail(objResource, objSelected);
        }

        private void SetDetail(Resource objResource, object objSelected)
        {
            try
            {
                if (objResource.IdRecursoPadre == Resource.ID_RESOURCE_SYSTEM)
                {
                    switch (objResource.IdRecurso)
                    {
                        case Resource.ID_RESOURCE_SYSTEM:
                            this.Detail = new NavigationPage(new ModuleOption(objResource));
                            break;
                        default:

                            break;
                    }
                }
                else if (objResource.IdRecursoPadre == Resource.ID_RESOURCE_INVENTORY)
                {
                    switch (objResource.IdRecurso)
                    {
                        case Resource.ID_RESOURCE_INVENTORY_ITEM:
                            // Detalle.
                            this.Detail = new NavigationPage(new ItemDetail(objResource, objSelected));
                            break;
                        case Resource.ID_RESOURCE_INVENTORY_INVENTORYMOVEMENT:
                            // Detalle.
                            this.Detail = new NavigationPage(new MIDetail(objResource, objSelected));
                            break;

                        default:

                            break;
                    }
                }
                else if (objResource.IdRecursoPadre == Resource.ID_RESOURCE_SELL)
                {
                    switch (objResource.IdRecurso)
                    {
                        case Resource.ID_RESOURCE_SELL_INVOICE:
                            // Detalle.
                            this.Detail = new NavigationPage(new ModuleOption(objResource));
                            break;
                        case Resource.ID_RESOURCE_SELL_DELIVERYNOTE:
                            // Detalle.
                            this.Detail = new NavigationPage(new ModuleOption(objResource));
                            break;
                        case Resource.ID_RESOURCE_SELL_PROFORMA:
                            // Detalle.
                            this.Detail = new NavigationPage(new ModuleOption(objResource));
                            break;

                        default:

                            break;
                    }
                }
                else
                {

                }
            }
            catch (Exception exc)
            {
                Tools.DisplayAlert("Ha ocurrido un error: " + exc.Message);
            }
        }
    }
}