using Xamarin.Forms;

namespace SaeApp.Resources.CustomControls
{
    public class ButtonAlignment : Button
    {
        public static BindableProperty HorizontalTextAlignmentProperty =
            BindableProperty.Create<ButtonAlignment, TextAlignment>(x => x.HorizontalTextAlignment, TextAlignment.Center);

        public TextAlignment HorizontalTextAlignment
        {
            get
            {
                return (TextAlignment)GetValue(HorizontalTextAlignmentProperty);
            }
            set
            {
                SetValue(HorizontalTextAlignmentProperty, value);
            }
        }

        public static BindableProperty VerticalTextAlignmentProperty =
            BindableProperty.Create<ButtonAlignment, TextAlignment>(x => x.VerticalTextAlignment, TextAlignment.Center);

        public TextAlignment VerticalTextAlignment
        {
            get
            {
                return (TextAlignment)GetValue(VerticalTextAlignmentProperty);
            }
            set
            {
                SetValue(VerticalTextAlignmentProperty, value);
            }
        }
    }
}
