
using SaeApp.Model.Modules.System.Secutiry;
using SaeApp.Resources;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaeApp.View.Modules.SAE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetail : MasterDetailPage
    {
        public MasterDetail(Resource objResource)
        {
            InitializeComponent();
            // Ocultamos barra de navegación.
            NavigationPage.SetHasNavigationBar(this, false);

            // Asignar página maestro detalle.
            App.MasterD = this;

            // Menu lateral.
            this.Master = new LateralMenu();

            if (objResource.IdRecursoPadre == 0)
            {
                if (objResource.IdRecurso < 100000)
                    SetDetail(objResource);
                else
                    // Detalle.
                    this.Detail = new NavigationPage(new ModuleOption(objResource));
            }
            else
                SetDetail(objResource);
        }

        private void SetDetail(Resource objResource)
        {
            try
            {
                switch (objResource.IdRecurso)
                {
                    case Resource.ID_RESOURCE_HOME:
                        // Detalle.
                        this.Detail = new NavigationPage(new Home());
                        break;
                    case Resource.ID_RESOURCE_SYSTEM:
                        // Detalle.
                        this.Detail = new NavigationPage(new ModuleOption(objResource));
                        break;

                    default:
                        break;
                }
            }
            catch (Exception exc)
            {
                Tools.DisplayAlert("Ha ocurrido un error: " + exc.Message);
            }
        }
    }
}