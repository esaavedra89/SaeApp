using Android.Content;
using Android.Views;
using SaeApp.Droid.CustomControls;
using SaeApp.Resources.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ButtonAlignment), typeof(ButtonAlignmentDroid))]
namespace SaeApp.Droid.CustomControls
{
    public class ButtonAlignmentDroid : ButtonRenderer
    {
        public new ButtonAlignment Element
        {
            get
            {
                return (ButtonAlignment)base.Element;
            }
        }

        public ButtonAlignmentDroid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement == null)
            {
                return;
            }

            var button = this.Control;
            button.SetAllCaps(false); // Se desactivan todas las letras mayusculas por defecto.

            SetTextAlignment();

            var x = e.NewElement.FontSize;
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == ButtonAlignment.HorizontalTextAlignmentProperty.PropertyName)
            {
                SetTextAlignment();
            }
            if (e.PropertyName == ButtonAlignment.VerticalTextAlignmentProperty.PropertyName)
            {
                SetTextAlignmentDos();
            }
        }

        /// <summary>
        /// Configura la alineación de los botones.
        /// </summary>
        public void SetTextAlignment()
        {
            Control.Gravity = Element.HorizontalTextAlignment.ToHorizontalGravityFlags();
            Control.Gravity = Element.VerticalTextAlignment.ToVerticalGravityFlags();
        }

        public void SetTextAlignmentDos()
        {

        }
    }

    public static class AlignmentHelper
    {
        /// <summary>
        /// Propiedades horizontales para botón.
        /// </summary>
        /// <param name="alignment"></param>
        public static GravityFlags ToHorizontalGravityFlags(this Xamarin.Forms.TextAlignment alignment)
        {
            if (alignment == Xamarin.Forms.TextAlignment.Center)
            {
                return GravityFlags.CenterHorizontal;
            }
            else if (alignment == Xamarin.Forms.TextAlignment.Start)
            {
                return GravityFlags.Right;
            }
            else
            {
                return GravityFlags.Left;
            }
        }

        /// <summary>
        /// Propiedades verticales para Botón.
        /// </summary>
        /// <param name="alignment"></param>
        public static GravityFlags ToVerticalGravityFlags(this Xamarin.Forms.TextAlignment alignment)
        {
            if (alignment == Xamarin.Forms.TextAlignment.Center)
            {
                return GravityFlags.CenterVertical;
            }
            else if (alignment == Xamarin.Forms.TextAlignment.Start)
            {
                return GravityFlags.Top;
            }
            else
            {
                return GravityFlags.Bottom;
            }
        }
    }
}