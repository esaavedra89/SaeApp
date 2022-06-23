
using SaeApp.Model.Modules.System.Secutiry;
using SaeApp.Resources;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaeApp.View.Modules.SAE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LateralMenu : ContentPage
    {
        public LateralMenu()
        {
            InitializeComponent();

            CreateList();
        }

        void CreateList()
        {
            try
            {
                List<Resource> objResourceList = new List<Resource>();

                Resource objResource = new Resource();
                objResource.IdRecurso = Resource.ID_RESOURCE_SYSTEM;
                objResource.Nombre = "Sistema";
                objResourceList.Add(objResource);

                Resource objResource2 = new Resource();
                objResource2.IdRecurso = Resource.ID_RESOURCE_INVENTORY;
                objResource2.Nombre = "Inventario";
                objResourceList.Add(objResource2);

                Resource objResource3 = new Resource();
                objResource3.IdRecurso = Resource.ID_RESOURCE_SELL;
                objResource3.Nombre = "Ventas";
                objResourceList.Add(objResource3);

                menuList.ItemsSource = objResourceList;
            }
            catch (Exception exc)
            {
                Tools.DisplayAlert("Ha ocurrido un error: " + exc.Message);
            }
        }

        //private void MenuList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    try
        //    {
        //        Resource objSelectecd = e.SelectedItem as Resource;

        //        Tools.DisplayAlert(objSelectecd.Nombre);
        //    }
        //    catch (Exception exc)
        //    {
        //        Tools.DisplayAlert("Ha ocurrido un error: " + exc.Message);
        //    }
        //}

        async void ButtonAlignment_Clicked(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                if (button.BindingContext is Resource objResource)
                {
                    // Creamos el objeto.
                    // Navegamos hasta Despacho.
                    await Application.Current.MainPage.Navigation.PushAsync(new MasterDetail(objResource));
                }
            }
            catch (Exception exc)
            {
                Tools.DisplayAlert("Ha ocurrido un error: " + exc.Message);
            }
        }
    }
}