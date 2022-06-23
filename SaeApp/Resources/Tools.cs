using System;
using Xamarin.Forms;

namespace SaeApp.Resources
{
    public class Tools
    {
        public static void DisplayAlert(string message)
        {
			Device.BeginInvokeOnMainThread(async () =>
			{
				try
				{
					await Application.Current.MainPage.DisplayAlert("", message, "Aceptar");
				}
				catch (Exception exc)
				{
					await Application.Current.MainPage.DisplayAlert("", exc.Message, "Aceptar");
				}
			});
        }
    }
}
