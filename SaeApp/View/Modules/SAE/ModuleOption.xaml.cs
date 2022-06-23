using SaeApp.Model.Modules.System.Secutiry;
using SaeApp.Resources;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaeApp.View.Modules.SAE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModuleOption : ContentPage
    {
        public ModuleOption(Resource objResource)
        {
            InitializeComponent();

            CreateList(objResource.IdRecurso);
        }

        public ModuleOption()
        {
            InitializeComponent();
        }

        void CreateList(int idResource)
        {
            try
            {
                SelectNameModule(idResource);

                List<Resource> objResourceList = new List<Resource>();

                if (idResource == Resource.ID_RESOURCE_INVENTORY)
                {
                    objResourceList.Add(new Resource 
                    {
                        IdRecurso = Resource.ID_RESOURCE_INVENTORY_ITEM,
                        IdRecursoPadre = Resource.ID_RESOURCE_INVENTORY,
                        Nombre = "Articulos",
                        IdModulo = Resource.ID_RESOURCE_INVENTORY,
                    });

                    objResourceList.Add(new Resource
                    {
                        IdRecurso = Resource.ID_RESOURCE_INVENTORY_INVENTORYMOVEMENT,
                        IdRecursoPadre = Resource.ID_RESOURCE_INVENTORY,
                        Nombre = "Movimiento de inventario",
                        IdModulo = Resource.ID_RESOURCE_INVENTORY,
                    });
                }
                else
                {
                    objResourceList.Add(new Resource
                    {
                        IdRecurso = Resource.ID_RESOURCE_SELL_INVOICE,
                        IdRecursoPadre = Resource.ID_RESOURCE_SELL,
                        Nombre = "Factura",
                        IdModulo = Resource.ID_RESOURCE_SELL,
                    });

                    objResourceList.Add(new Resource
                    {
                        IdRecurso = Resource.ID_RESOURCE_SELL_DELIVERYNOTE,
                        IdRecursoPadre = Resource.ID_RESOURCE_SELL,
                        Nombre = "Nota de entrega",
                        IdModulo = Resource.ID_RESOURCE_SELL,
                    });

                    objResourceList.Add(new Resource
                    {
                        IdRecurso = Resource.ID_RESOURCE_SELL_PROFORMA,
                        IdRecursoPadre = Resource.ID_RESOURCE_SELL,
                        Nombre = "Cotización",
                        IdModulo = Resource.ID_RESOURCE_SELL,
                    });
                }
              
                listaGestion.ItemsSource = objResourceList;
            }
            catch (Exception exc)
            {
                Tools.DisplayAlert("Ha ocurrido un error: " + exc.Message);
            }
        }

        void SelectNameModule(int idResource)
        {
            switch (idResource)
            {
                case Resource.ID_RESOURCE_SYSTEM:
                    sectionName.Text = "Sistema";
                    break;

                case Resource.ID_RESOURCE_INVENTORY:
                    sectionName.Text = "Inventario";
                    break;

                case Resource.ID_RESOURCE_SELL:
                    sectionName.Text = "Ventas";
                    break;

                default:
                    sectionName.Text = "Opciones del módulo";
                    break;
            }
        }

        async void ButtonAlignment_Clicked(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;

                if (button.BindingContext is Resource objResource)
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new MasterDetailPA(objResource));
                }
            }
            catch (Exception exc)
            {
                Tools.DisplayAlert("Ha ocurrido un error: " + exc.Message);
            }
        }
    }
}