using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace STVMatrimony.Helpers.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomActivityLoader : Rg.Plugins.Popup.Pages.PopupPage
    {
        public CustomActivityLoader(string LoadingMessage)
        {
            InitializeComponent();
        }
        public static readonly BindableProperty MessageProperty = BindableProperty.Create(
                                                          propertyName: "Message",
                                                          returnType: typeof(string),
                                                          declaringType: typeof(CustomActivityLoader),
                                                          defaultValue: "",
                                                          defaultBindingMode: BindingMode.OneWay,
                                                          propertyChanged: MessagePropertyChanged);

        public string Message
        {
            get { return base.GetValue(MessageProperty).ToString(); }
            set { base.SetValue(MessageProperty, value); }
        }
        private static void MessagePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CustomActivityLoader control = (CustomActivityLoader)bindable;
            if (oldValue != newValue)
            {
              //  control.LblText.Text = newValue.ToString();
            }
        }
    }
}