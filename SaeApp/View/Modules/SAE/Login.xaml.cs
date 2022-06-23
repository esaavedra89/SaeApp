using Newtonsoft.Json;
using SaeApp.DataAccess.Modules.System;
using SaeApp.Model.Modules.System.Security;
using SaeApp.Model.Modules.System.Secutiry;
using SaeApp.Resources;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaeApp.View.Modules.SAE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();

            // Oculta la barra de navegación para la vista.
            NavigationPage.SetHasNavigationBar(this, false);

            // Se obtiene la conexión a la BD.

            InsertarRegistros();

            login.Text = "esjh89";
            password.Text = "123";
        }

        async void InsertarRegistros()
        {
            try
            {
                UserDAO database = await UserDAO.Instance;

                var listaUsuarios = database.GetItemsAsync();
                var resul = listaUsuarios.AsyncState;
                var resul1 = listaUsuarios.Result;
                if (listaUsuarios.Result == null)
                {
                    User objUser = new User();
                    objUser.Name = "Eleazar";
                    objUser.LastName = "Saavedra";
                    objUser.Login = "esjh89";
                    objUser.Password = "123";
                    await database.SaveItemAsync(objUser);
                }
                else
                {
                    User objUser = new User();
                    objUser.Name = "Eleazar";
                    objUser.LastName = "Saavedra";
                    objUser.Login = "esjh89";
                    objUser.Password = "123";
                    await database.SaveItemAsync(objUser);
                }
            }
            catch (Exception exc)
            {
                Tools.DisplayAlert(exc.Message);
            }
        }

        async void LoginOnline()
        {
            User objUsera = (User)BindingContext;

            try
            {

                var objUser = new User();
                objUser.Login = login.Text;
                objUser.Password = password.Text;

                // Creamos el JSON.
                string json = JsonConvert.SerializeObject(objUser);

                // Configuración para evitar error de certificado.
                HttpClientHandler httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => { return true; };

                HttpClient httpClient = new HttpClient(httpClientHandler);

                // Headers.
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));

                // petición.
                HttpResponseMessage response = await httpClient.PostAsync(
                        "https://neobusinessapi.conveyor.cloud/Usuario_AutenticarPrueba",
                        new StringContent(json, Encoding.UTF8, "application/json")).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Application.Current.MainPage.DisplayAlert(
                            response.StatusCode.ToString(),
                            response.ReasonPhrase.ToString(), "Aceptar");
                    });
                }
                else
                {
                    string resultadoJson = await response.Content.ReadAsStringAsync();

                    User objUserResponds = JsonConvert.DeserializeObject<User>(resultadoJson);
                    if (objUserResponds != null && objUserResponds.IdUser > 0)
                    {
                        // Se obtiene la conexión a la BD.
                        //UserDAO database = await UserDAO.Instance;

                        //await database.SaveItemAsync(objUsuarioRespuesta);

                        //Device.BeginInvokeOnMainThread(async () =>
                        //{
                        //    await Application.Current.MainPage.Navigation.PushAsync(new MestroDetalle(), false);
                        //});
                    }
                }
            }
            catch (Exception exc)
            {
                Tools.DisplayAlert(exc.Message);
            }
        }

        async Task LoginOffline()
        {
            try
            {
                UserDAO database = await UserDAO.Instance;

                User objUser = await database.LoginUserAsync(login.Text, password.Text).ConfigureAwait(false);
                if (objUser != null)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new MasterDetail(new Resource() { IdRecurso = Resource.ID_RESOURCE_HOME }), false);
                    });
                }
                else
                    Tools.DisplayAlert("Usuario o clave invalida");
            }
            catch (Exception exc)
            {
                Tools.DisplayAlert(exc.Message);
            }
        }

        async void Button_Clicked_1(object sender, EventArgs e)
        {
            await LoginOffline();
        }
    }
}