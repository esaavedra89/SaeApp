using SaeApp.Model.Modules.Inventory;
using SaeApp.Model.Modules.System.Secutiry;
using SaeApp.Resources;
using SaeApp.View.Modules.SAE;
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
    public partial class InventoryMovementPA : ContentPage
    {
        public Resource ResourceSelected { get; set; }

        public InventoryMovementPA()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        public InventoryMovementPA(Resource objResource)
        {
            InitializeComponent();
            this.BindingContext = this;
            PageLoad();
            this.ResourceSelected = objResource;
            InventoryMovementList.ItemSelected += InventoryMovementList_ItemSelected; ;
        }

        private void InventoryMovementList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                InventoryMovement objItemSelected = e.SelectedItem as InventoryMovement;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new MasterDetailDetail(this.ResourceSelected, objItemSelected));
                });
            }
            catch (Exception exc)
            {
                Tools.DisplayAlert(exc.Message);
            }
        }

        async void PageLoad()
        {
            List<InventoryMovement> objInventoryMovementList = new List<InventoryMovement>();

            try
            {
                InventoryMovement objInventoryMovement1 = new InventoryMovement();
                objInventoryMovement1.IdInventoryMovement = 1;
                objInventoryMovement1.IdInventoryMovementType = 1;
                objInventoryMovement1.Number = 253;
                objInventoryMovement1.NumberInvoice = "5";
                objInventoryMovement1.Comments = "Prueba";
                objInventoryMovement1.Comments = "Requisición";
                objInventoryMovement1.InventoryMovementType = new InventoryMovementType();
                objInventoryMovement1.InventoryMovementType.IdInventoryMovementType = 1;
                objInventoryMovement1.InventoryMovementType.Name = "Entrada";
                objInventoryMovement1.IdResponsibleUser = 1;
                objInventoryMovement1.ResponsibleUser = new Model.Modules.System.Security.User();
                objInventoryMovement1.ResponsibleUser.IdUser = 1;
                objInventoryMovement1.ResponsibleUser.IdLocal = 1;
                objInventoryMovement1.ResponsibleUser.Login = "esaavedrah";
                objInventoryMovement1.IdStateEntity = 1;
                objInventoryMovement1.StateEntity = new Model.Modules.System.Entity.StateEntity();
                objInventoryMovement1.StateEntity.Name = "Aplicado";
                objInventoryMovement1.IdInventoryMovementMotive = 1;
                objInventoryMovement1.AdmissionDate = new DateTime(2022, 5, 13);
                objInventoryMovement1.ModificationDate = new DateTime(2022, 5, 13);

                objInventoryMovementList.Add(objInventoryMovement1);

                InventoryMovement objInventoryMovement2 = new InventoryMovement();
                objInventoryMovement2.IdInventoryMovement = 2;
                objInventoryMovement2.IdInventoryMovementType = 2;
                objInventoryMovement2.Number = 2;
                objInventoryMovement2.NumberInvoice = "6";
                objInventoryMovement2.Comments = "Prueba 2";
                objInventoryMovement2.InventoryMovementType = new InventoryMovementType();
                objInventoryMovement2.InventoryMovementType.IdInventoryMovementType = 2;
                objInventoryMovement2.InventoryMovementType.Name = "Salida";
                objInventoryMovement2.IdResponsibleUser = 1;
                objInventoryMovement2.ResponsibleUser = new Model.Modules.System.Security.User();
                objInventoryMovement2.ResponsibleUser.IdUser = 1;
                objInventoryMovement2.ResponsibleUser.IdLocal = 1;
                objInventoryMovement2.ResponsibleUser.Login = "esaavedrah";
                objInventoryMovement2.IdStateEntity = 2;
                objInventoryMovement2.StateEntity = new Model.Modules.System.Entity.StateEntity();
                objInventoryMovement2.StateEntity.Name = "Registado";
                objInventoryMovement2.IdInventoryMovementMotive = 1;
                objInventoryMovement2.AdmissionDate = new DateTime(2022, 7, 1);
                objInventoryMovement2.ModificationDate = new DateTime(2022, 7, 4);

                objInventoryMovementList.Add(objInventoryMovement2);

                InventoryMovementList.ItemsSource = objInventoryMovementList;
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